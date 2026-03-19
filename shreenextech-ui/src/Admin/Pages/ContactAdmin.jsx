// src/admin/pages/ContactAdmin.jsx
export default function ContactAdmin() {
  return (
    <div>
      <h2>Contact Messages</h2>

      <table border="1" cellPadding="10">
        <thead>
          <tr>
            <th>Name</th>
            <th>Email</th>
            <th>Message</th>
          </tr>
        </thead>

        <tbody>
          <tr>
            <td>Mahesh</td>
            <td>test@mail.com</td>
            <td>Hello, I need service</td>
          </tr>
        </tbody>
      </table>
    </div>
  );
}