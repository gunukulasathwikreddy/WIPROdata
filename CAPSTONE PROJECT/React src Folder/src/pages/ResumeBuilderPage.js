import React, { useState } from "react";
import api from "../services/api";
import Modal from "../components/Modal";
import ResumeForm from "../components/ResumeForm";
import EducationForm from "../components/EducationForm";
import SkillsForm from "../components/SkillsForm";
import ExperienceForm from "../components/ExperienceForm";
import ProjectsForm from "../components/ProjectsForm";
import CertificationsForm from "../components/CertificationsForm";
import AchievementsForm from "../components/AchievementsForm";

import "./ResumeBuilderPage.css";

const ResumeBuilderPage = () => {
  const [resume, setResume] = useState(null);
  const [activeModal, setActiveModal] = useState(null);

  const token = localStorage.getItem("jwtToken");
  const userId = localStorage.getItem("userId");

  
  const checkLogin = () => {
    if (!token || !userId) {
      alert("Please login first");
      return false;
    }
    return true;
  };

  
  const handleCreateResume = async (resumeData) => {
    if (!checkLogin()) return;
    try {
      const res = await api.post(
        "/api/Resume",
        { ...resumeData, userId: Number(userId) },
        { headers: { Authorization: token } } 
      );
      setResume(res.data);
      alert("Title & Objective Added successfully!, Now Add other Sections...");
    } catch (err) {
      console.error(err);
      alert("Failed to create resume");
    }
  };

  
  const handleAddEducation = async (eduData) => {
  if (!checkLogin() || !resume) return;

  try {
    await api.post(
      "/api/Education",
      { ...eduData, resumeId: resume.resumeId },
      { headers: { Authorization: `${token}` } }
    );
    alert("Education added successfully!");
  } catch (err) {
    console.error("Education error:", err.response?.data || err.message);
    alert("Failed to add education");
  }
};

const handleAddSkill = async (skillData) => {
    if (!checkLogin() || !resume) return;
    try {
      await api.post(
        "/api/Skill",
        { ...skillData, resumeId: resume.resumeId },
        { headers: { Authorization: `${token}` } }
      );
      alert("Skill added successfully!");
    } catch (err) {
      console.error("Skill error:", err.response?.data || err.message);
      alert("Failed to add skill");
    }
  };

  const handleAddExperience = async (expData) => {
    if (!checkLogin() || !resume) return;
    try {
      await api.post(
        "/api/Experience",
        { ...expData, resumeId: resume.resumeId },
        { headers: { Authorization: `${token}` } }
      );
      alert("Experience added successfully!");
    } catch (err) {
      console.error("Experience error:", err.response?.data || err.message);
      alert("Failed to add experience");
    }
  };

  const handleAddProject = async (projData) => {
  if (!checkLogin() || !resume) return;
  try {
    await api.post(
      "/api/Project",
      { ...projData, resumeId: resume.resumeId },
      { headers: { Authorization: `${token}` } }
    );
    alert("Project added successfully!");
  } catch (err) {
    console.error("Project error:", err.response?.data || err.message);
    alert("Failed to add project");
  }
};

const handleAddCertification = async (certData) => {
  if (!checkLogin() || !resume) return;
  try {
    await api.post(
      "/api/Certification",
      { ...certData, resumeId: resume.resumeId },
      { headers: { Authorization: `${token}` } }
    );
    alert("Certification added successfully!");
  } catch (err) {
    console.error("Certification error:", err.response?.data || err.message);
    alert("Failed to add certification");
  }
};

const handleAddAchievement = async (achData) => {
  if (!checkLogin() || !resume) return;
  try {
    await api.post(
      "/api/Achievement",
      { ...achData, resumeId: resume.resumeId },
      { headers: { Authorization: `${token}` } }
    );
    alert("Achievement added successfully!");
  } catch (err) {
    console.error("Achievement error:", err.response?.data || err.message);
    alert("Failed to add achievement");
  }
};


  return (
    <div className="resume-builder">
      <h2>Resume Builder</h2>

      {/* Buttons always visible */}
      <div className="section-buttons">
        <button onClick={() => setActiveModal("resume")}>
          Add Title & Objective
        </button>
        <button onClick={() => setActiveModal("education")}>Add Education</button>
        <button onClick={() => setActiveModal("skills")}>Add Skills</button> 
        <button onClick={() => setActiveModal("experience")}>Add Experience</button>
        <button onClick={() => setActiveModal("projects")}>Add Projects</button>
        <button onClick={() => setActiveModal("certifications")}>Add Certifications</button>
        <button onClick={() => setActiveModal("achievements")}>Add Achievements</button>
      </div>

      {/* Modal */}
      <Modal
        title="Add Title & Objective"
        open={activeModal === "resume"}
        onClose={() => setActiveModal(null)}
      >
        <ResumeForm
          onSubmit={handleCreateResume}
          onClose={() => setActiveModal(null)}
        />
      </Modal>

      {/* Modal */}
      <Modal
        title="Add Education"
        open={activeModal === "education"}
        onClose={() => setActiveModal(null)}
      >
        <EducationForm
          onSubmit={handleAddEducation}
          onClose={() => setActiveModal(null)}
        />
      </Modal>

      <Modal
        title="Add Skill"
        open={activeModal === "skills"}
        onClose={() => setActiveModal(null)}
      >
        <SkillsForm
          onSubmit={handleAddSkill}
          onClose={() => setActiveModal(null)}
        />
      </Modal>

      <Modal
        title="Add Experience"
        open={activeModal === "experience"}
        onClose={() => setActiveModal(null)}
      >
        <ExperienceForm
          onSubmit={handleAddExperience}
          onClose={() => setActiveModal(null)}
        />
      </Modal>

      <Modal
      title="Add Project"
      open={activeModal === "projects"}
      onClose={() => setActiveModal(null)}
      >
        <ProjectsForm
        onSubmit={handleAddProject}
        onClose={() => setActiveModal(null)}
      />
    </Modal>

    <Modal
    title="Add Certification"
    open={activeModal === "certifications"}
    onClose={() => setActiveModal(null)}
    >
    <CertificationsForm
    onSubmit={handleAddCertification}
    onClose={() => setActiveModal(null)}
    />
  </Modal>

  <Modal
  title="Add Achievement"
  open={activeModal === "achievements"}
  onClose={() => setActiveModal(null)}
  >
  <AchievementsForm
    onSubmit={handleAddAchievement}
    onClose={() => setActiveModal(null)}
    />
  </Modal>


    </div>
  );
};

export default ResumeBuilderPage;
