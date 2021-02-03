using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quartz;
using QuartzWithCore.Models;
using QuartzWithCore.Tasks;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace QuartzWithCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScheduler _scheduler;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IScheduler factory)
        {
            _logger = logger;
            _scheduler = factory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> CheckAvailability()
        {
            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity($"Check Availability.{DateTime.Now}")
                                .StartNow()
                                .WithPriority(1)
                                .Build();
            IJobDetail job = JobBuilder.Create<CheckAvailabilityTask>()
                                        .WithIdentity("Check Availability")
                                        .Build();
            await _scheduler.ScheduleJob(job, trigger);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
