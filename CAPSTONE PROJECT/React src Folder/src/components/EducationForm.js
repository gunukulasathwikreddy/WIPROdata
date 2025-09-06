import React, { useState } from "react";
import "./EducationForm.css";

const EducationForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    institutionName: "",
    universityOrBoard: "",
    degree: "",
    fieldOfStudy: "",
    startDate: "",
    endDate: "",
    percentageOrCGPA: "",
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
    <form onSubmit={handleSubmit} className="form-container">
      <div className="form-group">
        <label>Institution Name</label>
        <input
          type="text"
          name="institutionName"
          value={formData.institutionName}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <label>University / Board</label>
        <input
          type="text"
          name="universityOrBoard"
          value={formData.universityOrBoard}
          onChange={handleChange}
          required
        />
      </div>

      <div className="form-group">
        <label>Degree</label>
        <input
          type="text"
          name="degree"
          value={formData.degree}
          onChange={handleChange}
        />
      </div>

      <div className="form-group">
        <label>Field of Study</label>
        <input
          type="text"
          name="fieldOfStudy"
          value={formData.fieldOfStudy}
          onChange={handleChange}
        />
      </div>

      <div className="form-row">
        <div className="form-group">
          <label>Start Date</label>
          <input
            type="date"
            name="startDate"
            value={formData.startDate}
            onChange={handleChange}
            required
          />
        </div>

        <div className="form-group">
          <label>End Date</label>
          <input
            type="date"
            name="endDate"
            value={formData.endDate}
            onChange={handleChange}
          />
        </div>
      </div>

      <div className="form-group">
        <label>Percentage / CGPA</label>
        <input
          type="text"
          name="percentageOrCGPA"
          value={formData.percentageOrCGPA}
          onChange={handleChange}
        />
      </div>

      <div className="form-actions">
        <button type="submit" className="btn-primary">Save</button>
        <button type="button" className="btn-secondary" onClick={onClose}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default EducationForm;