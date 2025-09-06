import React, { useEffect, useState, useRef } from "react";
import { useParams } from "react-router-dom";
import api from "../services/api";
import jsPDF from "jspdf";
import html2canvas from "html2canvas";
import "./ResumePreviewPage.css";

const ResumePreviewPage = () => {
  const { resumeId } = useParams();
  const [resumeData, setResumeData] = useState(null);
  const [education, setEducation] = useState([]);
  const [skills, setSkills] = useState([]);
  const [experience, setExperience] = useState([]);
  const [projects, setProjects] = useState([]);
  const [certifications, setCertifications] = useState([]);
  const [achievements, setAchievements] = useState([]);
  const [loading, setLoading] = useState(true);
  const resumeRef = useRef(null);

  useEffect(() => {
    const fetchResume = async () => {
      try {
        const resumeRes = await api.get(`/api/Resume/${resumeId}`);
        const resume = resumeRes.data;

        if (!resume) {
          setLoading(false);
          return;
        }

        const userRes = await api.get(`/api/Users/${resume.userId}`);
        const eduRes = await api.get(`/api/Education/by-resume/${resumeId}`);
        const skillsRes = await api.get(`/api/Skill/by-resume/${resumeId}`);
        const expRes = await api.get(`/api/Experience/by-resume/${resumeId}`);
        const projectsRes = await api.get(`/api/Project/by-resume/${resumeId}`);
        const certsRes = await api.get(`/api/Certification/by-resume/${resumeId}`);
        const achievementsRes = await api.get(`/api/Achievement/by-resume/${resumeId}`);

        setResumeData({
          ...resume,
          user: userRes.data,
        });
        setEducation(eduRes.data || []);
        setSkills(skillsRes.data || []);
        setExperience(expRes.data || []); 
        setProjects(projectsRes.data || []);
        setCertifications(certsRes.data || []);
        setAchievements(achievementsRes.data || []);

        setLoading(false);
      } catch (err) {
        console.error("Error fetching resume preview:", err);
        setLoading(false);
      }
    };

    fetchResume();
  }, [resumeId]);

  

  const handleDownload = async () => {
  if (!resumeRef.current) return;

  const element = resumeRef.current;
  const canvas = await html2canvas(element, { scale: 2 });
  const imgData = canvas.toDataURL("image/png");

  const pdf = new jsPDF("p", "mm", "a4");
  const pdfWidth = pdf.internal.pageSize.getWidth();
  const pdfHeight = pdf.internal.pageSize.getHeight();

  const imgProps = pdf.getImageProperties(imgData);
  const imgHeight = (imgProps.height * pdfWidth) / imgProps.width;

  let heightLeft = imgHeight;
  let position = 0;

  // First page
  pdf.addImage(imgData, "PNG", 0, position, pdfWidth, imgHeight);
  heightLeft -= pdfHeight;

  // Add more pages if needed
  while (heightLeft > 0) {
    position = heightLeft - imgHeight;
    pdf.addPage();
    pdf.addImage(imgData, "PNG", 0, position, pdfWidth, imgHeight);
    heightLeft -= pdfHeight;
  }

  pdf.save(`${resumeData?.title || "resume"}.pdf`);
};


  if (loading) {
    return <div className="loading">Loading resume preview...</div>;
  }

  if (!resumeData) {
    return <div className="no-resume">No Resume Found</div>;
  }

  return (
    <div className="resume-page">

      <div className="download-btn-container top">
      <button className="download-btn" onClick={handleDownload}>
      Download Resume
      </button>
      </div>



      {/* Resume Preview Content */}
      <div className="resume-preview" ref={resumeRef}>
        <h1>{resumeData.title}</h1>
        <p className="objective">{resumeData.objective}</p>

        <h2>Personal Info</h2>
        <p><strong>Name:</strong> {resumeData.user?.fullName}</p>
        <p><strong>Date of Birth:</strong> 
        {resumeData.user?.dateOfBirth ? new Date(resumeData.user.dateOfBirth).toLocaleDateString() : "N/A"}</p>
        <p><strong>Gender:</strong> {resumeData.user?.gender || "N/A"}</p>
        <p><strong>Email:</strong> {resumeData.user?.email}</p>
        <p><strong>Phone:</strong> {resumeData.user?.phoneNumber}</p>
        <p><strong>Address:</strong> {resumeData.user?.address}</p>
        <p><strong>Pincode:</strong> {resumeData.user?.pincode || "N/A"}</p>
        <p><strong>Country:</strong> {resumeData.user?.country || "N/A"}</p>
        

        <h2>Education</h2>
        {education.length > 0 ? (
          <ul>
            {education.map((edu) => (
              <li key={edu.educationId} className="education-item">
                <strong>{edu.degree}</strong> in {edu.fieldOfStudy} <br />
                {edu.institutionName}, {edu.universityOrBoard} <br />
                {edu.startDate ? new Date(edu.startDate).toLocaleDateString() : ""} –{" "}
                {edu.endDate ? new Date(edu.endDate).toLocaleDateString() : "Present"} <br />
                <em>Score: {edu.percentageOrCGPA}</em>
              </li>
            ))}
          </ul>
        ) : (
          <p>No education details</p>
        )}


        <h2>Skills</h2>
        {skills.length > 0 ? (
        <ul>
        {skills.map((skill) => (
        < li key={skill.skillId} className="skill-item">
        {skill.skillName} <span>{skill.proficiencyLevel}</span>
        </li>
        ))}
        </ul>
        ) : (
        <p>No skills</p>
        )}



        <h2>Experience</h2>
        {experience.length > 0 ? (
          <ul>
            {experience.map((exp) => (
              <li key={exp.experienceId} className="experience-item">
                <strong>{exp.jobTitle}</strong> at {exp.company} <br />
                {exp.startDate ? new Date(exp.startDate).toLocaleDateString() : ""} –{" "}
                {exp.endDate ? new Date(exp.endDate).toLocaleDateString() : "Present"} <br />
                <em>{exp.description}</em>
              </li>
            ))}
          </ul>
        ) : (
          <p>No experience details</p>
        )}

        <h2>Projects</h2>
        {projects.length > 0 ? (
          <ul>
            {projects.map((proj) => (
              <li key={proj.projectId} className="project-item">
                <strong>{proj.projectName}</strong> <br />
                Description : <em>{proj.description}</em> <br/>
                Technologies Used : <em>{proj.technologiesUsed}</em> <br/>
                Project Link : <em>{proj.link}</em>
              </li>
            ))}
          </ul>
        ) : (
          <p>No projects</p>
        )}

        <h2>Certifications</h2>
        {certifications.length > 0 ? (
          <ul>
            {certifications.map((cert) => (
              <li key={cert.certificationId} className="certification-item">
                <strong>{cert.certificateName}</strong> - {cert.issuedBy} <br />
                Issued: {cert.issueDate ? new Date(cert.issueDate).toLocaleDateString() : "N/A"} <br />
                {cert.expiryDate ? `Valid Till: ${new Date(cert.expiryDate).toLocaleDateString()}` : "No Expiry"} <br/>
                Credential Link : <em>{cert.credentialUrl}</em>
              </li>
            ))}
          </ul>
        ) : (
          <p>No certifications</p>
        )}


        <h2>Achievements</h2>
        {achievements.length > 0 ? (
          <ul>
            {achievements.map((ach) => (
              <li key={ach.achievementId} className="achievement-item">
                <strong>{ach.title}</strong> <br />
                Description : <em>{ach.description}</em> <br/>
                {ach.dateAchieved ? (
                <span>Date Achieved: {new Date(ach.dateAchieved).toLocaleDateString()}</span>
                ) : (
                <span>Date Achieved: N/A</span>
                )}
              </li>
            ))}
          </ul>
        ) : (
          <p>No achievements</p>
        )}



      </div>

      

    </div>
  );
};

export default ResumePreviewPage;