import React from "react";
import { motion } from "framer-motion";
import { useNavigate } from "react-router-dom";
import logo from "../../Assets/Images/L.jpg";
import "./Hero.css";

const Hero = () => {
  const navigate = useNavigate();

  return (
    <section className="hero-section">
  <div className="hero-container">

    {/* LEFT */}
    <div className="hero-left">

      <motion.h1
        className="hero-title"
        initial={{ opacity: 0, y: -50 }}
        animate={{ opacity: 1, y: 0 }}
        transition={{ duration: 1 }}
      >
        Build <span className="gradient-text">Next-Gen</span> Digital Products
        <br />
        With <span className="brand-text">ShreenexTech</span>
      </motion.h1>

      <p className="hero-text">
        We create scalable software, web platforms, and cloud solutions
        for modern businesses.
      </p>

      <div className="hero-buttons">
        <button
          className="btn-primary"
          onClick={() => navigate("/start-project")}
        >
          🚀 Start Project
        </button>

        <button
          className="btn-secondary"
          onClick={() => navigate("/portfolio")}
        >
          View Portfolio
        </button>
      </div>

    </div>

    {/* RIGHT */}
    <div className="hero-right">
      <img src={logo} alt="Hero" className="hero-img" />
    </div>

  </div>
</section>
  );
};

export default Hero;