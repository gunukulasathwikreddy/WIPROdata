import React, { useState } from "react";
import "./ProjectsForm.css";

const ProjectsForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    projectName: "",
    description: "",
    technologiesUsed: "",
    link: "",
  });

  const handleChange = (e) => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData);
    onClose();
  };

  return (
    <form className="projects-form" onSubmit={handleSubmit}>
      <label>
        Project Name:
        <input
          type="text"
          name="projectName"
          value={formData.projectName}
          onChange={handleChange}
          required
        />
      </label>

      <label>
        Description:
        <textarea
          name="description"
          value={formData.description}
          onChange={handleChange}
        />
      </label>

      <label>
        Technologies Used:
        <input
          type="text"
          name="technologiesUsed"
          value={formData.technologiesUsed}
          onChange={handleChange}
        />
      </label>

      <label>
        Project Link:
        <input
          type="url"
          name="link"
          value={formData.link}
          onChange={handleChange}
        />
      </label>

      <div className="projects-form-actions">
        <button type="submit">Save</button>
        <button type="button" onClick={onClose}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default ProjectsForm;
