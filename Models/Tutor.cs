namespace rc_tutors.Models
{
    public class Tutor
    {
        public int Id { get; set; }


        public string TutorImage { get; set; }

        // Foreign key to link Tutor to ApplicationUser
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        // Foreign key to link Tutor to a Module
        public int ModuleId { get; set; }
        public virtual Modules Module { get; set; }
    }
}
