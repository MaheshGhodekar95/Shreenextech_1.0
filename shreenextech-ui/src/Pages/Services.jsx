import React from "react";
import "./Services.css";

function Services() {
  return (
    <div className="services-page">

      <div className="services-hero">
        <h1>Our IT Services</h1>
        <p>We build scalable and modern software solutions for businesses.</p>
      </div>

      <div className="services-container">

        <div className="service-card">
          <h3>Custom Software Development</h3>
          <p>
            Tailor-made enterprise solutions designed to streamline your
            business operations and improve productivity.
          </p>
        </div>

        <div className="service-card">
          <h3>Web Application Development</h3>
          <p>
            Modern and responsive web applications using technologies like
            React and .NET.
          </p>
        </div>

        <div className="service-card">
          <h3>Mobile App Development</h3>
          <p>
            Build high performance Android and cross-platform mobile apps for
            your business.
          </p>
        </div>

        <div className="service-card">
          <h3>Cloud Solutions</h3>
          <p>
            Cloud migration, hosting, and scalable infrastructure setup for
            modern businesses.
          </p>
        </div>

        <div className="service-card">
          <h3>AI & Automation</h3>
          <p>
            Intelligent automation solutions including AI chatbots and
            machine learning integrations.
          </p>
        </div>

        <div className="service-card">
          <h3>Maintenance & Support</h3>
          <p>
            Continuous monitoring, bug fixing, security updates and technical
            support.
          </p>
        </div>

      </div>

      <div className="services-cta">
        <h2>Have a Project in Mind?</h2>
        <p>Let's build something amazing together.</p>
        <button>Contact Us</button>
      </div>

    </div>
  );
}

export default Services;