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
using System.IO;
using System.Threading.Channels;

namespace db_cp.Controllers
{
    public class EventsTypesController : Controller
    {
        IEventsTypesService eventTypeService;
        private readonly ILogger<EventsTypesController> logger;

        public EventsTypesController(IEventsTypesService eventTypeService,
                              ILogger<EventsTypesController> logger)
        {
            this.eventTypeService = eventTypeService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult AddEventType()
        {
            ViewBag.Title = "AddEventType";

            EventTypeViewModel model = new EventTypeViewModel();
            model.allEventsTypes = eventTypeService.GetAll();


            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddEventType(EventTypeViewModel model)
        {
            ViewBag.Title = "AddEventType";

            if (ModelState.IsValid)
            {
                try
                {
                    EventsTypes eventtype = new EventsTypes
                    {
                        EventType = model.EventType
                    };

                    eventTypeService.Add(eventtype);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("AddEventType", "EventsTypes");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This type of incident already exists");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View(model);
        }

        [HttpGet]
        public IActionResult DelEventType()
        {
            ViewBag.Title = "DelEventType";

            EventTypeViewModel model = new EventTypeViewModel();
            model.allEventsTypes = eventTypeService.GetAll();

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }

        [HttpPost]
        public IActionResult DelEventType(EventTypeViewModel model)
        {
            ViewBag.Title = "DelEventType";

            if (ModelState.IsValid)
            {
                try
                {
                    EventsTypes eventtype = eventTypeService.GetByEventType(model.EventType);

                    eventTypeService.Delete(eventtype);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("DelEventType", "EventsTypes");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This type of event does not exist.");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View(model);
        }
    }
}
