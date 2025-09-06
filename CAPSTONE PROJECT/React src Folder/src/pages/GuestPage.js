import React from "react";
import { Link, useNavigate } from "react-router-dom";
import "./GuestPage.css";

const GuestPage = () => {
  const navigate = useNavigate();

  return (
    <div className="guest-container">
      <h2>Welcome Guest</h2>
      <p>You can explore the application features here.</p>
      <Link to="/test">
        <button className="guest-btn">Go to Test Page</button>
      </Link>
      <br/>
      <Link to="/resumebuilder">
        <button className="guest-btn">Go to Resume Page</button>
      </Link>
      <div className="back-button">
          <button type="button" onClick={() => navigate("/")}>
            ⬅ Back to Home
          </button>
    </div>
    </div>
  );
};

export default GuestPage;

