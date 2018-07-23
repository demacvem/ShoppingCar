using Microsoft.EntityFrameworkCore;
using ShoppCar.Data.Interfaces;
using ShoppCar.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppCar.Data.Repositories
{
    public class DrinkRepository : IDrinkRepository
    {
        private readonly AppDbContext _appDbContext;

        public DrinkRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Drink> Drinks => _appDbContext.Drinks.Include(d => d.Category);

        public IEnumerable<Drink> PreferredDrinks => _appDbContext.Drinks.Where(d => d.IsPreferredDrink).Include(d => d.Category);

        public Drink GetDrinkById(int id) => _appDbContext.Drinks.FirstOrDefault(d => d.DrinkId == id);
    }
}
