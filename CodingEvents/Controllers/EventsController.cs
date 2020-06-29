using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);

            return Redirect("/Events");
        }

        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach (int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }

        [HttpPost("/events/edit")]
        public IActionResult Update(int id, string name, string description)
        {
            Event eventToUpdate = EventData.GetById(id);
            eventToUpdate.Name = name;
            eventToUpdate.Description = description;


            return Redirect("/events");
        }

        [HttpGet("/events/edit/{id}")]
        public IActionResult Edit(int eventId)
        {
            ViewBag.eventtoedit = EventData.GetById(eventId);
            return View();
        }
    }
}
