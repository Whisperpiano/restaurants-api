using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }

    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants =
            [
            new()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "Kentucky Fried Chicken",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes =
                [
                    new()
                    {
                        Name = "Nashville Hot Chicken",
                        Description = "Spicy fried chicken with a crispy coating",
                        Price = 12.99m,
                    },

                    new()
                    {
                        Name = "Original Recipe Chicken",
                        Description = "Famous secret recipe chicken",
                        Price = 10.99m,
                    },
                    ],
                Address = new()
                {
                    City = "London",
                    Street = "123 Chicken Street",
                    PostalCode = "SW1A 1AA",
                }
            },

            new Restaurant()
            {
                Name = "McDonald's",
                Category = "Fast Food",
                Description = "Global fast food chain",
                ContactEmail = "contact@mcdonalds.com",
                HasDelivery = true,
                Address = new Address()
                {
                    City = "London",
                    Street = "456 Burger Lane",
                    PostalCode = "SW1A 1BB",
                }
            }
            ];

        return restaurants;
    }
}
