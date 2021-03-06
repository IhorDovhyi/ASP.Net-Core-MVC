CREATE DATABASE UNIVERSITY;
GO

USE UNIVERSITY;
CREATE TABLE COURSES 
(
COURSE_ID INT PRIMARY KEY IDENTITY(1,1), 
NAME NVARCHAR(20) NOT NULL UNIQUE,
DESCRIPTION NVARCHAR(200) NOT NULL
);

CREATE TABLE GROUPS
(
GROUP_ID INT PRIMARY KEY IDENTITY(1,1), 
COURSE_ID INT NOT NULL,
NAME NVARCHAR(20) NOT NULL UNIQUE
CONSTRAINT FK_GROUPS_To_COURSES 
FOREIGN KEY (COURSE_ID) REFERENCES COURSES (COURSE_ID) ON DELETE CASCADE
);

CREATE TABLE STUDENTS 
(
STUDENT_ID INT PRIMARY KEY IDENTITY(1,1), 
GROUP_ID INT, 
FIRST_NAME NVARCHAR(20) NOT NULL,
LAST_NAME NVARCHAR(40) NOT NULL,
CONSTRAINT FK_STUDENTS_To_GROUPS
FOREIGN KEY (GROUP_ID) REFERENCES GROUPS (GROUP_ID) ON DELETE CASCADE
);
