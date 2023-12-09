namespace rc_tutors.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class ApplicationUser : IdentityUser
    {
       
       public string FirstName { get; set; }

        public string LastName { get; set; }



        public ICollection<Message> Messages { get; set; }



    }


}
