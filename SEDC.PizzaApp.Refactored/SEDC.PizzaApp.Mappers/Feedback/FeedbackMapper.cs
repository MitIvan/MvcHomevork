using SEDC.PizzaApp.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Mappers.Feedback
{
    public static class FeedbackMapper
    {
        public static FeedbackDetailsViewModel toFeedBackDetailsViewModel(this Domain.Models.Feedback feedback)
        {
            return new FeedbackDetailsViewModel
            {
                Id = feedback.Id,
                Name = feedback.Name,
                Email = feedback.Email,
                Message = feedback.Message
            };
        }

        public static List<FeedbackDetailsViewModel> toFeedBackDetailsViewModelList(this List<Domain.Models.Feedback> feedbacks)
        {
            List<FeedbackDetailsViewModel> viewModels = new List<FeedbackDetailsViewModel>();

            foreach (Domain.Models.Feedback feedback in feedbacks)
            {
                viewModels.Add(feedback.toFeedBackDetailsViewModel());
            }

            return viewModels;
        }

        public static Domain.Models.Feedback ToFeedback(this FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            return new Domain.Models.Feedback
            {
                Id = feedbackDetailsViewModel.Id,
                Name = feedbackDetailsViewModel.Name,
                Email = feedbackDetailsViewModel.Email,
                Message = feedbackDetailsViewModel.Message

            };
        }
    }
}
