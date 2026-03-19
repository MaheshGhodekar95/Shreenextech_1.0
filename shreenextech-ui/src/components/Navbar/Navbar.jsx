import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import logo from "../../Assets/Images/Shree2.png";
import "./Navbar.css";

const Navbar = () => {
  const [scrolled, setScrolled] = useState(false);
  const [open, setOpen] = useState(false);

  useEffect(() => {
    const handleScroll = () => {
      setScrolled(window.scrollY > 50);
    };
    window.addEventListener("scroll", handleScroll);
  }, []);

  return (
    <nav className={`navbar ${scrolled ? "scrolled" : ""}`}>

      <div className="nav-container">

        {/* Logo */}
        <Link to="/" className="logo">
          <img src={logo} alt="logo" />
          ShreenexTech
        </Link>

        {/* Menu */}
        <div className={`nav-links ${open ? "active" : ""}`}>
          <Link to="/">Home</Link>
          <Link to="/services">Services</Link>
          <Link to="/portfolio">Portfolio</Link>
          <Link to="/about">About</Link>
          <Link to="/contact">Contact</Link>
          <Link to="/start-project" className="nav-btn">Get Started</Link>
        </div>

        {/* Hamburger */}
        <div className="menu-icon" onClick={() => setOpen(!open)}>
          ☰
        </div>

      </div>

    </nav>
  );
};

export default Navbar;