using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using rc_tutors.Models;
using System.Linq;

namespace rc_tutors.Controllers
{
    public class MessageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public MessageController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // Get the list of users
            var users = _userManager.Users.ToList();

            // Pass the list of users to the view
            return View(users);
        }

     
    }
}
