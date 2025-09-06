create database AIResume
Go

use AIResume
Go

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender VARCHAR(10) NOT NULL CONSTRAINT chk_user_gender CHECK (UPPER(Gender) IN ('MALE', 'FEMALE')),
    Address NVARCHAR(255) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    City NVARCHAR(100) NULL,
    State NVARCHAR(100) NOT NULL,
    Pincode NVARCHAR(10) NOT NULL,
    Country NVARCHAR(50) NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
);
GO

-- ========================
-- Resume Table
-- ========================
CREATE TABLE Resumes (
    ResumeId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Objective NVARCHAR(MAX),  -- Resume summary/objective
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId) ON DELETE CASCADE
);
Go

-- ========================
-- Education Table
-- ========================
CREATE TABLE Education (
    EducationId INT PRIMARY KEY IDENTITY(1,1),
    ResumeId INT NOT NULL,
    InstitutionName NVARCHAR(200) NOT NULL,
    Degree NVARCHAR(100) NOT NULL,
    FieldOfStudy NVARCHAR(150) NOT NULL,  
    PercentageOrCGPA DECIMAL(5,2) NOT NULL,
    UniversityOrBoard NVARCHAR(150) NOT NULL, 
    StartDate DATE NOT NULL,
    EndDate DATE,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);
Go

-- ========================
-- Experience Table
-- ========================
CREATE TABLE Experience (
    ExperienceId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    JobTitle NVARCHAR(200) NOT NULL,
    Company NVARCHAR(250) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE,
    Description NVARCHAR(MAX),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);
Go

-- ========================
-- Skills Table
-- ========================
CREATE TABLE Skills (
    SkillId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    SkillName NVARCHAR(150) NOT NULL,
    ProficiencyLevel NVARCHAR(50),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);

-- ========================
-- Projects Table
-- ========================
CREATE TABLE Projects (
    ProjectId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    ProjectName NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    TechnologiesUsed NVARCHAR(500),
    Link NVARCHAR(500),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);

-- ========================
-- Certifications Table
-- ========================
CREATE TABLE Certifications (
    CertificationId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    CertificateName NVARCHAR(200) NOT NULL,
    IssuedBy NVARCHAR(200),
    IssueDate DATE,
    ExpiryDate DATE,
    CredentialUrl NVARCHAR(500),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);

-- ========================
-- Achievements Table
-- ========================
CREATE TABLE Achievements (
    AchievementId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    DateAchieved DATE,
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);

-- ========================
-- AI Suggestions Table
-- ========================
CREATE TABLE AISuggestions (
    SuggestionId INT IDENTITY(1,1) PRIMARY KEY,
    ResumeId INT NOT NULL,
    Section NVARCHAR(100) NOT NULL, 
    SuggestedText NVARCHAR(MAX) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(ResumeId) ON DELETE CASCADE
);
