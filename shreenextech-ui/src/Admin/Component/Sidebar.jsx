// src/admin/components/Sidebar.jsx
import { Link } from "react-router-dom";

export default function Sidebar() {
  return (
    <div style={{ width: "200px", background: "#222", color: "#fff", height: "100vh", padding: "20px" }}>
      <h3>Admin</h3>
      <ul style={{ listStyle: "none", padding: 0 }}>
        <li><Link to="/admin" style={{ color: "#fff" }}>Dashboard</Link></li>
        <li><Link to="/admin/services" style={{ color: "#fff" }}>Services</Link></li>
        <li><Link to="/admin/portfolio" style={{ color: "#fff" }}>Portfolio</Link></li>
        <li><Link to="/admin/contact" style={{ color: "#fff" }}>Contact</Link></li>
      </ul>
    </div>
  );
}