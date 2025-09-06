import React, { useState } from "react";
import "./AchievementsForm.css";

const AchievementsForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    title: "",
    description: "",
    dateAchieved: "",
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
    <form className="achievements-form" onSubmit={handleSubmit}>
      <label>
        Title:
        <input
          type="text"
          name="title"
          value={formData.title}
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
        Date Achieved:
        <input
          type="date"
          name="dateAchieved"
          value={formData.dateAchieved}
          onChange={handleChange}
        />
      </label>

      <div className="achievements-form-actions">
        <button type="submit">Save</button>
        <button type="button" onClick={onClose}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default AchievementsForm;
