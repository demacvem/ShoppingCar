using Microsoft.AspNetCore.Mvc;
using ShoppCar.Data.Models;
using ShoppCar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //var items = _shoppingCart.GetShoppingCartItems();
            var items = new List<ShoppingCartItem>()
            {
                new ShoppingCartItem{ Amount = 1},
                new ShoppingCartItem{ Amount = 2}
            };

            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartItemViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartItemViewModel);
        }
    }
}
