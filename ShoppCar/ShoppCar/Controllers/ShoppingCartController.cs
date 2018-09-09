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
    public class ShoppingCartController : Controller
    {
        private readonly IDrinkRepository _drinkRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IDrinkRepository drinkRepository, ShoppingCart shoppingCart)
        {
            _drinkRepository = drinkRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var sCmv = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(sCmv);
        }

        public RedirectToActionResult AddToShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkRepository.Drinks
                .FirstOrDefault(s => s.DrinkId == drinkId);

            if(selectedDrink != null)
            {
                _shoppingCart.AddToCart(selectedDrink, 1);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int drinkId)
        {
            var selectedDrink = _drinkRepository.Drinks
                .FirstOrDefault(s => s.DrinkId == drinkId);

            if (selectedDrink != null)
            {
                _shoppingCart.RemoveFromCart(selectedDrink);
            }

            return RedirectToAction("Index");
        }
    }
}
