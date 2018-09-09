using ShoppCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferedDrinks { get; set; }
    }
}
