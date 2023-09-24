using System;
using db_cp.ViewModels;
using db_cp.Services;
using Microsoft.AspNetCore.Mvc;
using db_cp.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace db_cp.Controllers
{
    public class NewsController : Controller
    {
        private INewsService newsService;
        private readonly ILogger<NewsController> logger;

        public NewsController(INewsService newsService,
                              ILogger<NewsController> logger)
        {
            this.newsService = newsService;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult AddNews()
        {
            ViewBag.Title = "AddNews";

            NewsViewModel model = new NewsViewModel();
            model.allNews = newsService.GetAll();

            logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

            return View(model);
        }

        [HttpPost]
        public IActionResult AddNews(NewsViewModel model)
        {
            ViewBag.Title = "AddNews";

            if (ModelState.IsValid)
            {
                try
                {
                    News news = new News
                    {
                        Content = model.Content,
                        Time = DateTime.Now
                    };

                    newsService.Add(news);

                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name);

                    return RedirectToAction("AddNews", "News");
                }
                catch (Exception ex)
                {
                    logger.LogInformation(User.Identity.Name, MethodBase.GetCurrentMethod().Name, ex.Message);

                    ModelState.AddModelError("", "This news already exists.");
                }
            }
            else
                ModelState.AddModelError("", "Incorrect data");

            return View(model);
        }
    }
}
