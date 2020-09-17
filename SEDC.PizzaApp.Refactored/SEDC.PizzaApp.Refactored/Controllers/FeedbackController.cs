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

        public IActionResult EditFeedback (int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                FeedbackDetailsViewModel feedbackDetailsViewModel = _feedbackService.GetFeedbackForEditing(id.Value);
                return View(feedbackDetailsViewModel);
            }
            catch (Exception)
            {

                return View("ExceptionView");
            }
        }

        [HttpPost]
        public IActionResult EditFeedbackPost (FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            try
            {
                _feedbackService.EditFeedback(feedbackDetailsViewModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }
        }

        public IActionResult DeleteFeedback(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            try
            {
                FeedbackDetailsViewModel feedbackDetailsViewModel = _feedbackService.GetFeedbackById(id.Value);
                return View(feedbackDetailsViewModel);
            }
            catch
            {
                return View("ExceptionView");
            }
        }

        [HttpPost]
        public IActionResult DeleteFeedbackPost(FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            try
            {
                _feedbackService.DeleteFeedback(feedbackDetailsViewModel.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("ExceptionView");
            }
        }
    }
}
