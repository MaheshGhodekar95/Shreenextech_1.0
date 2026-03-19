// src/admin/pages/PortfolioAdmin.jsx
export default function PortfolioAdmin() {
  return (
    <div>
      <h2>Portfolio</h2>

      <button>Add Project</button>

      <table border="1" cellPadding="10" style={{ marginTop: "10px" }}>
        <thead>
          <tr>
            <th>Project</th>
            <th>Description</th>
            <th>Actions</th>
          </tr>
        </thead>

        <tbody>
          <tr>
            <td>Company Website</td>
            <td>React + .NET</td>
            <td>
              <button>Edit</button>
              <button>Delete</button>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}