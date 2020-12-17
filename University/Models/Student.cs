using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace University.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int? GroupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Group Group { get; set; }
    }
}
