import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";

const ProjectDetails = () => {
  const { id } = useParams();   // 🔥 get id from URL
  const [project, setProject] = useState(null);

  useEffect(() => {
    fetch(`http://localhost:5000/api/portfolio/${id}`)
      .then(res => res.json())
      .then(data => setProject(data))
      .catch(err => console.log(err));
  }, [id]); // 🔥 runs when id changes

  if (!project) return <p>Loading...</p>;

  return (
    <div style={{ padding: "40px" }}>

      <h2>{project.title}</h2>

      <img 
        src={project.imageUrl} 
        alt={project.title}
        style={{ width: "400px", margin: "20px 0" }}
      />

      <p>{project.description}</p>

      <p><strong>Client:</strong> {project.clientName}</p>

      <p><strong>Technologies:</strong> {project.technologies}</p>

      <a href={project.projectUrl} target="_blank" rel="noreferrer">
        View Project
      </a>

    </div>
  );
};

export default ProjectDetails;