import React from "react";
import "./Testimonials.css";

const Testimonials = () => {
  return (
    <section className="Testimonials">

      <h2>What Clients Say</h2>

      <div className="testimonial-container">

        <div className="Testimonial">
          <p>"Amazing development team. Delivered our project on time."</p>
          <h4>— Client 1</h4>
        </div>

        <div className="Testimonial">
          <p>"Highly professional IT services and great support."</p>
          <h4>— Client 2</h4>
        </div>

        <div className="Testimonial">
          <p>"Great experience working with the team. Highly recommended."</p>
          <h4>— Client 3</h4>
        </div>

      </div>

    </section>
  );
};

export default Testimonials;