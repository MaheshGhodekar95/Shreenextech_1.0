import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Services from "./Pages/Services";
import HomePage from "./Pages/HomePage";
import About from "./Pages/About/About";
import Contact from "./Pages/Contact/Contact";
import Portfolio from "./Pages/Portfolio/Portfolio";
import StartProject from "./Pages/Startproject/StartProject";
import WebDevelopment from "./Pages/Services/WebDevelopment";
import MobileApps from "./Pages/Services/MobileApps";
import CloudSolutions from "./Pages/Services/CloudSolutions";
import AdminLayout from "./Admin/Component/AdminLayout";
import Dashboard from "./Admin/Pages/Dashboard";
import ServicesAdmin from "./Admin/Pages/ServicesAdmin";
import PortfolioAdmin from "./Admin/Pages/PortfolioAdmin";
import ContactAdmin from "./Admin/Pages/ContactAdmin";




function App() {
  return (
    <BrowserRouter>

      <Routes>

        <Route path="/" element={<HomePage />} />

        <Route path="/start-project" element={<StartProject />} />
        <Route path="/services" element={<Services />} />
        <Route path="/About" element={<About />} />
        <Route path="/Contact" element={<Contact />} />
        <Route path="/Portfolio" element={<Portfolio />} />
        <Route path="/services/web-development" element={<WebDevelopment />} />
        <Route path="/services/mobile-apps" element={<MobileApps />} />
        <Route path="/services/cloud-solutions" element={<CloudSolutions />} />
        <Route path="/admin" element={<AdminLayout><Dashboard /></AdminLayout>} />
        <Route path="/admin/services" element={<AdminLayout><ServicesAdmin /></AdminLayout>} />
        <Route path="/admin/portfolio" element={<AdminLayout><PortfolioAdmin /></AdminLayout>} />
        <Route path="/admin/contact" element={<AdminLayout><ContactAdmin /></AdminLayout>} />

      </Routes>
      
    </BrowserRouter>
    
  );
}

export default App;