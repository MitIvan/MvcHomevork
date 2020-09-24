using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.EFImplementations
{
   public class FeedbackEFRepository : IFeedbackRepository
    {
        private PizzaAppDbContext _pizzaAppDbContext;

        public FeedbackEFRepository(PizzaAppDbContext pizzaAppDbContext)
        {
            _pizzaAppDbContext = pizzaAppDbContext;

        }


        public List<Feedback> GetAll()
        {
            return _pizzaAppDbContext.Feedbacks.ToList();
        }

        public Feedback GetById(int id)
        {
            return _pizzaAppDbContext.Feedbacks
                .FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Feedback entity)
        {
            _pizzaAppDbContext.Feedbacks.Add(entity);

            return _pizzaAppDbContext.SaveChanges();
        }

        public void Update(Feedback entity)
        {
            Feedback feedbackDb = _pizzaAppDbContext.Feedbacks.FirstOrDefault(x => x.Id == entity.Id);
            if (feedbackDb == null)
            {
                throw new Exception($"The feedback with id {entity.Id} was not found!");
            }



            feedbackDb.Email = entity.Email;
            feedbackDb.Message = entity.Message;
            feedbackDb.Id = entity.Id;
            feedbackDb.Name = entity.Name;

            // Ne zamam zasto no vaka ne raboti kako sto pisavme na cas
            //_pizzaAppDbContext.Feedbacks.Update(entity);
            _pizzaAppDbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Feedback feedbackDb = _pizzaAppDbContext.Feedbacks.FirstOrDefault(x => x.Id == id);
            if (feedbackDb == null)
            {
                throw new Exception($"The feedback with id {id} was not found!");
            }

            _pizzaAppDbContext.Feedbacks.Remove(feedbackDb);
            _pizzaAppDbContext.SaveChanges();
        }

        public int GetNumOfEmails(Feedback entety)
        {
            int numOfEmails = _pizzaAppDbContext.Feedbacks.Where(x => x.Email == entety.Email)
                .ToList()
                .Count();
            return numOfEmails;
        }
    }
}
