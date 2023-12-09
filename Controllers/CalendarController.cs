
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace rc_tutors.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEvents()
        {
            // Simulate fetching events from a database or other data source
            var events = new List<EventViewModel>
            {
                new EventViewModel
                {
                    Id = 1,
                    Title = "Event 1",
                    Start = new DateTime(2023, 10, 31, 10, 0, 0),
                    End = new DateTime(2023, 10, 31, 12, 0, 0)
                },
                new EventViewModel
                {
                    Id = 2,
                    Title = "Event 2",
                    Start = new DateTime(2023, 11, 5, 14, 0, 0),
                    End = new DateTime(2023, 11, 5, 16, 0, 0)
                }
                // Add more events as needed
            };

            return Json(events);
        }
    }

    public class EventViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
