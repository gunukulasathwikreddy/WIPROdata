import axios from 'axios';
import React, { useState } from 'react';
import './RegisterPage.css';
import { useNavigate } from 'react-router-dom';

const RegisterPage = () => {
  const navigate = useNavigate();
  const [result, setResult] = useState('');
  const [data, setData] = useState({
    fullName: '',
    email: '',
    password: '',
    dateOfBirth: '',
    gender: '',
    address: '',
    phoneNumber: '',
    city: '',
    state: '',
    pincode: '',
    country: ''
  });

  const registerPage = () => {
    axios.post("http://localhost:5178/api/Users", data)
      .then(resp => {
        setResult("✅ " + resp.data + "\nRedirecting to Home in 5 seconds...");
        console.log(resp.data);

        setTimeout(() => {
          navigate("/");
        }, 5000);

      })
      .catch(err => {
        if (err.response && err.response.data) {
          const errors = err.response.data.errors
            ? Object.values(err.response.data.errors).flat().join("\n")
            : err.response.data;
          setResult(`❌ ${errors}`);
        } else {
          setResult("❌ Registration failed. Please try again.");
        }
        console.error(err);
      });
  };

  const handleChange = event => {
    setData({
      ...data,
      [event.target.name]: event.target.value
    });
  };

  // ✅ disable Register button until required fields are filled
  const isFormValid = () => {
    return (
      data.fullName.trim() &&
      data.email.trim() &&
      data.password.trim() &&
      data.dateOfBirth.trim() &&
      data.gender.trim() &&
      data.address.trim() &&
      data.phoneNumber.trim() &&
      data.state.trim() &&
      data.pincode.trim() &&
      data.country.trim()
    );
  };

  return (
    <div className="register-page">
    <div className="register-container">
      <h2 className="title">Register Account</h2>
      <p className="note">* fields are required to fill compulsorily</p>

      <label>Full Name <span className="required">*</span></label>
      <input type="text" name="fullName" value={data.fullName} onChange={handleChange} />

      <label>Email <span className="required">*</span></label>
      <input type="email" name="email" value={data.email} onChange={handleChange} />

      <label>Password <span className="required">*</span></label>
      <input type="password" name="password" value={data.password} onChange={handleChange} />

      <label>Date of Birth <span className="required">*</span></label>
      <input type="date" name="dateOfBirth" value={data.dateOfBirth} onChange={handleChange} />

      <label>Gender <span className="required">*</span></label>
      <select name="gender" value={data.gender} onChange={handleChange}>
        <option value="">-- Select --</option>
        <option value="Male">Male</option>
        <option value="Female">Female</option>
      </select>

      <label>Address <span className="required">*</span></label>
      <input type="text" name="address" value={data.address} onChange={handleChange} />

      <label>Phone Number <span className="required">*</span></label>
      <input type="text" name="phoneNumber" value={data.phoneNumber} onChange={handleChange} />

      <label>City</label>
      <input type="text" name="city" value={data.city} onChange={handleChange} />

      <label>State <span className="required">*</span></label>
      <input type="text" name="state" value={data.state} onChange={handleChange} />

      <label>Pincode <span className="required">*</span></label>
      <input type="text" name="pincode" value={data.pincode} onChange={handleChange} />

      <label>Country <span className="required">*</span></label>
      <input type="text" name="country" value={data.country} onChange={handleChange} />

      <button 
        className="register-btn" 
        onClick={registerPage} 
        disabled={!isFormValid()}
      >
        Register Account
      </button>

      <pre className="result">{result}</pre>
    </div>
    <div className="back-home">
          <button type="button" onClick={() => navigate("/")}>
            ⬅ Back to Home
          </button>
    </div>
  </div>
  );
};

export default RegisterPage;
