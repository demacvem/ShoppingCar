using Microsoft.AspNetCore.Mvc;
using ShoppCar.Data.Interfaces;
using ShoppCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.Controllers
{
    public class DrinkController : Controller
    {
        private readonly ICategoryRepository _categoryReository;
        private readonly IDrinkRepository _drinkReository;

        public DrinkController(ICategoryRepository categoryRepository, IDrinkRepository drinkRepository)
        {
            _categoryReository = categoryRepository;
            _drinkReository = drinkRepository;
        }

        public ViewResult List()
        {
            ViewBag.Name = "WhatsApp";
            DrinkListViewModel model = new DrinkListViewModel();
            model.Drinks = _drinkReository.Drinks;
            model.CurrentCategory = "DrinkCategory";
            return View(model);
        }
    }
}
