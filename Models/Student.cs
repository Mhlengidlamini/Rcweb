namespace rc_tutors.Models
{
    public class Student
    {
        public int Id { get; set; }
        // Add properties specific to a Student

        // Foreign key to link Student to ApplicationUser
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}