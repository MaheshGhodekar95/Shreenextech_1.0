import React from "react";
import "./StartProject.css";

const StartProject = () => {
  return (
    <div className="project-page">

      <div className="project-header">
        <h1>Start Your Project</h1>
        <p>Tell us about your idea and we will help you build it.</p>
      </div>

      <div className="project-form-container">

        <form className="project-form">

          <div className="form-row">
            <input type="text" placeholder="Full Name" required />
            <input type="email" placeholder="Email Address" required />
          </div>

          <div className="form-row">
            <input type="text" placeholder="Company Name" />
            <input type="text" placeholder="Phone Number" />
          </div>

          <select>
            <option>Select Project Type</option>
            <option>Website Development</option>
            <option>Web Application</option>
            <option>Mobile App</option>
            <option>Cloud Solution</option>
            <option>Custom Software</option>
          </select>

          <select>
            <option>Select Budget</option>
            <option>₹50k - ₹1L</option>
            <option>₹1L - ₹5L</option>
            <option>₹5L - ₹10L</option>
            <option>₹10L+</option>
          </select>

          <textarea
            rows="5"
            placeholder="Describe your project..."
          ></textarea>

          <button className="submit-btn">Submit Project Request</button>

        </form>

      </div>

    </div>
  );
};

export default StartProject;