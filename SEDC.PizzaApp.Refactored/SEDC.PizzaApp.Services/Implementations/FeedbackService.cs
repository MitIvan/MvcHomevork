using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using SEDC.PizzaApp.Mappers.Feedback;
using SEDC.PizzaApp.Services.Interfaces;
using SEDC.PizzaApp.ViewModels.FeedBack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.Services.Implementations
{
    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;

        public FeedbackService(IFeedbackRepository feedback)
        {
            _feedbackRepository = feedback;
        }


        public List<FeedbackDetailsViewModel> GetAllFeebacks()
        {
            List<Feedback> feedbacks = _feedbackRepository.GetAll();

            return  feedbacks.toFeedBackDetailsViewModelList();  
        }

        public void CreateFeedback(FeedbackDetailsViewModel feedbackDetailsViewModel)
        {
            Feedback feedback = feedbackDetailsViewModel.ToFeedback();


            int numOfChars = feedback.Message.ToCharArray().Count();
            if (numOfChars > 100)
            {
                throw new Exception();
            }

            char [] emailValidation = feedback.Email.ToCharArray();
            if(!emailValidation.Contains('@'))
            {
                throw new Exception();
            }
            if(!emailValidation.Contains('.'))
            {
                throw new Exception();
            }
            if (emailValidation.Length < 3)
            {
                throw new Exception();
            }

            // Prefrleno vo repo taka mi imase poveke logika.

            //List<Feedback> feedbacks = _feedbackRepository.GetAll();
            //var numOfEmails = feedbacks.Where(x => x.Email == feedbackDetailsViewModel.Email).ToList().Count();

            //if(numOfEmails > 2)
            //{
            //    throw new Exception();
            //}

            if (_feedbackRepository.GetNumOfEmails(feedback) > 2)
            {
                throw new Exception();
            }

            int newFeedbackId = _feedbackRepository.Insert(feedback);
            if (newFeedbackId <= 0)
            {
                throw new Exception("Something went wrong while saving the feedback");
            }
        }
    }
}
