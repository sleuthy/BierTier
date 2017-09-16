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
        public static void Initializer(IServiceProvider serviceProvider) 
        { 
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>())) 
            { 
                if(context.Beer.Any()) 
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
                        Name = "West Coast IPA",
                        Brewery = "Green Flash",
                        Description = "Assertive, grapefruit zest bitterness supported by notes of dark caramel from British Crystal malt, finishes floral with dry woodsy hop notes.",
                        Type = "Double IPA",
                        ABV = 8.1,
                        IBU = 95,
                        Image = "https://res.cloudinary.com/ratebeer/image/upload/w_120,c_limit/beer_257984.jpg"
                       
                    },
                    
                    new Beer()
                    {
                        Name = "Oktoberfest",
                        Brewery = "Wiseacre",
                        Description = "Oktoberfest is a Marzen – a smooth, clean, malt forward German lager that was traditionally released each September for Oktoberfest in Munich. Toasty bread and subtlety sweet malt qualities emerge right before the beer abruptly, cleanly finishes",
                        Type = "Marzen",
                        ABV = 5.9,
                        IBU = 24,
                        Image = "http://central-distributors.com/uploads/beer-images/wiseacre-ocktoberfest.png"
                       
                    },

                    new Beer()
                    {
                        Name = "Oktoberfest",
                        Brewery = "Sierra Nevada",
                        Description = "Each year, we partner with a different German brewer to explore the roots of Germany’s famous Oktoberfest beers. This year, we’re collaborating with Germany’s Brauhaus Miltenberger, whose approach to the classic style we’ve long admired. The result is a festival beer true to their style—deep golden in color with deceptively rich malt flavor and balanced by traditional German-grown whole-cone hops.",
                        Type = "Marzen",
                        ABV = 6.1,
                        IBU = 30,
                        Image = "https://www.cdn.sierranevada.com/sites/www.sierranevada.com/files/content/beers/oktoberfest/oktoberfest2017bottlepint.png"
                    }
                };
                foreach(Beer b in beer)
                {
                    context.Add(b);
                    context.SaveChanges();
                }

            }
        }
    }
}