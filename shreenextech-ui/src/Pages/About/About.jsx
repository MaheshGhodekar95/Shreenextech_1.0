import React from "react";
import "./About.css";

function About() {
  return (
    <div className="about-page">

      {/* Hero Section */}
      <div className="about-hero">
        <h1>About ShreenexTech</h1>
        <p>Building smart digital solutions for modern businesses.</p>
      </div>

      {/* Company Intro */}
      <div className="about-container">

        <div className="about-text">
          <h2>Who We Are</h2>
          <p>
            ShreenexTech is a modern IT solutions company focused on delivering
            high quality software, websites, and cloud applications. Our goal
            is to help businesses grow using technology, automation, and smart
            digital solutions.
          </p>

          <p>
            We specialize in web development, enterprise software, and scalable
            cloud solutions. Our team focuses on building reliable, secure and
            high performance applications for startups and enterprises.
          </p>
        </div>

        <div className="about-image">
          <img
            src="https://images.unsplash.com/photo-1552664730-d307ca884978"
            alt="team"
          />
        </div>

      </div>

      {/* Mission Vision */}
      <div className="mission-section">

        <div className="mission-card">
          <h3>Our Mission</h3>
          <p>
            To empower businesses with innovative technology solutions that
            improve efficiency, productivity, and growth.
          </p>
        </div>

        <div className="mission-card">
          <h3>Our Vision</h3>
          <p>
            To become a trusted global technology partner delivering scalable
            and future ready digital solutions.
          </p>
        </div>

      </div>

      {/* Why Choose Us */}
      <div className="why-section">
        <h2>Why Choose Us</h2>

        <div className="why-grid">

          <div className="why-card">
            <h4>Modern Technology</h4>
            <p>We use the latest frameworks and tools to build future-ready applications.</p>
          </div>

          <div className="why-card">
            <h4>Expert Developers</h4>
            <p>Our experienced developers deliver reliable and scalable solutions.</p>
          </div>

          <div className="why-card">
            <h4>Fast Delivery</h4>
            <p>We focus on quick development cycles and efficient delivery.</p>
          </div>

          <div className="why-card">
            <h4>Client Satisfaction</h4>
            <p>We prioritize long term relationships and client success.</p>
          </div>

        </div>
      </div>

    </div>
  );
}

export default About;