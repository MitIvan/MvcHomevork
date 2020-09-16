using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.DataAccess.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        int GetNumOfEmails(Feedback entety);
    }
}
