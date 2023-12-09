using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using rc_tutors.Models;
using rc_tutors.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rc_tutors.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Display a list of users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // Display user details and allow role management
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            // Get roles from the role manager
            var allRoles = _roleManager.Roles.Select(r => r.Name).ToList();

            var userRoles = await _userManager.GetRolesAsync(user);

            var model = new ManageRolesViewModel
            {
                UserId = userId,
                UserName = user.UserName,
                CurrentRole = userRoles.FirstOrDefault(),
                AllRoles = allRoles
            };

            return View(model);
        }

        // Handle role assignment
        [HttpPost]
        public async Task<IActionResult> ManageRoles(ManageRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            // Get current roles
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Remove user from all current roles
            await _userManager.RemoveFromRolesAsync(user, currentRoles.ToArray());

            // Add selected role if it is valid
            if (!string.IsNullOrEmpty(model.SelectedRole) && await _roleManager.RoleExistsAsync(model.SelectedRole))
            {
                await _userManager.AddToRoleAsync(user, model.SelectedRole);
            }

            return RedirectToAction("Index", "Admin"); // Redirect to the admin index page or another appropriate action
        }
    }
}

