import React from "react";
import "./Services.css";
import { Link } from "react-router-dom";

const Services = () => {
  return (
    <section className="services">
      <h2>Our Services</h2>

      <div className="services-container">

        <Link to="/services/web-development" className="service-link">
          <div className="service-card">
            <h3>Web Development</h3>
            <p>
              Modern responsive websites using React, .NET and latest technologies.
            </p>
          </div>
        </Link>

        <Link to="/services/mobile-apps" className="service-link">
          <div className="service-card">
            <h3>Mobile Apps</h3>
            <p>
              High performance Android & iOS apps for startups and businesses.
            </p>
          </div>
        </Link>

        <Link to="/services/cloud-solutions" className="service-link">
          <div className="service-card">
            <h3>Cloud Solutions</h3>
            <p>
              Azure cloud deployment, DevOps pipelines and scalable systems.
            </p>
          </div>
        </Link>

      </div>
    </section>
  );
};

export default Services;