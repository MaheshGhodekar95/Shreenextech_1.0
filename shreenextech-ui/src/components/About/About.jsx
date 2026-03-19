import React from "react";
import "./About.css";

const About = () => {
  return (
    <section className="About">

      <div className="about-container">

        <div className="about-text">
          <h2>About ShreenexTech</h2>
          <p>
            We are a modern IT company delivering scalable web applications,
            cloud solutions and enterprise software using latest technologies.
          </p>
          <button className="about-btn">Learn More</button>
        </div>

        <div className="about-image">
          <img src="https://picsum.photos/500/300" alt="about"/>
        </div>

      </div>

    </section>
  );
};

export default About;