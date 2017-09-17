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
                    return;
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
                    },
                     new Beer()
                    {
                        Name = "Breakfast Stout",
                        Brewery = "Founders Brewing Company",
                        Description = "The coffee lover’s consummate beer. Brewed with an abundance of flaked oats, bitter and imported chocolates, and two types of coffee, this stout has an intense fresh-roasted java nose topped with a frothy, cinnamon-colored head that goes forever.",
                        Type = "American Double / Imperial Stout",
                        ABV = 8.3,
                        IBU = 60,
                        Image = "https://foundersbrewing.com/wp-content/uploads/2017/01/BreakfastStout2017Feature.jpg" 
                    },

                    new Beer()
                    {
                        Name = "90 Minute IPA",
                        Brewery = "Dogfish Head Craft Brewery",
                        Description = "An imperial IPA best savored from a snifter, 90 Minute has a great malt backbone that stands up to the extreme hopping rate. 90 Minute IPA was the first beer we continuously hopped, allowing for a pungent -- but not crushing -- hop flavor.",
                        Type = "American Double / Imperial IPA",
                        ABV = 9.0,
                        IBU = 90,
                        Image = "https://i.pinimg.com/236x/60/87/45/608745a61886f8db7c31b8dfd2e53fec--brewing-recipes-homebrew-recipes.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Pliny The Elder",
                        Brewery = "Russian River Brewing Company",
                        Description = "Pliny the Elder was a Roman naturalist, scholar, historian, traveler, officer, and writer. Although not considered his most important work, Pliny and his contemporaries created the botanical name for hops, 'lupus Salictarius', meaning wolf among scrubs. Hops at that time grew wild among willows, much like a wolf in the forest. Later the current botanical name, humulus Lupulus, was adopted. Pliny died in 79 AD while observing the eruption of Mount Vesuvius. He was immortalized by his nephew, Pliny the Younger, who continued his uncle’s legacy by documenting much of what he observed during the eruption of Mount Vesuvius. Pliny the Elder, the beer, is brewed with 40% more malt and over twice the amount of hops as compared to our already hoppy IPA.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.0,
                        IBU = 100,
                        Image = "https://deardenver.files.wordpress.com/2016/06/6a00d8341c2b7953ef0167681c9cef970b-550wi.jpg"
                    },                
                 
                    new Beer()
                    {
                        Name = "Two Hearted Ale",
                        Brewery = "Bell's Brewery, Inc.",
                        Description = "Brewed with 100% Centennial hops from the Pacific Northwest and named after the Two Hearted River in Michigan’s Upper Peninsula, this IPA is bursting with hop aromas ranging from pine to grapefruit from massive hop additions in both the kettle and the fermenter. Perfectly balanced with a malt backbone and combined with the signature fruity aromas of Bell's house yeast, this beer is remarkably drinkable and well suited for adventures everywhere.",
                        Type = "American IPA",
                        ABV = 7.0,
                        IBU = 55,
                        Image = "http://www.vinowineshopnc.com/wp-content/uploads/2015/05/bellstwohearted.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Sculpin IPA",
                        Brewery = "Ballast Point Brewing Company",
                        Description = "The Sculpin IPA is a testament to our humble beginnings as Home Brew Mart. Founded in 1992, the Mart continues to be a catalyst for the San Diego brewing scene, setting the trend for handcrafted ales. Inspired by our customers, employees and brewers, the Sculpin IPA is bright with aromas of apricot, peach, mango and lemon. Its lighter body also brings out the crispness of the hops. This delicious Ballast Point Ale took a Bronze Medal at the 2007 Great American Beer Festival in the Pro Am category. The Sculpin fish has poisonous spikes on its fins that can give a strong sting. Ironically, the meat from a Sculpin is considered some of the most tasty. Something that has a sting but tastes great, sounds like a Ballast Point India Pale Ale.",
                        Type = "American IPA",
                        ABV = 7.0,
                        IBU = 70,
                        Image = "https://www.ballastpoint.com/wp-content/uploads/2013/09/02-beers-primary-image-Sculpin.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Heady Topper",
                        Brewery = "The Alchemist Brewery and Visitors Center",
                        Description = "Heady Topper is not intended to be the strongest or most bitter DIPA. It is brewed to give you wave after wave of hop flavor without any astringent bitterness. We brew Heady Topper with a proprietary blend of six hops—each imparting its own unique flavor and aroma. There is just enough malt to give this beer some backbone, but not enough to take the hops away from the center stage.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.0,
                        IBU = 100,
                        Image = "http://beer.suregork.com/wp-content/uploads/2012/06/alchemist_heady_topper-500x581.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Hopslam Ale",
                        Brewery = "Bell's Brewery, Inc.",
                        Description = "Starting with six different hop varietals added to the brew kettle & culminating with a massive dry-hop addition of Simcoe hops, Bell's Hopslam Ale possesses the most complex hopping schedule in the Bell's repertoire. Selected specifically because of their aromatic qualities, these Pacific Northwest varieties contribute a pungent blend of grapefruit, stone fruit, and floral notes. A generous malt bill and a solid dollop of honey provide just enough body to keep the balance in check, resulting in a remarkably drinkable rendition of the Double India Pale Ale style.",
                        Type = "American Double / Imperial IPA",
                        ABV = 10.0,
                        IBU = 70,
                        Image = "https://beermetaldude.files.wordpress.com/2014/02/hopslam.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "KBS (Kentucky Breakfast Stout)",
                        Brewery = "Founders Breweing Company",
                        Description = "A bit of backwoods pleasure without the banjo. This strong stout is brewed with a hint of coffee and vanilla then aged in oak bourbon barrels. Our process ensures that strong bourbon undertones come through in the finish in every batch we brew. We recommend decanting at room temperature and best enjoyed in a brandy snifter.",
                        Type = "American Double / Imperial Stout",
                        ABV = 11.8,
                        IBU = 70,
                        Image = "https://kingbobyjr.files.wordpress.com/2011/03/beer-95.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Old Rasputin Russian Imperial Stout",
                        Brewery = "North Coast Brewing Co.",
                        Description = "Produced in the tradition of 18th Century English brewers who supplied the court of Russia’s Catherine the Great, Old Rasputin seems to develop a cult following wherever it goes. It’s a rich, intense brew with big complex flavors and a warming finish.",
                        Type = "Russian Imperial Stout",
                        ABV = 9.0,
                        IBU = 75,
                        Image = "https://beerandamovie.files.wordpress.com/2012/02/old-rasputin-russian-imperial-stout.jpeg"
                    },
                   
                    new Beer()
                    {
                        Name = "Bourbon County Brand Stout",
                        Brewery = "Goose Island Beer Co.",
                        Description = "I really wanted to do something special for our 1000th batch at the original brewpub. Goose Island could have thrown a party. But we did something better. We brewed a beer. A really big batch of stout-so big the malt was coming out of the top of the mash tun. After fermentation we brought in some bourbon barrels to age the stout. One hundred and fifty days later, Bourbon County Stout was born-A liquid as dark and dense as a black hole with a thick foam the color of bourbon barrels. The nose is a mix of charred oak, vanilla,carmel and smoke. One sip has more flavor than your average case of beer. It overpowers anything in the room.",
                        Type = "American Double / Imperial Stout",
                        ABV = 13.8,
                        IBU = 60,
                        Image = "https://static1.squarespace.com/static/55f58dcde4b0f0037bc07471/t/565c7492e4b0b80773ac8963/1448899733600/?format=750w"
                    },
                   
                    new Beer()
                    {
                        Name = "60 Minute IPA",
                        Brewery = "Dogfish Head Craft Brewery",
                        Description = "60 Minute IPA is continuously hopped -- more than 60 hop additions over a 60-minute boil. (Getting a vibe of where the name came from?) 60 Minute is brewed with a slew of great Northwest hops. A powerful but balanced East Coast IPA with a lot of citrusy hop character, it's the session beer for hardcore enthusiasts!",
                        Type = "American IPA",
                        ABV = 6.0,
                        IBU = 60,
                        Image = "http://docvmp.com/wp-content/uploads/2012/10/60ipa.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Sierra Nevada Pale Ale",
                        Brewery = "Sierra Nevada Brewing Co.",
                        Description = "The beginning. A classic. Our most popular beer. Pale Ale began as a home brewer’s dream, grew into an icon, and inspired countless brewers to follow a passion of their own. Its unique piney and grapefruit aromas from the use of whole-cone American hops have fascinated beer drinkers for decades and made this beer a classic, yet it remains new, complex and surprising to thousands of beer drinkers every day. It is—as it always has been—all natural, bottle conditioned and refreshingly bold.",
                        Type = "American Pale Ale",
                        ABV = 5.6,
                        IBU = 37,
                        Image = "https://www.cdn.sierranevada.com/sites/www.sierranevada.com/files/content/beers/pale-ale/paleale_0.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Stone IPA",
                        Brewery = "Stone Brewing",
                        Description = "By definition, an India pale ale is hoppier and higher in alcohol than its little brother, pale ale—and we deliver in spades. One of the most well-respected and best-selling IPAs in the country, this golden beauty explodes with tropical, citrusy, piney hop flavors and aromas, all perfectly balanced by a subtle malt character. This crisp, extra hoppy brew is hugely refreshing on a hot day, but will always deliver no matter when you choose to drink it.",
                        Type = "American IPA",
                        ABV = 6.9,
                        IBU = 71,
                        Image = "http://www.aperfectpint.net/wp-content/uploads/2011/03/stoneipa.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Sierra Nevada Torpedo Extra IPA",
                        Brewery = "Sierra Nevada Brewing Co.",
                        Description = "Sierra Nevada Torpedo Ale is a big American IPA; bold, assertive and full of flavor and aromas highlighting the complex citrus, pine and herbal character of whole-cone American hops.",
                        Type = "American IPA",
                        ABV = 7.2,
                        IBU = 65,
                        Image = "https://www.cdn.sierranevada.com/sites/www.sierranevada.com/files/content/beers/torpedoreg/sup-extra-ipa/torpedo2015a.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Stone Enjoy By IPA",
                        Brewery = "Stone Brewing",
                        Description = "You have in your hands a devastatingly fresh double IPA. While freshness is a key component of many beers - especially big, citrusy, floral IPAs - we've taken it further, a lot further, in this IPA. You see, we specifically brewed it NOT to last. We've not only gone to extensive lengths to ensure that you're getting this beer in your hands within an extraordinarily short window, we made sure that the Enjoy By date isn't randomly etched in tiny text somewhere on the label, to be overlooked by all but the most attentive of retailers and consumers. Instead, we've sent a clear message with the name of the beer itself that there is no better time than right now to enjoy this IPA.",
                        Type = "American Double / Imperial IPA",
                        ABV = 9.4,
                        IBU = 90,
                        Image = "https://c1.staticflickr.com/8/7448/16475816112_f429118f0e.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Arrogant Bastard Ale",
                        Brewery = "Arrogant Brewing",
                        Description = "At Arrogant Bastard Brewing Co., we believe that pandering to the lowest common denominator represents the height of tyranny—a virtual form of keeping the consumer barefoot and stupid. Brought forth upon an unsuspecting public in 1997, Arrogant Bastard Ale openly challenged the tyrannical overlords who were brazenly attempting to keep Americans chained in the shackles of poor taste. As the progenitor of its style, Arrogant Bastard Ale has reveled in its unprecedented and uncompromising celebration of intensity. There have been many nods to Arrogant Bastard Ale...even outright attempts to copy it...but only one can ever embody the true nature of Liquid Arrogance!",
                        Type = "American Strong Ale",
                        ABV = 7.2,
                        IBU = 100,
                        Image = "http://media.kansascity.com/static/django-media/ink/img/articles/aba_small.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Lagunitas Sucks (Brown Shugga' Substitute Ale)",
                        Brewery = "Lagunitas Brewing Company",
                        Description = "This beer is a 'cereal medley' of barley, rye, wheat, and oats. Full of complexishness from the 4 grains, then joyously dry-hopped for that big aroma and resinous flavor.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.0,
                        IBU = 63,
                        Image = "http://www.tastymug.com/wp-content/uploads/2013/04/Beer-of-the-Week-Lagunitas-Sucks-Brown-Shugga-Substitute.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Sierra Nevada Celebration Ale",
                        Brewery = "Sierra Nevada Brewing Company",
                        Description = "Sierra Nevada Celebration Ale represents a time honored tradition of brewing a special beer for the holiday season. There are generous portions of barley malts and fine whole hops of several varieties, creating a brew with a full, rich and hearty character.",
                        Type = "American IPA",
                        ABV = 6.8,
                        IBU = 65,
                        Image = "http://www.newschoolbeer.com/wp-content/uploads/2015/11/celebration-ale-glass.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Zombie Dust",
                        Brewery = "3 Floyds Brewing Co.",
                        Description = "This intensely hopped and gushing undead Pale Ale will be one’s only respite after the zombie apocalypse. Created with our marvelous friends in the comic industry. Formerly known as Cenotaph: A medium bodied single hop beer showcasing Citra hops from the Yakima Valley, USA.",
                        Type = "American Pale Ale",
                        ABV = 6.2,
                        IBU = 60,
                        Image = "https://i.pinimg.com/236x/58/7e/8c/587e8c34af0711602e5f91f37d1aba51--beer-art-best-beer.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "La Fin Du Monde",
                        Brewery = "Unibroue",
                        Description = "La Fin du Monde was developed through 18 months of research on a unique strain of yeast originating from Europe. It is brewed in honor of the intrepid European explorers who believed they had reached the 'end of the world' when they discovered North America ‘the new world’. This triple-style golden ale recreates the style of beer originally developed in the Middle Ages by trappist monks for special occasions and as such it was the first of its kind to be brewed in North America.",
                        Type = "Tripel",
                        ABV = 9.0,
                        IBU = 19,
                        Image = "https://c1.staticflickr.com/3/2454/4056653085_dd62ff06bc.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Ten FIDY Imperial Stout",
                        Brewery = "Oscar Blues Brewery",
                        Description = "This titanic, immensely viscous stout is loaded with inimitable flavors of chocolate-covered caramel and coffee and hide a hefty 65 IBUs underneath the smooth blanket of malt. Ten FIDY (10.5% ABV) is made with enormous amounts of two-row malt, chocolate malt, roasted barley,flaked oats and hops. Ten FIDY is the ultimate celebration of dark malts and boundary-stretching beer.",
                        Type = "Imperial Stout",
                        ABV = 10.5,
                        IBU = 65,
                        Image = "https://aleheads.files.wordpress.com/2010/03/ten-fidy.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "St. Bernardus Abt 12",
                        Brewery = "Brouwerij St. Bernardus NV",
                        Description = "The St. Bernardus Abt 12 is the pride of our stable, the nec plus ultra of our brewery. Abbey ale brewed in the classic ’Quadrupel’ style of Belgium’s best Abbey Ales. Dark with a full, ivory-colored head. It has a fruity aroma, full of complex flavours and excels because of its long bittersweet finish with a hoppy bite. Worldwide seen as one of the best beers in the world. It’s a very balanced beer, with a full-bodied taste and a perfect equilibrium between malty, bitter, and sweet. One of the original recipes from the days of license-brewing for the Trappist monks of Westvleteren.",
                        Type = "Quadrupel (Quad)",
                        ABV = 10.0,
                        IBU = 22,
                        Image = "https://s3.amazonaws.com/beertourprod/beers/pictures/000/000/073/original/St_Bernardus_Abt_12_900.jpg?1395129181"
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