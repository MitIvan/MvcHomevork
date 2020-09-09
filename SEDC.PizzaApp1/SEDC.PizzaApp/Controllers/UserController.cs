using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = StaticDb.Users;
            List<UserViewModel> userViewModels = new List<UserViewModel>();

            foreach (var user in users)
            {
                userViewModels.Add(UserMapper.ToUserViewModel(user));
            }

            return View(userViewModels);
        }


        public IActionResult AddUser()
        {
            // Bidejki mi trebaat site atributi od User dali da se zeme domain User modelot ili da se napravi nov View Model??
            User user = new User();

            return View(user);
        }

        [HttpPost]
        public IActionResult AddUserPost(User user)
        {
            user.Id = ++StaticDb.UserId;

            StaticDb.Users.Add(user);

            return RedirectToAction("Index");
        }

        public IActionResult EditUser (int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }

            User user = StaticDb.Users.FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return View("ResourceNotFound");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditUserPost ( User user)
        {
            User edditedUser = StaticDb.Users.FirstOrDefault(u => u.Id == user.Id);

            if (edditedUser == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Users.IndexOf(edditedUser);
            StaticDb.Users[index] = user;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteUser(int? id)
        {
            User user = StaticDb.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return View("ResourceNotFound");
            }

            Order order = StaticDb.Orders.FirstOrDefault(p => p.User.Id == id);
            if (order != null)
            {
                return View("UserHasOrder");
            }

            return View(user);

        }

        public IActionResult ConfirmDeleteUser (int id)
        {
            var index = StaticDb.Users.FindIndex(x => x.Id == id);
    
            if (index == -1)
                return View("ResourceNotFound");

            StaticDb.Users.RemoveAt(index);
            return RedirectToAction("Index");
        }
    }
}

