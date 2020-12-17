using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace University.Models
{
    public partial class Group
    {
        public Group()
        {
            Students = new HashSet<Student>();
        }
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
