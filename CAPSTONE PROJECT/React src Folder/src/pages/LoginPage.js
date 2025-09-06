import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import api from '../services/api';  //use central axios instance
import './LoginPage.css';

const LoginPage = () => {
  const navigate = useNavigate();
  const [data, setData] = useState({
    Email: '',
    Password: ''
  });

  // On mount, check if token exists
  useEffect(() => {
    const token = localStorage.getItem("jwtToken");
    if (token) {
      // Verify with backend
      api.get("http://localhost:5178/api/Auth/ValidateToken")
        .then(() => {
          // Valid token → skip login page
          navigate("/user");
        })
        .catch(() => {
          // Invalid/expired token → remove it and force back to login
          localStorage.removeItem("jwtToken");
          localStorage.removeItem("userEmail");
          localStorage.removeItem("userId");
          navigate("/login");  // redirect immediately
        });
    }
  }, [navigate]);

  const handleChange = (event) => {
    setData({
      ...data,
      [event.target.name]: event.target.value
    });
  };

  const handleSubmit = async () => {
    let user = data.Email;
    let pwd = data.Password;

    try {
      const response = await api.get("http://localhost:5178/Login/" + user + "/" + pwd);

      if (response.data.token) {
        localStorage.setItem("jwtToken", response.data.token);
        localStorage.setItem("userEmail", user);
        alert("Login successful!");
        alert("Your Token : "+response.data.token);
        alert("This is stored in local storage and used when protected operations are to be done!...");
        navigate("/user");
      }
    } catch (error) {
      console.error(error);
      alert("Invalid Credentials... Please Enter Your Login Details Correctly.");
    }
  };

  return (
    <div className="login-page">
      <div className="login-container">
        <h2>Login Page</h2>
        <form>
          <label>Email : </label>
          <input
            type="email"
            name="Email"
            onChange={handleChange}
            value={data.Email}
          /> <br /><br />

          <label>Password : </label>
          <input
            type="password"
            name="Password"
            onChange={handleChange}
            value={data.Password}
          /> <br /><br />

          <input type="button" value="Login" onClick={handleSubmit} />
        </form>
      </div>
      <div className="back-home-container">
        <button type="button" onClick={() => navigate("/")}>
          ⬅ Back to Home
        </button>
      </div>
    </div>
  );
};

export default LoginPage;
