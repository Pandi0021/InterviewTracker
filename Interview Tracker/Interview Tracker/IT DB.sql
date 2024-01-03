-- Create a database
CREATE DATABASE InterviewTracker;
USE InterviewTracker;

-- Table for Candidates
CREATE TABLE Candidates (
    CandidateId INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100),
    Phone NVARCHAR(20),
    Resume NVARCHAR(MAX),
    LinkedInProfile NVARCHAR(100),
    CONSTRAINT CK_Email CHECK (Email LIKE '%_@%._%') -- Basic email format check
);

-- Table for Jobs
CREATE TABLE Jobs (
    JobId INT PRIMARY KEY IDENTITY(1,1),
    PositionTitle NVARCHAR(100),
    Company NVARCHAR(100),
    JobDescription NVARCHAR(MAX),
    ApplicationStatus NVARCHAR(50)
);

-- Table for Interviews
CREATE TABLE Interviews (
    InterviewId INT PRIMARY KEY IDENTITY(1,1),
    CandidateId INT FOREIGN KEY REFERENCES Candidates(CandidateId),
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
    InterviewDate DATETIME,
    InterviewType NVARCHAR(50),
    InterviewerName NVARCHAR(100),
    InterviewStatus NVARCHAR(50),
    FollowUpActions NVARCHAR(MAX),
    ThankYouNoteSent BIT,
    Notes NVARCHAR(MAX),
    CONSTRAINT CHK_InterviewStatus CHECK (InterviewStatus IN ('Scheduled', 'Completed', 'Pending Feedback'))
);
-- Insert sample data into Candidates table
INSERT INTO Candidates (FirstName, LastName, Email, Phone, Resume, LinkedInProfile)
VALUES
('John', 'Doe', 'john.doe@email.com', '123-456-7890', 'John Doe Resume Text', 'https://www.linkedin.com/in/johndoe/'),
('Jane', 'Smith', 'jane.smith@email.com', '987-654-3210', 'Jane Smith Resume Text', 'https://www.linkedin.com/in/janesmith/');

-- Insert sample data into Jobs table
INSERT INTO Jobs (PositionTitle, Company, JobDescription, ApplicationStatus)
VALUES
('Software Developer', 'ABC Corp', 'Description for Software Developer position', 'Open'),
('Data Analyst', 'XYZ Inc', 'Description for Data Analyst position', 'Closed');

-- Insert sample data into Interviews table
INSERT INTO Interviews (CandidateId, JobId, InterviewDate, InterviewType, InterviewerName, InterviewStatus, FollowUpActions, ThankYouNoteSent, Notes)
VALUES
(1, 1, '2023-01-15 10:00:00', 'Phone Interview', 'Interviewer1', 'Scheduled', 'Send additional materials', 0, 'Notes for the interview'),
(2, 2, '2023-01-20 14:30:00', 'In-person Interview', 'Interviewer2', 'Completed', 'Send follow-up email', 1, 'Additional notes for the interview');
