import React, { useState } from "react";
import "./CertificationsForm.css";

const CertificationsForm = ({ onSubmit, onClose }) => {
  const [formData, setFormData] = useState({
    certificateName: "",
    issuedBy: "",
    issueDate: "",
    expiryDate: "",
    credentialUrl: "",
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
    <form className="certifications-form" onSubmit={handleSubmit}>
      <label>
        Certificate Name:
        <input
          type="text"
          name="certificateName"
          value={formData.certificateName}
          onChange={handleChange}
          required
        />
      </label>

      <label>
        Issued By:
        <input
          type="text"
          name="issuedBy"
          value={formData.issuedBy}
          onChange={handleChange}
        />
      </label>

      <label>
        Issue Date:
        <input
          type="date"
          name="issueDate"
          value={formData.issueDate}
          onChange={handleChange}
        />
      </label>

      <label>
        Expiry Date:
        <input
          type="date"
          name="expiryDate"
          value={formData.expiryDate}
          onChange={handleChange}
        />
      </label>

      <label>
        Credential URL:
        <input
          type="url"
          name="credentialUrl"
          value={formData.credentialUrl}
          onChange={handleChange}
        />
      </label>

      <div className="certifications-form-actions">
        <button type="submit">Save</button>
        <button type="button" onClick={onClose}>
          Cancel
        </button>
      </div>
    </form>
  );
};

export default CertificationsForm;
