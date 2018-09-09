using Microsoft.AspNetCore.Mvc;
using ShoppCar.Data.Interfaces;
using ShoppCar.Data.Models;
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

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Drink> drinks;

            string currentCatgory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                drinks = _drinkReository.Drinks.OrderBy(n => n.DrinkId);
                currentCatgory = "All drinks";
            }
            else
            {
                if(string.Equals("Alcoholic",_category, StringComparison.OrdinalIgnoreCase))
                {
                    drinks = _drinkReository.Drinks.Where(p => p.Category.CategoryName.Equals("Alcoholic")).OrderBy(d => d.DrinkId);
                }
                else
                {
                    drinks = _drinkReository.Drinks.Where(p => p.Category.CategoryName.Equals("Non-alcoholic")).OrderBy(d => d.DrinkId);
                }

                currentCatgory = _category;
            }

            var drinkListViewModel = new DrinkListViewModel
            {
                Drinks = drinks,
                CurrentCategory = currentCatgory
            };

            return View(drinkListViewModel);
        }
    }
}
