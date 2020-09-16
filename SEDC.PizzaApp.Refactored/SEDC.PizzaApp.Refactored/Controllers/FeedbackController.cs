using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.FeedBack;

namespace SEDC.PizzaApp.Refactored.Controllers
{
    public class FeedbackController : Controller
    {
        private IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public IActionResult Index()
        {
            List<FeedbackDetailsViewModel> feedbackDetailsViewModels = _feedbackService.GetAllFeebacks();
            return View(feedbackDetailsViewModels);
        }

        public IActionResult CreateFeedback ()
        {
            FeedbackDetailsViewModel feedbackDetailsViewModel = new FeedbackDetailsViewModel();
            return View(feedbackDetailsViewModel);
        }

        [HttpPost]
        public IActionResult CreateFeedbackPost(FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            try
            {
                _feedbackService.CreateFeedback(feedbackDetailsViewModel);
                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return View("ExceptionView");
            }
        }

    }
}
