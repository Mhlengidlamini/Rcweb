namespace rc_tutors.Models
{
    public class Modules
    {
        public int Id { get; set; }
        public string ModuleName { get; set; }

        // Foreign key to link Module to Faculty
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }

        // Navigation property for Tutors in this Module
        public virtual ICollection<Tutor> Tutors { get; set; }
    }
}
