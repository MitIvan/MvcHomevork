using SEDC.PizzaApp.DataAccess.Interfaces;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public List<Feedback> GetAll()
        {

            return StaticDb.Feedbacks;
        }

        public Feedback GetById(int id)
        {
            return StaticDb.Feedbacks.FirstOrDefault(f => f.Id == id);
        }

        public int Insert(Feedback entity)
        {
            StaticDb.FeedbackId++;
            entity.Id = StaticDb.FeedbackId;
            StaticDb.Feedbacks.Add(entity);
            return entity.Id;
        }

        public void Update(Feedback entity)
        {
            Feedback feedback = StaticDb.Feedbacks.FirstOrDefault(f => f.Id == entity.Id);
            
            if(feedback == null)
            {
                throw new Exception($"Feedback with id {entity.Id} does not exist!");
            }

            int index = StaticDb.Feedbacks.IndexOf(feedback);
            StaticDb.Feedbacks[index] = entity;
        }

        public void DeleteById(int id)
        {
            Feedback feedback = StaticDb.Feedbacks.FirstOrDefault(f => f.Id == id);
            if (feedback == null)
            {
                throw new Exception($"Feedback with id {id} does not exist!");
            }

            StaticDb.Feedbacks.Remove(feedback);
        }

        public int GetNumOfEmails(Feedback entety)
        {
            // go napraviv vaka bidejki ako ima 1mil emails podobro ke bide da se prebaraat vo baza otkolu vo memo;
            int numOfEmails = StaticDb.Feedbacks.Where(x => x.Email == entety.Email).ToList().Count();
            return numOfEmails;
        }
    }
}
