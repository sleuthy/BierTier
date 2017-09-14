using System; 
using System.Linq; 
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection; 
using BierTier.Models;
using System.Threading.Tasks;
using BierTier.Data;

namespace BierTier.Data
{
    public static class DBInitializer 
    { 
        public static void Initialize(IServiceProvider serviceProvider) 
        { 
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) 
            { 
                if(context.Beers.Any()) 
                { 
                    return; //db is already seeded
                }

                var beer = new Beer []
                {
                    new Beer()
                    {
                        Name = "Bearwalker",
                        Brewery = "Jackalope",
                        Description = "Bearwalker was inspired by our brewmaster Bailey’s Vermont roots. Pure maple syrup is infused during the conditioning phase, and is noticeable from start to finish. Chocolate malts add roasted notes to the flavor and aroma. It is also more highly hopped than most browns to create a balanced, yet complex brew.",
                        Type = "Maple Brown",
                        ABV = 5.1,
                        IBU = 32,
                        Image = "http://jackalopebrew.com/new/wp-content/uploads/2013/11/bearwalker-web.png"
                    },

                    new Beer()
                    {
                        Name = "West Coast IPS",
                        Brewery = "Green Flash",
                        Description = "Assertive, grapefruit zest bitterness supported by notes of dark caramel from British Crystal malt, finishes floral with dry woodsy hop notes.",
                        Type = "Double IPA",
                        ABV = 8.1,
                        IBU = 95,
                        Image = "https://res.cloudinary.com/ratebeer/image/upload/w_120,c_limit/beer_257984.jpg"
                       
                    }
                };
                foreach(Beer b in beer)
                {
                    context.Beers.Add(b);
                }
                context.SaveChanges();

            }
        }
    }
}