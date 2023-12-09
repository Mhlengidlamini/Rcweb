using System.Reflection;

namespace rc_tutors.Models
{
    public class Faculty
    {
        public int FacultyId { get; set; }
        public string Department { get; set; }

        // Navigation property for Modules taught by this Faculty
        public virtual ICollection<Modules> Modules { get; set; }
    }
}
