
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace rc_tutors.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
