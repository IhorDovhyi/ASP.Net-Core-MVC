using System;
using System.Collections.Generic;
using University.Controllers;
using University.Models;
using Xunit;

namespace University.Test
{
    public class HomeControllerTests
    {
        public TestDB testDB = new TestDB();

        [Fact]
        public void TestMethodIndex_AllCoursesExpected()
        {
            // Arrange
            var testRepository = new TestRepository<Course>(testDB);
            var expected = testDB.Courses;

            // Act
            var actual = testRepository.GetAll();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestMethodGroupInCourse_NotNullExpected()
        {
            // Arrange
            HomeController controller = new HomeController(new TestUnitOfWork<TestDB>());
            // Act
            var actual = controller.GroupsInCourse(1);
            // Assert
            Assert.NotNull(actual);
        }

        [Fact]
        public void TestMethodEditGroup_CorrectExpected()
        {
            // Arrange
            HomeController controller = new HomeController(new TestUnitOfWork<TestDB>());
            Group testGroup = testDB.Groups.Find(1);
            testGroup.Name = "713";
            controller.EditGroup(testGroup);
            // Act
            var actual = testDB.Groups.Find(1);
            // Assert
            Assert.Equal("713", actual.Name);
        }

        [Fact]
        public void TestMethodEditStudent_CorrectExpected()
        {
            // Arrange
            HomeController controller = new HomeController(new TestUnitOfWork<TestDB>());
            Student testStudent = testDB.Students.Find(1);
            testStudent.FirstName = "Name";
            testStudent.LastName = "Test";
            controller.EditStudent(testStudent);
            // Act
            var actualStudent = testDB.Students.Find(1);
            // Assert
            Assert.Equal("Name", actualStudent.FirstName);
            Assert.Equal("Test", actualStudent.LastName);
        }

        [Fact]
        public void TestMethodDeleteStudent()
        {   // Arrange
            HomeController controller = new HomeController(new TestUnitOfWork<TestDB>());
            int testId = 1;
            controller.DeleteGroup(testId);
            // Act
            var actual = controller.DeleteGroup(testId).ToString();
            // Assert
            Assert.NotNull(actual);
        }
    }

}