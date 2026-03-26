using ShreenexTech.API.Application.Common.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace ShreenexTech.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger,
                                   IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception exception)
        {
            var correlationId = context.TraceIdentifier;

            _logger.LogError(exception,
                "Error occurred. CorrelationId: {CorrelationId}",
                correlationId);

            context.Response.ContentType = "application/json";

            var problem = new ProblemDetails
            {
                Instance = context.Request.Path,
                Extensions = { ["correlationId"] = correlationId }
            };

            switch (exception)
            {
                case FluentValidation.ValidationException ex:
                    problem.Title = "Validation Error";
                    problem.Status = (int)HttpStatusCode.BadRequest;
                    problem.Detail = "One or more validation errors occurred.";
                    problem.Extensions["errors"] = ex.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(
                            x => x.Key,
                            x => x.Select(v => v.ErrorMessage).ToArray());
                    break;

                case AppException ex:
                    problem.Title = "Application Error";
                    problem.Status = ex.StatusCode;
                    problem.Detail = ex.Message;
                    break;

                default:
                    problem.Title = "Server Error";
                    problem.Status = (int)HttpStatusCode.InternalServerError;
                    problem.Detail = _env.IsDevelopment()
                        ? exception.Message
                        : "An unexpected error occurred.";
                    break;
            }

            context.Response.StatusCode = problem.Status.Value;

            var json = JsonSerializer.Serialize(problem,
                new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            await context.Response.WriteAsync(json);
        }
    }
}
