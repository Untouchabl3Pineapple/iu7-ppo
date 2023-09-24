using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using db_cp.ViewModels;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using Microsoft.AspNetCore.Mvc;
using db_cp.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace db_cp.Controllers
{
    public class EventsController : Controller
    {
        private IEventsService eventService;
        private IEventsTypesService eventTypeService;
        private readonly ILogger<EventsController> logger;

        public EventsController(IEventsService eventService,
                                IEventsTypesService eventTypeService,
                                ILogger<EventsController> logger)
        {
            this.eventService = eventService;
            this.eventTypeService = eventTypeService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Editing()
        {
            ViewBag.Title = "Editing";

            EventsViewModel model = new EventsViewModel();
            model.allEventsTypes = eventTypeService.GetAll();

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }

        [HttpPost]
        public IActionResult Editing(int id, string eventType, string eventDescription)
        {
            ViewBag.Title = "Editing";
           
            if (ModelState.IsValid)
            {
                try
                {
                    EventsViewModel model = new EventsViewModel();
                    model.allEventsTypes = eventTypeService.GetAll();

                    Events eevent = eventService.GetByID(id);

                    eevent.EventType_ID = model.allEventsTypes.FirstOrDefault(elem => elem.EventType == eventType).ID;
                    eevent.EventDescription = eventDescription;

                    eventService.Update(eevent);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "The specified incident type does not exist.");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View();
        }
    }
}
