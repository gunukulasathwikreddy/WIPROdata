import React, { useState } from "react";
import "./ResumeForm.css";

const ResumeForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    title: "",
    objective: "",
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    onSubmit(formData); // ✅ always create
    onClose();
  };

  return (
    <form className="resume-form" onSubmit={handleSubmit}>
      <label>Title</label>
      <input
        type="text"
        name="title"
        value={formData.title}
        onChange={handleChange}
        required
      />

      <label>Objective</label>
      <textarea
        name="objective"
        value={formData.objective}
        onChange={handleChange}
        rows="4"
        required
      />

      <div className="form-actions">
        <button type="submit">Save</button>
        <button type="button" onClick={onClose} className="cancel-btn">
          Cancel
        </button>
      </div>
    </form>
  );
};

export default ResumeForm;
