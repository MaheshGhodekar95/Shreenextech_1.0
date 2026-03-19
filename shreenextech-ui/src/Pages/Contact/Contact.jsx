import React from "react";
import "./Contact.css";

function Contact() {
  return (
    <div className="contact-page">

      {/* Hero */}
      <div className="contact-hero">
        <h1>Contact Us</h1>
        <p>We would love to hear about your project.</p>
      </div>

      {/* Contact Section */}
      <div className="contact-container">

        {/* Contact Form */}
        <div className="contact-form">

          <h2>Send us a message</h2>

          <form>
            <input type="text" placeholder="Your Name" required />

            <input type="email" placeholder="Your Email" required />

            <input type="text" placeholder="Subject" />

            <textarea placeholder="Your Message" rows="5"></textarea>

            <button type="submit">Send Message</button>
          </form>

        </div>

        {/* Contact Info */}
        <div className="contact-info">

          <h2>Get in touch</h2>

          <p>
            We help businesses build modern digital solutions including
            websites, enterprise software, and cloud platforms.
          </p>

          <div className="info-item">
            <strong>Email</strong>
            <p>contact@shreenextech.com</p>
          </div>

          <div className="info-item">
            <strong>Phone</strong>
            <p>+91 9689038319</p>
          </div>

          <div className="info-item">
            <strong>Location</strong>
            <p>India</p>
          </div>

        </div>

      </div>

    </div>
  );
}

export default Contact;