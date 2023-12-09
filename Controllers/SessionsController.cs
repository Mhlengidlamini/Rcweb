using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rc_tutors.Models; // Adjust the namespace for your Event model
using rc_tutors.Data; // Adjust the namespace for your DbContext
using rc_tutors.Data;
using rc_tutors.Models.ViewModel;

namespace rc_tutors.Controllers
{
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context; // Inject your DbContext

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sessions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tutors()
        {
            // Replace the following code with your actual data retrieval logic
            var tutorModules = _context.Faculties
                .Select(faculty => new TutorModuleViewModel
                {
                    Faculty = faculty.Department,
                    Modules = faculty.Modules.Select(module => new ModuleViewModel
                    {
                        ModuleName = module.ModuleName,
                        Tutors = module.Tutors.Select(tutor => new TutorViewModel
                        {
                            TutorName = $"{tutor.User.FirstName} {tutor.User.LastName}",
                            TutorImage = tutor.TutorImage // Add your image property here
                        }).ToList()
                    }).ToList()
                }).ToList();

            return View(tutorModules);
        }

        public JsonResult GetEvents()
        {
            var events = _context.Events.ToList();
            return new JsonResult(events);
        }

        [HttpPost]
        public JsonResult SaveEvent(Sessions e)
        {
            var status = false;
            if (e.Id > 0)
            {
                // Update the event
                var existingEvent = _context.Events.FirstOrDefault(a => a.Id == e.Id);
                if (existingEvent != null)
                {
                    existingEvent.Subject = e.Subject;
                    existingEvent.Start = e.Start;
                    existingEvent.End = e.End;
                    existingEvent.Description = e.Description;
                    existingEvent.IsFullDay = e.IsFullDay;
                    existingEvent.ThemeColor = e.ThemeColor;
                }
            }
            else
            {
                _context.Events.Add(e);
            }

            _context.SaveChanges();
            status = true;

            return new JsonResult(new { status = status });
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            var existingEvent = _context.Events.FirstOrDefault(a => a.Id == eventID);
            if (existingEvent != null)
            {
                _context.Events.Remove(existingEvent);
                _context.SaveChanges();
                status = true;
            }

            return new JsonResult(new { status = status });
        }
    }
}
