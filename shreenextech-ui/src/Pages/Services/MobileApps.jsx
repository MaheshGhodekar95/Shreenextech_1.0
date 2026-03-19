import React from "react";
import "./MobileApps.css";

const MobileApps = () => {
  return (
    <div className="mobile-page">

      <h1>Mobile App Development</h1>

      <p className="mobile-intro">
        We create high-performance mobile applications that provide seamless
        user experiences across Android and iOS platforms.
      </p>

      <h2>Our Mobile Services</h2>

      <ul className="mobile-list">
        <li>Android App Development</li>
        <li>iOS App Development</li>
        <li>Cross Platform Apps</li>
        <li>UI/UX Design for Mobile</li>
        <li>App Maintenance & Updates</li>
      </ul>

      <h2>Technologies We Use</h2>

      <p className="mobile-tech">
        React Native, Flutter, Kotlin, Swift, Firebase, REST APIs.
      </p>

    </div>
  );
};

export default MobileApps;