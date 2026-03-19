using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShreenexTech.API.Data;

namespace ShreenexTech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PortfolioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PortfolioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/portfolio
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _context.Portfolio
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.ImageUrl
                })
                .ToList();

            return Ok(data);
        }
        [HttpGet]
        public IActionResult GetProjectById(int Id)
        {
            var data = _context.Portfolio
                .Select(p => p.Id == Id); 
                

            return Ok(data);
        }
    }
}
