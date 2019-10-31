using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurant : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurant(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        void IRestaurantData.Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        IEnumerable<Restaurant> IRestaurantData.GetAll()
        {
            return from r in db.Restaurants
                   orderby r.Name
                   select r;
        }

        void IRestaurantData.Update(Restaurant restaurant)
        {
            var entry = db.Entry(restaurant);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        void IRestaurantData.Delete(int id)
        {
            var restauant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restauant);
            db.SaveChanges();
        }
    }
}
