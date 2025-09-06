import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import './HomePage.css';

const HomePage = () => {
  localStorage.clear();
  const [showNav, setShowNav] = useState(false);
  useEffect(() => {
    const timer = setTimeout(() => {
      setShowNav(true);
    }, 7000);
    return () => clearTimeout(timer);
  }, []);

  return (
    <div className="home-container">
      <header className="hero-section">
        <h1 className="animated-text">Welcome to AI Resume Builder</h1>
        <p className="fade-in">Create Resumes Effectively.</p>

        {showNav && (
          <div className="nav-section">
            <Link to="/login" className="nav-card zoom-in">Login</Link>
            <Link to="/register" className="nav-card zoom-in delay-1">Register</Link>
            <Link to="/guest" className="nav-card zoom-in delay-2">Guest</Link>
          </div>
        )}
      </header>
    </div>
  );
};

export default HomePage;

