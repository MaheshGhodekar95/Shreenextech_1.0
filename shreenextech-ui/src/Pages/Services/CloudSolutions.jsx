import React from "react";
import "./CloudSolutions.css";

const CloudSolutions = () => {
  return (
    <div className="cloud-page">

      <h1>Cloud Solutions</h1>

      <p className="cloud-intro">
        We help businesses migrate, build, and scale applications on the cloud
        with secure and reliable infrastructure.
      </p>

      <h2>Our Cloud Services</h2>

      <ul className="cloud-list">
        <li>Cloud Infrastructure Setup</li>
        <li>Azure Cloud Deployment</li>
        <li>DevOps & CI/CD Pipelines</li>
        <li>Cloud Security</li>
        <li>Scalable Microservices Architecture</li>
      </ul>

      <h2>Platforms We Work With</h2>

      <p className="cloud-tech">
        Microsoft Azure, AWS, Docker, Kubernetes, GitHub Actions.
      </p>

    </div>
  );
};

export default CloudSolutions;