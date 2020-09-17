using SEDC.PizzaApp.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Interfaces
{
    public interface IFeedbackService
    {
        List<FeedbackDetailsViewModel> GetAllFeebacks();
        void CreateFeedback(FeedbackDetailsViewModel feedbackDetailsViewModel);
        FeedbackDetailsViewModel GetFeedbackForEditing(int id);
        void EditFeedback(FeedbackDetailsViewModel feedbackDetailsViewModel);
        FeedbackDetailsViewModel GetFeedbackById(int id);
        void DeleteFeedback(int id);

    }
}
