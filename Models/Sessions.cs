

namespace rc_tutors.Models
{
   

    public class Sessions
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } // Foreign key to ApplicationUser
        public ApplicationUser ApplicationUser { get; set; } // Navigation property to ApplicationUser
        public string Subject { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public string Description { get; set; }
        public bool IsFullDay { get; set; }
        public string ThemeColor { get; set; }
    }


}
