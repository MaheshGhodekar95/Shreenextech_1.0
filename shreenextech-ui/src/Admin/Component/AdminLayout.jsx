// src/admin/AdminLayout.jsx
import Sidebar from "./Sidebar";
import Header from "./Header";

export default function AdminLayout({ children }) {
  return (
    <div style={{ display: "flex" }}>
      <Sidebar />
      <div style={{ flex: 1 }}>
        <Header />
        <div style={{ padding: "20px" }}>
          {children}
        </div>
      </div>
    </div>
  );
}