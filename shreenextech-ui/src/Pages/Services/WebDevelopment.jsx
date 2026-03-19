import React from "react";
import "./WebDevelopment.css";

const WebDevelopment = () => {
  return (
    <div className="web-page">

      <h1>Web Development</h1>

      <p className="web-intro">
        At ShreenexTech, we build modern, scalable, and high-performance web
        applications using the latest technologies like React, .NET, and cloud platforms.
      </p>

      <h2>What We Offer</h2>

      <ul className="web-list">
        <li>Custom Website Development</li>
        <li>Enterprise Web Applications</li>
        <li>E-Commerce Platforms</li>
        <li>API Development</li>
        <li>Performance Optimization</li>
      </ul>

      <h2>Technologies We Use</h2>

      <p className="web-tech">
        React, .NET Core, Node.js, SQL Server, Azure Cloud, REST APIs.
      </p>

    </div>
  );
};

export default WebDevelopment;