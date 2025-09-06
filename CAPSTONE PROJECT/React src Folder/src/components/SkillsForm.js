import React, { useState } from "react";
import "./SkillsForm.css";

const SkillsForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    skillName: "",
    proficiencyLevel: "",
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
    <form className="skills-form" onSubmit={handleSubmit}>
      <label>
        Skill Name:
        <input
          type="text"
          name="skillName"
          value={formData.skillName}
          onChange={handleChange}
          required
        />
      </label>

      <label>
        Proficiency Level:
        <select
          name="proficiencyLevel"
          value={formData.proficiencyLevel}
          onChange={handleChange}
          required
        >
          <option value="">Select Level</option>
          <option value="Beginner">Beginner</option>
          <option value="Intermediate">Intermediate</option>
          <option value="Advanced">Advanced</option>
          <option value="Expert">Expert</option>
        </select>
      </label>

      <div className="skills-form-actions">
        <button type="submit">Save</button>
        <button type="button" onClick={onClose}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default SkillsForm;
