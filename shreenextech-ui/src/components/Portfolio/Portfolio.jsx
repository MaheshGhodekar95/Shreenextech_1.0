import React, { useEffect, useState } from "react";
import "./Portfolio.css";

const Portfolio = () => {
  const [projects, setProjects] = useState([]);

  useEffect(() => {
    fetch("http://localhost:5142/api/portfolio")
      .then(res => res.json())
      .then(data => {
        console.log(data);
        setProjects(data);
      })
      .catch(err => console.log(err));
  }, []);

  return (
    <section className="Portfolio">
      <h2>Our Projects</h2>

      <div className="Portfolio-grid">

        {projects.length === 0 ? (
          <p>Loading projects...</p>
        ) : (
          projects.map((p) => (
            <div className="project" key={p.id}>
              <img src={p.imageUrl} alt={p.title} className="project-img" />
              <h3 className="project-title">{p.Title}</h3>
            </div>
          ))
        )}

      </div>
    </section>
  );
};

export default Portfolio;