using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rc_tutors.Data;
using rc_tutors.Models;
using rc_tutors.Models.ViewModel;
using System.Linq;
using System.Threading.Tasks;

namespace rc_tutors.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ApplicationUser user = _userManager.GetUserAsync(User).Result;

            if (user == null)
            {
                // Handle the case where the user is not found
                // You can return an error view or redirect to another page
            }

            ProfileViewModel profile = new ProfileViewModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Phone = user.PhoneNumber,
                Password = user.PasswordHash,
                
            };

            return View(profile);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            ApplicationUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return NotFound();
            }

            ProfileViewModel profile = new ProfileViewModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Phone = user.PhoneNumber
            };

            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            
                ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    user.FirstName = model.FullName;
                    user.Email = model.Email;
                    user.PhoneNumber = model.Phone;
                    

                    IdentityResult result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
           

            return View(model);
        }
    }
}

