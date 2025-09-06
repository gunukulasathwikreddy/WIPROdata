import axios from "axios";
import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./TestPage.css";

const TestPage = () => {
  const [publicResult, setPublicResult] = useState("");
  const [secureResult, setSecureResult] = useState("");
  const navigate = useNavigate();

  // Non-protected API call
  const handlePublicCheck = async () => {
    try {
      const response = await axios.get("http://localhost:5178/api/test/public");
      setPublicResult(response.data.message || response.data);
    } catch (error) {
      console.error(error);
      setPublicResult("Error while calling public API.");
    }
  };

  // Protected API call
  const handleSecureCheck = async () => {
    const token = localStorage.getItem("jwtToken");

    if (!token) {
      alert("No token found. Please login first!");
      return;
    }

    try {
      const response = await axios.get("http://localhost:5178/api/test/secure", {
        headers: {
          Authorization: `${token}`, // Sending token directly (no "Bearer ")
        },
      });
      setSecureResult(response.data.message || response.data);
    } catch (error) {
      console.error(error);
      setSecureResult("Unauthorized! Token might be invalid or expired.");
    }
  };

  return (
    <div className="test-page">
      <h2>JWT Test Page</h2>

      {/* Public API */}
      <div className="test-section">
        <h3>Public API (No Auth Required)</h3>
        <button onClick={handlePublicCheck}>Check Public API</button>
        <p>Result: {publicResult}</p>
      </div>

      {/* Secure API */}
      <div className="test-section">
        <h3>Protected API (JWT Required)</h3>
        <button onClick={handleSecureCheck}>Check Secure API</button>
        <p>Result: {secureResult}</p>
      </div>

      <button className="back-btn" onClick={() => navigate(-1)}>
        ⬅ Back
      </button>
    </div>
  );
};

export default TestPage;
