import React, { useEffect, useState } from "react";
import Modal from "../components/Modal";
import { Link, useNavigate } from "react-router-dom";
import api from "../services/api";
import "./UserPage.css";

const UserPage = () => {
  const navigate = useNavigate();
  const [user, setUser] = useState(null);
  const [menuOpen, setMenuOpen] = useState(false);
  const [resumes, setResumes] = useState([]);

  const [loading, setLoading] = useState(false);

  const [aiSuggestions, setAiSuggestions] = useState([]);
  const [showSuggestions, setShowSuggestions] = useState(false);

  // key → label mapping
  const fieldLabels = {
    userId: "User ID",
    name: "Name",
    email: "Email",
    phone: "Phone Number",
    address: "Address",
    dateOfBirth: "Date of Birth",
    createdAt: "Account Created",
    updatedAt: "Last Updated",
  };

  // fields to hide (like password)
  const hiddenFields = ["password", "confirmPassword"];

  // format dates nicely
  const formatValue = (key, value) => {
    if ((key === "createdAt" || key === "updatedAt" || key === "dateOfBirth") && value) {
      return new Date(value).toLocaleString("en-US", {
        year: "numeric",
        month: "short",
        day: "numeric",
      });
    }
    return value;
  };

  const fetchResumes = (userId) => {
  console.log("Fetching resumes for userId:", userId); // 🟢 debug log
  api
    .get(`/api/Resume/user/${userId}`)
    .then((res) => {
      console.log("Fetched resumes:", res.data); // 🟢 see response
      setResumes(res.data);
    })
    .catch((err) => console.error("Failed to fetch resumes", err));
};

useEffect(() => {
  const email = localStorage.getItem("userEmail");
  if (!email) {
    navigate("/login");
    return;
  }

  api
    .get("http://localhost:5178/api/Users/ByEmail/" + email)
    .then((res) => {
      console.log("Fetched user:", res.data); // 🟢 debug log
      setUser(res.data);

      // Store userId in localStorage
      if (res.data && res.data.userId) {
        localStorage.setItem("userId", res.data.userId);

        fetchResumes(res.data.userId);
      }
    })
    .catch((err) => {
      console.error(err);
      localStorage.removeItem("jwtToken");
      localStorage.removeItem("userEmail");
      localStorage.removeItem("userId"); // cleanup if failed

      alert("Failed to fetch user details.");
      navigate("/login");
    });
}, [navigate]);


  

  const handleDelete = (resumeId) => {
    if (!window.confirm("Delete this resume?")) return;
    api
      .delete(`/api/Resume/${resumeId}`)
      .then(() => {
        setResumes((prev) => prev.filter((r) => r.resumeId !== resumeId));
      })
      .catch(() => alert("Failed to delete resume"));
  };

  const handlePostAI = async (resumeId) => {
  try {
    setLoading(true);
    await api.post(`/api/AISuggestions/generate/${resumeId}`);
    alert("✅ AI Suggestions Posted successfully!");
  } catch (err) {
    console.error("Error posting AI suggestions:", err.response?.data || err.message);
    alert("❌ Failed to post AI Suggestions: " + (err.response?.data || err.message));
  } finally {
    setLoading(false);
  }
};



  const handleAISuggestion = (resumeId) => {
  const url = `/api/AISuggestions/resume/${resumeId}`; // ✅ corrected URL
  console.log("🔎 Fetching AI suggestions from:", url);

  api
    .get(url)
    .then((res) => {
      setAiSuggestions(res.data);
      setShowSuggestions(true);
    })
    .catch((err) => {
      console.error("❌ AI Suggestion fetch failed:", err.response || err.message);
      alert("Failed to fetch AI suggestions. Status: " + (err.response?.status || "Unknown"));
    });
};



  const handleLogout = () => {
    localStorage.removeItem("jwtToken");
    localStorage.removeItem("userEmail");
    localStorage.removeItem("userId");
    
    alert("You have been logged out!");
    navigate("/login");
  };

  return (
    <div className="user-page">
      {/* Header with Hamburger */}
      <header className="user-header">
        <h1>Welcome {user ? user.name : "User"}</h1>
        <div
          className={`hamburger ${menuOpen ? "open" : ""}`}
          onClick={() => setMenuOpen(!menuOpen)}
        >
          <span></span>
          <span></span>
          <span></span>
        </div>
      </header>

      {/* Sidebar Menu */}
      <div className={`side-menu ${menuOpen ? "show" : ""}`}>
        {user && (
          <div className="profile-card">
            <h2>User Profile</h2>
            <ul className="user-details">
              {Object.entries(user)
                .filter(([key]) => !hiddenFields.includes(key.toLowerCase())) // skip hidden
                .map(([key, value]) => (
                  <li key={key}>
                    <strong>{fieldLabels[key] || key}:</strong>{" "}
                    {formatValue(key, value)}
                  </li>
                ))}
            </ul>
            <div className="menu-actions">

              <button
                className="logout-btn"
                onClick={() => {
                  handleLogout();
                  setMenuOpen(false);
                }}
              >
                Logout
              </button>
              <button
                className="close-btn"
                onClick={() => setMenuOpen(false)}
              >
                ❌ Close
              </button>
            </div>
          </div>
        )}
      </div>

      {/* Main Content */}
      <main className="user-content">

        <p className="welcome-text">This is your user dashboard 🚀</p>
        <br/>


        <Link to="/resumebuilder" className="create-resume-link">
        ➕ Create New Resume
        </Link>
        <br />

        <div className="resume-list">
        <h2>Your Resumes</h2>
        {resumes.length === 0 ? (
        <p>No resumes found. Create one using +Create Resume Link above</p>
        ) : (
       <ul>
        {resumes.map((resume) => (
        <li key={resume.resumeId} className="resume-item">
          <span>{resume.title || `Resume #${resume.resumeId}`}</span>
          <div className="actions">
            <button onClick={() => navigate(`/preview/${resume.resumeId}`)}>
             Preview
            </button>

            <button className="post-ai-btn" onClick={() => handlePostAI(resume.resumeId)} disabled={loading}>
            {loading ? "Posting..." : "Post AI"}
            </button>

            <button onClick={() => handleAISuggestion(resume.resumeId)}>AISuggestion</button>


            <button 
            onClick={() => handleDelete(resume.resumeId)} 
            style={{ backgroundColor: "red", color: "white", padding: "6px 12px", border: "none", borderRadius: "4px" }}
            >
            Delete
            </button>

          </div>
        </li>
        ))}
      </ul>
       )}
      </div>

      <div className="test-btn-container">
      <Link to="/test">
          <button className="test-btn">Go to Test Page</button>
      </Link>
      </div>

            

      </main>

      <Modal
  title="AI Suggestions"
  open={showSuggestions}
  onClose={() => setShowSuggestions(false)}
>
  {aiSuggestions.length === 0 ? (
    <p>No suggestions available</p>
  ) : (
    <ul>
      {aiSuggestions.map((s) => (
        <li key={s.suggestionId}>
          <strong>{s.section}:</strong> {s.suggestedText}
        </li>
      ))}
    </ul>
  )}
</Modal>




    </div>
  );
};

export default UserPage;