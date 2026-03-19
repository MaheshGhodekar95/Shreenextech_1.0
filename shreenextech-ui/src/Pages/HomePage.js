import React from "react";
import Navbar from "../components/Navbar/Navbar";
import Hero from "../components/Hero/Hero";
import Services from "../components/Services/Services";
import Portfolio from "../components/Portfolio/Portfolio";
import About from "../components/About/About";
import Testimonials from "../components/Testimonials/Testimonials";
import Contact from "../components/Contact/Contact";

const HomePage = () => {
  return (
    <>
      <Navbar />
      <Hero />
     <Services />
      <Portfolio />
      <About />
      <Testimonials />
       <Contact /> 
    </>
  );
};

export default HomePage;