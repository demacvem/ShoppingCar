using Microsoft.AspNetCore.Mvc;
using ShoppCar.Data.Interfaces;
using ShoppCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;

        public HomeController(IDrinkRepository drinkRepository)
        {
            _drinkRepository = drinkRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PreferedDrinks = _drinkRepository.PreferredDrinks
            };

            return View(homeViewModel);
        }
    }
}
