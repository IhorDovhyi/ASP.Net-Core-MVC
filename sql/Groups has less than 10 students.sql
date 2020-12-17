USE UNIVERSITY;

SELECT GROUPS.NAME AS 'GROUP', COUNT(STUDENTS.STUDENT_ID) AS 'STUDENTS'
FROM GROUPS
LEFT JOIN STUDENTS ON GROUPS.GROUP_ID = STUDENTS.GROUP_ID
GROUP BY GROUPS.NAME
HAVING COUNT(STUDENTS.STUDENT_ID) < 10