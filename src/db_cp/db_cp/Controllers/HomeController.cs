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
    public class HomeController : Controller
    {
        private IButtonsPostsService bpostService;
        private IButtonsEventsService beventService;
        private IEventsTypesService etypeService;
        private IEventsService eventService;
        private readonly ILogger<HomeController> logger;

        public HomeController(IButtonsPostsService bpostService,
                              IButtonsEventsService beventService,
                              IEventsTypesService etypeService,
                              IEventsService eventService,
                              ILogger<HomeController> logger)
        {
            this.bpostService = bpostService;
            this.beventService = beventService;
            this.etypeService = etypeService;
            this.eventService = eventService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult Index(HomeViewModel model)
        {
            model.allButtonsPosts = bpostService.GetAll();
            model.allButtonsEvents = beventService.GetAll();
            model.allEventsTypes = etypeService.GetAll();
            model.allEvents = eventService.GetAll();

            ViewBag.Title = "Events";

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }
    }
}
