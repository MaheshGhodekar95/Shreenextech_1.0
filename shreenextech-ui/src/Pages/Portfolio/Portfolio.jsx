import React from "react";
import "./Portfolio.css";

function Portfolio() {
  const projects = [
    {
      title: "E-Commerce Platform",
      description: "Full stack e-commerce web application with secure payments.",
      image: "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d"
    },
    {
      title: "Healthcare System",
      description: "Hospital management system for appointments and records.",
      image: "https://images.unsplash.com/photo-1576091160550-2173dba999ef"
    },
    {
      title: "Cloud Dashboard",
      description: "Admin dashboard for managing cloud infrastructure.",
      image: "https://images.unsplash.com/photo-1551288049-bebda4e38f71"
    },
    {
      title: "AI Analytics Tool",
      description: "Data analytics platform powered by AI insights.",
      image: "https://images.unsplash.com/photo-1518779578993-ec3579fee39f"
    }
  ];

  return (
    <div className="portfolio-page">

      {/* Hero */}
      <div className="portfolio-hero">
        <h1>Our Portfolio</h1>
        <p>Some of the projects we have built for our clients.</p>
      </div>

      {/* Projects */}
      <div className="portfolio-container">

        {projects.map((project, index) => (
          <div className="project-card" key={index}>
            <img src={project.image} alt={project.title} />
            <div className="project-info">
              <h3>{project.title}</h3>
              <p>{project.description}</p>
              <button>View Project</button>
            </div>
          </div>
        ))}

      </div>

    </div>
  );
}

export default Portfolio;