using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using University.Models;

namespace University.Test
{
    public class TestDB : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }

        public TestDB()
        {
            Courses.AddRange(testCourses);
            Groups.AddRange(testGroups);
            Students.AddRange(testStudents);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("test");
        }

        public List<Course> testCourses = new List<Course>()
        {
            new Course{CourseId = 1, Name = "C++", Description = "Learn C++" },
            new Course{CourseId = 2, Name = "C#", Description = "Learn C#" },
            new Course{CourseId = 3, Name = "JavaScript", Description = "Learn JavaScript" },
            new Course{CourseId = 4, Name = "Java", Description = "Learn Java" },
            new Course{CourseId = 5, Name = "Swift", Description = "Learn Swift" }
        };

        public List<Group> testGroups = new List<Group>()
        {
            new Group{ GroupId = 1, CourseId = 1, Name = "1 Group"},
            new Group{ GroupId = 2, CourseId = 2, Name = "2 Group"},
            new Group{ GroupId = 3, CourseId = 3, Name = "3 Group"},
            new Group{ GroupId = 4, CourseId = 4, Name = "4 Group"},
            new Group{ GroupId = 5, CourseId = 5, Name = "5 Group"},
            new Group{ GroupId = 6, CourseId = 1, Name = "16 Group"},
            new Group{ GroupId = 7, CourseId = 2, Name = "27 Group"},
            new Group{ GroupId = 8, CourseId = 3, Name = "38 Group"}
        };

        public List<Student> testStudents = new List<Student>()
        {
            new Student{ StudentId = 1, GroupId = 1, FirstName = "Bob", LastName = "Di" },
            new Student{ StudentId = 2, GroupId = 2, FirstName = "John", LastName = "Dou" },
            new Student{ StudentId = 3, GroupId = 3, FirstName = "Harry", LastName = "Potter" },
            new Student{ StudentId = 4, GroupId = 4, FirstName = "Frodo", LastName = "Begins" },
            new Student{ StudentId = 5, GroupId = 5, FirstName = "Ron", LastName = "Weasley" },
            new Student{ StudentId = 6, GroupId = 6, FirstName = "Hermione ", LastName = "Granger" },
            new Student{ StudentId = 7, GroupId = 7, FirstName = "Peter", LastName = "Parker" },
            new Student{ StudentId = 8, GroupId = 8, FirstName = "Fat", LastName = "Goblin " },
            new Student{ StudentId = 9, GroupId = 1, FirstName = "Tony", LastName = "Stark" },
            new Student{ StudentId = 10, GroupId = 2, FirstName = "John", LastName = "Snow" },
            new Student{ StudentId = 11, GroupId = 3, FirstName = "Tor", LastName = "Odinson" },
            new Student{ StudentId = 12, GroupId = 4, FirstName = "Steve", LastName = "Rogers" },
            new Student{ StudentId = 13, GroupId = 5, FirstName = "Black", LastName = "Widow" },
            new Student{ StudentId = 14, GroupId = 6, FirstName = "This", LastName = "Dude" },
        };
    }
}
