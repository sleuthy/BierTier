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
                        Name = "West Coast IPA",
                        Brewery = "Green Flash",
                        Description = "Assertive, grapefruit zest bitterness supported by notes of dark caramel from British Crystal malt, finishes floral with dry woodsy hop notes.",
                        Type = "Double IPA",
                        ABV = 8.1,
                        IBU = 95,
                        Image = "http://4.bp.blogspot.com/-9VJs39WtF-M/UIQ9-_bDz9I/AAAAAAAAFXg/CUz03X3KE10/s1600/Green+Flash+West+Coast+IPA.JPG"
                       
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
                        Name = "Kentucky Breakfast Stout",
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
                        Name = "Pale Ale",
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
                        Name = "Torpedo Extra IPA",
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
                        Name = "Lagunitas Sucks Brown Shugga' Substitute",
                        Brewery = "Lagunitas Brewing Company",
                        Description = "This beer is a 'cereal medley' of barley, rye, wheat, and oats. Full of complexishness from the 4 grains, then joyously dry-hopped for that big aroma and resinous flavor.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.0,
                        IBU = 63,
                        Image = "http://www.tastymug.com/wp-content/uploads/2013/04/Beer-of-the-Week-Lagunitas-Sucks-Brown-Shugga-Substitute.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Celebration Ale",
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
                    },
                    
                     new Beer()
                    {
                        Name = "Trappistes Rochefort 10",
                        Brewery = "Brasserie de Rochefort",
                        Description = "The top product from the Rochefort Trappist brewery. Dark color, full and very impressive taste. Strong plum, raisin, and black currant palate, with ascending notes of vinousness and other complexities.",
                        Type = "Quadrupel (Quad)",
                        ABV = 11.3,
                        IBU = 27,
                        Image = "https://s3.amazonaws.com/beertourprod/beers/pictures/000/000/064/original/Rochefort_10_trappist_beer_900.jpg.jpg?1391077043"
                    },
                   
                    new Beer()
                    {
                        Name = "Samuel Adams Boston Lager",
                        Brewery = "Boston Beer Company Samuel Adams",
                        Description = "Samuel Adams Boston Lager helped lead the American beer revolution, reviving a passion for full-bodied brews that are robust and rich with character. Since 1984, Samuel Adams Boston Lager has used only the finest hand-selected ingredients to create this perfectly balanced, complex and full-bodied original brew.",
                        Type = "Vienna Lager",
                        ABV = 4.9,
                        IBU = 30,
                        Image = "http://www.betterondraft.com/wp-content/uploads/2016/06/SABL_TBS-product-images-2013.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "A Little Sumpin' Sumpin' Ale",
                        Brewery = "Lagunitas Brewing Company",
                        Description = "Way smooth and silky with a nice wheaty-esque-ish-ness. Just the little sumpin’ sumpin’ we all need to kick Summer into full swing! Ingredients: Hops, Malt, Hops, Hops, Yeast, Hops, Water, and Hops.",
                        Type = "American Pale Wheat Ale",
                        ABV = 7.5,
                        IBU = 65,
                        Image = "https://365beers.files.wordpress.com/2010/08/lagunitas-little-sumpin-ale.jpg?w=470"
                    },
                   
                    new Beer()
                    {
                        Name = "Lagunitas IPA",
                        Brewery = "Lagunitas Brewing Company",
                        Description = "Thanks for choosing to spend the next few minutes with this special homicidally hoppy ale. Savor the moment as the raging hop character engages the Imperial Qualities of the Malt Foundation in mortal combat on the battlefield of your palate!",
                        Type = "American IPA",
                        ABV = 6.2,
                        IBU = 46,
                        Image = "http://s3.media.squarespace.com/production/840157/9867282/_zikSxOpljDc/S3lNc9cnuHI/AAAAAAAAAY8/a1dU522Ut_s/s320/lagunitis+IPA.JPG"
                    },
                   
                    new Beer()
                    {
                        Name = "Fat Tire Amber Ale",
                        Brewery = "New Belgium Brewing",
                        Description = "Fat Tire’s unique flavor profile originates from the late 1930s, when local Belgian breweries aimed to satisfy the tastes of visiting British soldiers. English floral hops, subtle malt sweetness and spicy, fruity notes from Belgian yeast made for a balanced yet magical combination. These same characteristics are at the heart of Fat Tire. Classified as an Ameri-Belgo style ale by the revered Great American Beer Festival and World Beer Cup competitions, Fat Tire blends a fine malt presence, fresh herbal hop balance and a touch of fruity yeast to offer drinkers everywhere a timeless craft beer experience with a rare blend of balance and complexity.",
                        Type = "American Amber / Red Ale",
                        ABV = 5.2,
                        IBU = 22,
                        Image = "http://whichbeerglass.com/wp-content/uploads/2017/02/NewBelgiumFatTireAmberAle-212x300.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Nugget Nectar",
                        Brewery = "Tröegs Brewing Company",
                        Description = "Squeeze those hops for all they're worth and prepare to pucker up: Nugget Nectar Ale, will take hopheads to nirvana with a heady collection of Nugget, Warrior and Tomahawk hops. Starting with the same base ingredients of our flagship HopBack Amber Ale, Nugget Nectar intensifies the malt and hop flavors to create an explosive hop experience.",
                        Type = "American Amber / Red Ale",
                        ABV = 7.5,
                        IBU = 93,
                        Image = "http://www.troegs.com/wp-content/uploads/2015/08/nugget-productshot-new.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Imperial Russian Stout",
                        Brewery = "Stone Brewing",
                        Description = "Brewed in the authentic historical style of an Imperial Russian Stout, this ale is massive. Intensely aromatic (notes of anise, lack currants, coffee, roastiness and alcohol) and heavy on the palate, this brew goes where few can --- and fewer dare even try. The style originated from Czarist Russia's demand for ever thicker English stouts. Expect our version of this mysterious brew to pour like Siberian crude and taste even heavier!",
                        Type = "Russian Imperial Stout",
                        ABV = 10.6,
                        IBU = 60,
                        Image = "https://i.pinimg.com/236x/6c/bc/3f/6cbc3f7422ec49c1f3abe4338e104bb3--homebrewing-craft-beer.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Weihenstephaner Hefeweissbier",
                        Brewery = "Bayerische Staatsbrauerei Weihenstephan",
                        Description = "Our golden-yellow wheat beer, with its fine-poured white foam, smells of cloves and impresses consumers with its refreshing banana flavour. It is full bodied and with a smooth yeast taste. To be enjoyed at any time,goes excellently with fish and seafood, with spicy cheese and especially with the traditional Bavarian veal sausage. Brewed according to our centuries-old brewing tradition on the Weihenstephan hill.",
                        Type = "Hefeweizen",
                        ABV = 5.4,
                        IBU = 14,
                        Image = "https://www.weihenstephaner.de/fileadmin/user_upload/Dropdown/Sortiment/hefeweissbier.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Paulaner Hefe-Weißbier Naturtrüb",
                        Brewery = "Paulaner Brauerei GmbH & Co. KG",
                        Description = "The no. 1 Hefe-Weißbier in Germany and one of the world’s favourites. Naturally cloudy and shining silky gold in the glass under a really strong head of foam. At the first mouthful this Weißbier classic has a mild aroma of banana. Finer palates detect a trace of mango and pineapple and the balance between sweet and bitter. Beer connoisseurs appreciate the fine note of yeast and the mild but sparkling mix of aromas. It is a typical beergarden beer, which brings people together all over the world.",
                        Type = "Hefeweizen",
                        ABV = 5.5,
                        IBU = 12,
                        Image = "https://www.paulaner.com/sites/default/files/images/produkte/hwb_glas.png"
                    },
                   
                    new Beer()
                    {
                        Name = "Franziskaner Hefe-Weissbier / Weissbier Naturtrub",
                        Brewery = "Spaten-Franziskaner-Bräu",
                        Description = "The original fresh wheat beer taste. Franziskaner Hefe-Weißbier Naturtrüb is a natural and elegant Weissbier from Bavaria with a lush white foam. The copper golden wheat beer unfolds with an aromatic fragrance and harmonious banana and citrus fruits.",
                        Type = "Hefeweizen",
                        ABV = 5.0,
                        IBU = 12,
                        Image = "https://beergatherer.files.wordpress.com/2012/02/franziskaner_weisse.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Bell's Oberon Ale",
                        Brewery = "Bell's Brewery, Inc.",
                        Description = "Bell's Oberon is a wheat ale fermented with Bell's signature house ale yeast, mixing a spicy hop character with mildly fruity aromas. The addition of wheat malt lends a smooth mouthfeel, making it a classic summer beer.",
                        Type = "American Pale Wheat Ale",
                        ABV = 5.8,
                        IBU = 10,
                        Image = "https://www.bellsbeer.com/sites/default/files/brands/Oberon_WebPic_736X736.png"
                    },
                   
                    new Beer()
                    {
                        Name = "312 Urban Wheat",
                        Brewery = "Goose Island Beer Co.",
                        Description = "Crisp, bright flavor shines like city lights on Lake Michigan. Hazy and unfiltered, our award-winning Urban Wheat Ale's flavor flows from start to finish.",
                        Type = "American Pale Wheat Ale",
                        ABV = 4.2,
                        IBU = 18,
                        Image = "https://www.handfamilycompanies.com/filebin/images/product_images/Goose-312_wheat.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Dale's Pale Ale",
                        Brewery = "Oskar Blues Brewery",
                        Description = "This voluminously hopped mutha delivers a hoppy nose and assertive-but-balanced flavors of pale malts and citrusy floral hops from start to finish. Oskar Blues launched its canning ops in 2002, brewing and hand-canning Dale’s Pale Ale in the Lyons, Colorado, brewpub. America’s first-craft-canned mountain pale is a hearty, critically acclaimed trailblazer that changed the way craft beer fiends perceive portable beer.",
                        Type = "American Pale Ale",
                        ABV = 6.5,
                        IBU = 65,
                        Image = "https://aleheads.files.wordpress.com/2010/03/dales-pale-ale.jpg"
                    },
                   
                    new Beer()
                    {
                        Name = "Cutaway IPA",
                        Brewery = "Tennessee Brew Works",
                        Description = "For beer lovers who stretch beyond the 12th fret, our well balanced RYE IPA strums with an obvious bouquet of grapefruit, tangerine and orange harmonies. For hop enthusiasts of all varieties, this headliner gets folks asking for encores daily.",
                        Type = "American IPA",
                        ABV = 6.0,
                        IBU = 70,
                        Image = "http://knoxbrewnews.com/images/tennesseebrewworks_cutawayipa.jpg?crc=3774922129"
                    },
                                       
                    new Beer()
                    {
                        Name = "Southern Wit",
                        Brewery = "Tennessee Brew Works",
                        Description = "If we had a frontman to our band of beers, it would be our Southern Wit. A Tennessee native with a charasmatic, citrusy way of introducing itself, this unfiltered Belgian white ale packs venues with its high notes of tangerine, pear and honey!",
                        Type = "Witbier",
                        ABV = 5.15,
                        IBU = 15,
                        Image = "https://lh3.googleusercontent.com/-LMIM6R1wo8Y/WLI2EKsFD7I/AAAAAAAAM9I/THWQqoovr28/s1600/IMG_20170225_193602-01.jpeg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Basil Ryeman",
                        Brewery = "Tennessee Brew Works",
                        Description = "This creamy and spicy farmhouse ale has been making a Grand Ole splash since it hit the beer scene. The thai basil, sourced from Bloombury Farms, and rye malts take center stage; offering complexity while remaining approachable. One can taste a variety of notes, with tones of pepper and fennel on the nose and pallate.",
                        Type = "Saison / Farmhouse Ale",
                        ABV = 8.0,
                        IBU = 28,
                        Image = "https://pbs.twimg.com/media/C7KuPUiU4AEB1Zg.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Extra Easy",
                        Brewery = "Tennessee Brew Works",
                        Description = "There are few brews that accentuate Tennessee livin' like our ESB. When one starts to sip this malt forward beer, with tones of apricots, peaches, plums, and caramel, you'll want to relax and appreciate the moment. So, listen to your heart, kick back with your family and friends, and treat yourself to a few of this fine craft beer.",
                        Type = "Extra Special / Strong Bitter (ESB)",
                        ABV = 5.25,
                        IBU = 39,
                        Image = "https://vignette2.wikia.nocookie.net/beer/images/5/53/TNBrewWorksExtraEasy.png/revision/latest?cb=20160912180555"
                    },
                                       
                    new Beer()
                    {
                        Name = "Sue",
                        Brewery = "Yazoo Brewing Company",
                        Description = "The south is famous for smoking everything. Why not beer? Sue is a big, rich, smoky malt bomb of a beer, with mellow smokiness coming from barley malts smoked with cherry wood, and assertive bitterness from Galena and Perle hops to cleanse the finish",
                        Type = "Baltic Porter",
                        ABV = 9.0,
                        IBU = 72,
                        Image = "https://scontent-amt2-1.cdninstagram.com/t51.2885-15/e35/19764507_447458042283122_6385977192119009280_n.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Dos Perros",
                        Brewery = "Yazoo Brewing Company",
                        Description = "Many Mexican beer styles today are descendants of old Austrian styles, from when Austria ruled Mexico in the late 19th century. Our Dos Perros is made with German Munich malt, English Pale malt, and Chocolate malt, and hopped with Perle and Saaz hops. To lighten the body, as many Mexican brewers do, we add a small portion of flaked maize. The result is a wonderfully bready malt aroma, balanced with some maize sweetness and a noble hop finish.",
                        Type = "American Brown Ale",
                        ABV = 3.5,
                        IBU = 21,
                        Image = "http://blogaboutbeer.com/wp-content/blogs.dir/1/files/2012/10/yazoo-dos-perros-ale2.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Sly Rye Porter",
                        Brewery = "Yazoo Brewing Company",
                        Description = "A rich, chocolaty English Porter with a clean finish. We use the finest floor-malted Maris Otter malts from England, the same malts used for the best single-malt scotch. A portion of malted rye gives a spicy, slightly dry finish.",
                        Type = "English Porter",
                        ABV = 5.7,
                        IBU = 28,
                        Image = "http://www.alereview.com/wp-content/uploads/2010/08/4880020103_932c1862dd_o-e1364414267566-224x300.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Hefeweizen",
                        Brewery = "Yazoo Brewing Company",
                        Description = "An authentic example of a Bavarian Hefeweizen. “Hefe” means cloudy or yeasty and “weizen” means wheat. This beer is made with mostly wheat and uses a true Hefeweizen yeast that gives it a fruity, banana aroma with just a hint of cloves. The tart finish makes this the perfect summer beer.",
                        Type = "Hefeweizen",
                        ABV = 5.0,
                        IBU = 13,
                        Image = "http://www.jbspourhouse.com/wp-content/uploads/2014/07/hefeweizen.png"
                    },
                                       
                    new Beer()
                    {
                        Name = "Thunder Ann",
                        Brewery = "Jackalope Brewing Company",
                        Description = "Thunder Ann came about after a massive google search trying to come up with a name that we thought could represent our American Pale Ale. That’s how we found out about a little lady name Sally Ann Thunder Ann Whirlwind Crockett. She was Davy Crockett’s wife (well, in the folklore, according to Wikipedia, he married someone named Mary) and she was a bad ass. Seriously. Look her up. We mulled it over and thought that Thunder Ann could also be a pretty great name for a beer.",
                        Type = "American Pale Ale",
                        ABV = 5.5,
                        IBU = 37,
                        Image = "https://pbs.twimg.com/media/BtQy0FpIQAAKNot.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Bearwalker Maple Brown Ale",
                        Brewery = "Jackalope Brewing Company",
                        Description = "Bearwalker was inspired by our brewmaster Bailey’s Vermont roots. Pure maple syrup is infused during the conditioning phase, and is noticeable from start to finish. Chocolate malts add roasted notes to the flavor and aroma. It is also more highly hopped than most browns to create a balanced, yet complex brew.",
                        Type = "American Brown Ale",
                        ABV = 5.1,
                        IBU = 32,
                        Image = "http://jackalopebrew.com/new/wp-content/uploads/2013/11/bearwalker-web-205x412.png"
                    },
                                       
                    new Beer()
                    {
                        Name = "Rompo Red Rye Ale",
                        Brewery = "Jackalope Brewing Company",
                        Description = "Rompo is a twist on an Irish red, using classic earthy UK hops and caramel malts. We gave it our own Tennessee take by adding flaked rye to the mash. Rompo is a very smooth drinking brew with notes of fruit and caramel, while the rye contributes a spicy and clean finish.",
                        Type = "Rye Beer / Red Ale",
                        ABV = 5.6,
                        IBU = 22,
                        Image = "http://beerstreetjournal.com/wp-content/uploads/Jackalope-Rompo.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Peanut Butter Milk Stout",
                        Brewery = "TailGate Beer",
                        Description = "Becoming a cult classic in, Nashville, the PBMS is a full bodied, velvety smooth Milk Stout. After fermentation is complete, we add peanut butter flavor to the beer. Giving just enough of that recognizable peanut butter flavor and aroma, but still maintaing a delicious, approachable Milk Stout.",
                        Type = "Milk / Sweet Stout",
                        ABV = 5.8,
                        IBU = 33,
                        Image = "http://www.camrgb.org/wp-content/uploads/2016/08/Peanut-Butter-Milk-Stout-300x300.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Homestyle",
                        Brewery = "Bearded Iris Brewing",
                        Description = "A soft, juicy IPA brewed with oats, and hopped singularly and intensely with Mosaic.",
                        Type = "American IPA",
                        ABV = 6.0,
                        IBU = 0,
                        Image = "http://www.lexbeerscene.com/images/blogs/03122017A.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Ruby Red American Ale",
                        Brewery = "Fat Bottom Brewing Co.",
                        Description = "Our flagship brew is a delicious red ale with a blend of rich, specialty malts that have been carefully chosen by our brewmaster, ensuring a robust flavor, without being overbearing. She’s perfectly balanced, and a real crowd pleaser! ",
                        Type = "American Amber / Red Ale",
                        ABV = 5.3,
                        IBU = 35,
                        Image = "https://i.pinimg.com/736x/fa/c6/7f/fac67f7fd17e1ada3601cb8d9797e0cb--ruby-red-craft-beer.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Miro Miel",
                        Brewery = "East Nashville Beer Works",
                        Description = "American Style Blonde Ale brewed with Pilsner malt and locally sourced honey. Gives a nice crisp, malty finish, refreshing and light brew.",
                        Type = "American Blonde Ale",
                        ABV = 5.1,
                        IBU = 15,
                        Image = "http://lanadelbeer.weebly.com/uploads/3/9/8/5/39850313/published/miro.jpeg?1486130019"
                    },
                                       
                    new Beer()
                    {
                        Name = "Le Freak",
                        Brewery = "Green Flash Brewing Co.",
                        Description = "Le Freak is the first-ever hybrid ale of its kind: the convergence of a Belgian-Style Trippel with an American Imperial IPA. This zesty Amarillo dry-hopped, bottle-conditioned marvel entices with fruity Belgian yeast aromatics and a firm, dry finish. Aromas of orange and passion fruit with sweet bready malts, and flavors of orange marmalade and citrus fruit pith. Experience a legendary beer.",
                        Type = "Belgian IPA",
                        ABV = 9.2,
                        IBU = 101,
                        Image = "https://constructiveconsumption.files.wordpress.com/2014/02/green-flash-le-freak.jpg?w=670"
                    },
                                       
                    new Beer()
                    {
                        Name = "Brown Shugga'",
                        Brewery = "Lagunitas Brewing Company",
                        Description = "Originally a failed attempt at a 1997 batch of Olde GnarlyWine Ale resulting in an all-new-beer-style we like to call…Irresponsible.",
                        Type = "American Strong Ale",
                        ABV = 9.8,
                        IBU = 51,
                        Image = "https://constructiveconsumption.files.wordpress.com/2014/02/lagunitas-brown-shugga.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Dawn of the Red",
                        Brewery = "Ninkasi Brewing Company",
                        Description = "Bursting with tropical notes, this Red IPA captures the bright complexity of El Dorado and Mosaic hops. An assertive hop presence is carried by a subtle caramel backbone, unearthing a beer that is flavorful and juicy.",
                        Type = "Red IPA",
                        ABV = 7.0,
                        IBU = 66,
                        Image = "http://nepascene.com/wp-content/uploads/2015/06/Ninkasi-Dawn-of-the-Red.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Total Domination IPA",
                        Brewery = "Ninkasi Brewing Company",
                        Description = "This decidedly balanced Northwest IPA celebrates our love of hops. A delightful blend of citrus and floral hop notes dominate the senses while a trio of malt adds a clean finish. Totally hoppy, totally drinkable; the name says it all.",
                        Type = "American IPA",
                        ABV = 6.7,
                        IBU = 81,
                        Image = "https://i.pinimg.com/736x/54/b2/fa/54b2fa713091ee25fb523d7cf1ea8ae9--best-beer-ipa.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Trippel Belgian Style Ale",
                        Brewery = "New Belgium Brewing",
                        Description = "Brewed with Pilsner and Munich malts, Trippel is classically smooth and complex, and sings with a high-note of sweet citrus before a pleasantly dry finish delivers a warm, strong boozy bite. Give Trippel a sip to get you smiling.",
                        Type = "Tripel",
                        ABV = 8.5,
                        IBU = 43,
                        Image = "http://wichitabeer.com/yahoo_site_admin/assets/images/NB_Trippel.19894446_std.png"
                    },
                                       
                    new Beer()
                    {
                        Name = "Abbey Belgian Style Ale",
                        Brewery = "New Belgium Brewing",
                        Description = "This garnet brown hued Belgian-style dubbel is strong on character and rich in flavor. Seven malts, including caramel Munich and chocolate, and a definitive Belgian yeast, waft off sweet, spicy aromas. Rich tones of chocolate and dark caramel mix with nuanced dried cherries, burnt sugar and figs. Sweet and roasty upfront, followed by a slightly bitter finish, Abbey is a lovely representation of the monastic beers of Belgium. Sip Abbey, and sip New Belgium’s tradition.",
                        Type = "Belgian Dubbel",
                        ABV = 7.0,
                        IBU = 20,
                        Image = "http://wichitabeer.com/yahoo_site_admin/assets/images/NB_Abbey.19894403_std.png"
                    },
                                       
                    new Beer()
                    {
                        Name = "1554",
                        Brewery = "New Belgium Brewing Company",
                        Description = "Born of a flood and centuries-old Belgian text, 1554 Enlightened Black Ale uses a light lager yeast strain and dark chocolaty malts to redefine what dark beer can be. In 1997, a Fort Collins flood destroyed the original recipe our researcher, Phil Benstein, found in the library. So Phil and brewmaster, Peter Bouckaert, traveled to Belgium to retrieve this unique style lost to the ages. Their first challenge was deciphering antiquated script and outdated units of measurement, but trial and error (and many months of in-house sampling) culminated in 1554, a highly quaffable dark beer with a moderate body and mouthfeel.",
                        Type = "Euro Dark / Black Lager",
                        ABV = 5.6,
                        IBU = 21,
                        Image = "https://i.pinimg.com/236x/d5/44/7b/d5447b7d46224e75af01fdedb2d5d243--light-beer-drank.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Overcast Espresso Stout",
                        Brewery = "Oakshire Brewing",
                        Description = "Overcast Espresso Stout is a dark, silky stout brewed with beans from a local Eugene coffee roaster. Rich, smooth and full of coffee flavor and aroma, this beer is quite nice on a gray or sunny day!",
                        Type = "American Stout",
                        ABV = 5.8,
                        IBU = 37,
                        Image = "https://i.pinimg.com/236x/92/c9/19/92c919b9e380afaba5afa907e3685d9e.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Oakshire Amber Ale",
                        Brewery = "Oakshire Brewing",
                        Description = "Originally homebrewed by Oakshire’s founders Jeff & Chris Althouse, our amber is an outstanding and versatile ale that is traditionally crafted with the highest quality ingredients. This American Amber Ale is brewed with 60 and 120 lovibond crystal malts, chocolate and roasted barley malts. This malt driven ale derives hop character from a first wort addition of crystal hops as well as flavor and aroma additions from Crystal and Cascade. A small amount of bitterness balances the malt body providing a clean, dry finish.",
                        Type = "American Amber / Red Ale",
                        ABV = 5.4,
                        IBU = 24,
                        Image = "https://i.pinimg.com/564x/7b/fa/94/7bfa94712fb20e92d7f4d40e7ae876b2.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Moo-Hoo Chocolate Milk Stout",
                        Brewery = "Terrapin Beer Company",
                        Description = "The Terrapin “Moo-Hoo” Chocolate Milk Stout proudly uses cocoa nibs and shells from Olive and Sinclair Chocolate Company to give this beer its great taste!",
                        Type = "Milk / Sweet Stout",
                        ABV = 6.0,
                        IBU = 30,
                        Image = "http://draftmag.com/file/beers/Terrapin_Moo-Hoo_2014-2.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "W-n-B Coffee Oatmeal Imperial Stout",
                        Brewery = "Terrapin Beer Company",
                        Description = "Black as night, this coffee stout is thick, rich and full of real coffee flavor. Brewed with a special blend of beans from all over the world developed and roasted specifically for Terrapin by our friends at Jittery Joe’s Coffee right here in Athens, Ga. This unique blend of coffee produces a robust and flavorful beer that will leave you asking why not beer for breakfast!",
                        Type = "American Double / Imperial Stout",
                        ABV = 9.4,
                        IBU = 50,
                        Image = "http://cdn.pastemagazine.com/www/articles/terrapin%20wake%20and%20bake%20%28Custom%29.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Hopsecutioner",
                        Brewery = "Terrapin Beer Company",
                        Description = "This Killer IPA earns its name by using six different types of hops while still remaining an aggressive well balanced beer.",
                        Type = "American IPA",
                        ABV = 7.3,
                        IBU = 71,
                        Image = "https://cdn.pastemagazine.com/www/system/images/photo_albums/ipa-tasting-2015/large/terrapin-hopsecutioner.jpg?1384968217"
                    },
                                       
                    new Beer()
                    {
                        Name = "Sweetwater 420 Extra Pale Ale",
                        Brewery = "SweetWater Brewing Company",
                        Description = "SweetWater 420 Extra Pale Ale, our most popular brew, is a tasty West Coast Style Pale Ale with a stimulating hop character and a crisp finish.",
                        Type = "American Pale Ale",
                        ABV = 5.4,
                        IBU = 41,
                        Image = "http://www.beveragejournalinc.com/new/images/easyblog_shared/SweetWaterWEB.jpg"
                    },
                                       
                    new Beer()
                    {
                        Name = "Sweetwater Blue",
                        Brewery = "SweetWater Brewing Company",
                        Description = "Sweetwater Blue is a unique light bodied ale enhanced with a hint of fresh blueberries. This euphoric experience begins with an appealing blueberry aroma and finishes as a surprisingly thirst-quenching ale.",
                        Type = "Fruit Beer",
                        ABV = 4.6,
                        IBU = 10,
                        Image = "https://i.pinimg.com/736x/1a/23/f3/1a23f35dd125589b09da79fa316791f2--medium-blue.jpg"
                    },

                    new Beer()
                    {
                        Name = "Red Handed",
                        Brewery = "Bearded Iris Brewing",
                        Description = "Double IPA w/ Amarillo, Simcoe, Citra, & Chinook, hits the glass bursting with a dankness and pithy citrus peel, conjuring up images of pulpy fruit juices. Traces of pine and sweeter tropical fruits linger in the background. On the tongue, this is a hop lover's dream, biting with grapefruit and orange rind that wavers very little. The aforementioned sweeter fruits, mango and guava primarily, provide a bit of balance before a resinous pine and dank herb return to strafe the taste buds with bitterness. The alcohol is virtually undetectable, making this entirely too easy to drink. So good, and a worthy adversary to the ridiculously hyped New England IPAs.",
                        Type = "American Double / Imperial IPA",
                        ABV = 7.5,
                        IBU = 0,
                        Image = "http://www.lexbeerscene.com/images/blogs/03052017.jpg"
                    },

                    new Beer()
                    {
                        Name = "Scatterbrain",
                        Brewery = "Bearded Iris Brewing",
                        Description = "This hazy Simcoe IPA is bursting with aromas of passionfruit and pine.",
                        Type = "American IPA",
                        ABV = 6,
                        IBU = 0,
                        Image = "https://scontent.cdninstagram.com/t51.2885-15/s640x640/sh0.08/e35/16463952_1828189970769776_5417553476659970048_n.jpg"
                    },

                    new Beer()
                    {
                        Name = "Otra Vez",
                        Brewery = "Sierra Nevada",
                        Description = "n our search for the perfect warm weather beer, we wanted something light bodied and thirst quenching, yet filled with complex and interesting flavors. We stumbled across the fruit of the prickly pear cactus, native to California. This tangy fruit is a great complement to the tart and refreshing traditional gose style beer. Otra Vez combines prickly pear cactus with a hint of grapefruit for a refreshing beer that will have you calling for round after round. Otra Vez!",
                        Type = "Gose",
                        ABV = 4.5,
                        IBU = 5,
                        Image = "https://www.cdn.sierranevada.com/sites/www.sierranevada.com/files/content/beers/otra-vez/otravez-bottle-pint2016.png"
                    },

                    new Beer()
                    {
                        Name = "Boddingtons Pub Ale",
                        Brewery = "Boddingtons Brewery",
                        Description = "Boddingtons is a medium-bodied English pale ale renowned for its golden color, distinctive creamy head, smooth body and easy drinking character.  It has a creamy, malty and slightly sweet flavor and features a clean, pleasant aftertaste.  In 1992, Boddingtons introduced the widget can and was one of the first beers to use this technology.  When Boddingtons is canned, the combination of the carbon dioxide and nitrogen needed to create the head of the beer is less than ideal.  The Draught Flow System inside of the widget can consists of a plastic, nitrogen-filled ball or widget that helps the carbon dioxide already dissolved in the beer form additional tiny bubbles.  This keeps the head stable and makes the beer as close to a draught brew as possible.",
                        Type = "Extra Special / Strong Bitter / English Pale Ale",
                        ABV = 4.6,
                        IBU = 0,
                        Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTOj8vg45K-6IaCp1gI33khKTE4DVtih3Wc9miPpWGoolA68dD3"
                    },

                     new Beer()
                    {
                        Name = "Icelandic Arctic Pale Ale",
                        Brewery = "Einstok Beer Company",
                        Description = "Brewed 60 miles south of the Arctic Circle, we balance three kinds of hops with pure Icelandic water to create an ale unlike any other. It can only be described as an Arctic Pale Ale and it’s truly one of a kind. Cascade hops give it American character, while Northern Brewer and Hallertau Tradition add just enough bitterness to make this ale refreshingly Icelandic – and to make everything else pale in comparison.",
                        Type = "Arctic Pale Ale",
                        ABV = 5.6,
                        IBU = 0,
                        Image = "https://thehitchhikersguidetobeer.files.wordpress.com/2016/01/img_0067_crop.jpg?w=265&h=400"
                    },

                    new Beer()
                    {
                        Name = "Coffee Stout",
                        Brewery = "Smith & Lentz Brewing",
                        Description = "Smith & Lentz's coffee stout. Smooth.",
                        Type = "Stout - American",
                        ABV = 5.5,
                        IBU = 0,
                        Image = "https://www.alcoholprofessor.com/wp-content/uploads/2016/01/kevin-gibson-sl-porter-e1452611139726.jpg"
                    },

                    new Beer()
                    {
                        Name = "Runaway IPA",
                        Brewery = "Renegade Brewing Company",
                        Description = "This take on a classic west-coast style IPA will not disappoint. With citrus and grapfrit notes on the nose, you get a small amount of pine coming through on the back palate. With its burst of refreshing juicy hop flavor with a clean dry finish, this beer is sure to satisfy any hop head.",
                        Type = "West Coast IPA",
                        ABV = 6,
                        IBU = 70,
                        Image = "http://www.romancingthefoam.com/images/Beer/Renegade-Runaway-IPA-IMG_0425.gif"
                    },

                    new Beer()
                    {
                        Name = "Covfefe",
                        Brewery = "Renegade Brewing Company",
                        Description = "A happy accident provided us with this fruit forward, sessionable oat ale. An entirely different mishap gave us the inspiration for the name. Grab a pint of this easy drinking summer beer, and ask your bartender to tell you the story.",
                        Type = "Oat Ale with Coffee / Golden Ale",
                        ABV = 5.8,
                        IBU = 41,
                        Image = "https://s3-media4.fl.yelpcdn.com/bphoto/133grs1wGjCms9WtcGKtlQ/348s.jpg"
                    },

                    new Beer()
                    {
                        Name = "Depravity",
                        Brewery = "Renegade Brewing Company",
                        Description = "The tradition of this beer goes back to post-Halloween 2011 when Brian bought some discounted candy. He decided to throw a bunch of peanut butter cups into a small batch of milk stout to see what would happen. The beer was such a hit, he decided to brew a full batch for NEW YEAR’S EVE. That’s right folks every year this coveted brew is released on DECEMBER 31!  Depravity (formerly Black Gold) has been a tradition every since.  Each keg has 1 lb of Reese’s Peanut Butter Cups and 1 lb of dehydrated peanut butter.",
                        Type = "Imperial Peanut Butter Cup Stout",
                        ABV = 11,
                        IBU = 57,
                        Image = "http://i1077.photobucket.com/albums/w478/EvilDave60/Mobile%20Uploads/2017-03/75C6C0F3-5FA0-42E9-844F-43556F5C4600_zpsqleaw9ex.jpg"
                    },

                    new Beer()
                    {
                        Name = "Hammer & Sickle",
                        Brewery = "Renegade Brewing Company",
                        Description = "Bronze Medal Winner at the 2013 Great American Beer Festival, Hammer and Sickle is sure to leave an impression. This roasty stout has hints of vanilla, coffee, and dark chocolate. The high bitterness creates a dry finish on a beer that could otherwise be sweet and boozy. Hammer and Sickle is now packaged in 4-pack 12 ounce cans and will soon become dictators of your beer fridge.",
                        Type = "Russian Imperial Stout",
                        ABV = 9,
                        IBU = 60,
                        Image = "http://renegadebrewing.com/wp-content/uploads/2013/04/Hammer-and-Sickle-small-849x1024.jpg"
                    },

                    new Beer()
                    {
                        Name = "Retrograde Red",
                        Brewery = "Falling Sky Brewing",
                        Description = "A classic NW hoppy red that intermingles hops and malt with deftly balance. Fruity hops rotate with rich malts in the aroma while orbiting a drinkable inclination of toasted malt and earthy-spicy hop flavor. Take me to a moon already!",
                        Type = "Red Ale / American Amber / Red",
                        ABV = 6.3,
                        IBU = 70,
                        Image = "http://68.media.tumblr.com/46f619eb9bba7dc8d7f43b0a71578f2d/tumblr_inline_ojj6k2APvI1tovnkl_1280.jpg"
                    },

                    new Beer()
                    {
                        Name = "Alphadelic IPA",
                        Brewery = "Hop Valley Brewing",
                        Description = "You can run, but you can't hide from the hops in this true Northwest IPA. Pretty golden yellow and aromatic, this IPA is brewed by hop lovers for hop lovers.",
                        Type = "American IPA",
                        ABV = 7.2,
                        IBU = 90,
                        Image = "http://craftcans.com/cards/big_cards/hvalphadelic.jpg"
                    },

                    new Beer()
                    {
                        Name = "Freak of Nature",
                        Brewery = "Wicked Weed Brewing",
                        Description = "The Freak of Nature is our San Francisco inspired hoppy monster. At 8% abv and who knows how many ibu’s, this beer is our shrine to the Hop. Absurd amounts of the big West Coast hops gives this beer its citrusy, weedy nose and big, dank flavor. We dry hop with 48lbs per batch, which is over 3lbs of hops per barrel. In keeping with the classic style of the West Coast double, sugar plays a large part in creating this dry and minimally bitter double IPA. The Freak is particularly pintable for the style, so if you dare to enter, we welcome you to the Freak Show.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.5,
                        IBU = 95,
                        Image = "http://beerstreetjournal.com/wp-content/uploads/Wicked-Weed-Freak-of-Nature-bottle.jpg"
                    },

                    new Beer()
                    {
                        Name = "Monkeynaut IPA",
                        Brewery = "Straight to Ale Brewing",
                        Description = "Albert. Able. Gordo. Miss Baker. Bonny. Goliath. Between 1948 and 1961 these primate pioneers and others bravely went where no man had ever gone before, paving the way for manned U.S. spaceflight. This hoppy little monkey of a beer is a tribute to those Simian heroes of yesteryear. It has a citrusy, floral hop aroma, a strong malt body and a crisp finish.",
                        Type = "American IPA",
                        ABV = 7.25,
                        IBU = 70,
                        Image = "https://whatsinmycooler.files.wordpress.com/2014/04/monkeynaut.jpg"
                    },

                    new Beer()
                    {
                        Name = "Space Dust IPA",
                        Brewery = "Elysian Brewing",
                        Description = "Space Dust, A Totally Nebular IPA. Great Western premium two-row, combined with c-15 and Dextri-Pils, give this beer a bright and galactic Milky Way hue. The hopping is pure starglow energy, with Chinook to bitter and late and dry additions of Citra and Amarillo. Space Dust is out of this world.",
                        Type = "American Double / Imperial IPA",
                        ABV = 8.2,
                        IBU = 73,
                        Image = "https://2.bp.blogspot.com/-gsUj3d-93Fg/WA_XNIdDURI/AAAAAAAAOUI/qfa3gnLZGzcd_VRfl2-Y1jv2cGYqbS9OQCLcB/s1600/Elysian%2BSpace%2BDust%2BIPA.jpg"
                    },

                    new Beer()      
                    {
                        Name = "Nashweizen",
                        Brewery = "Tennessee Brew Works",
                        Description = "Intonations of banana and clove on the nose and pallet finish with a tropical medley including melon, white grape and tangerine.",
                        Type = "Hefeweizen",
                        ABV = 5,
                        IBU = 35,
                        Image = "https://pbs.twimg.com/media/DFxdHF8VoAEeZ-w.jpg"
                    },

                    new Beer()      
                    {
                        Name = "Oktoberfest",
                        Brewery = "Yee-Haw Brewing Company",
                        Description = "A traditional, malty German amber lager, our Märzen Oktoberfest is one seasonal you won't want to miss. Munich malt is at the heart of this beer. You'll enjoy clean, rich and toasty flavors without sweetness thanks to an ever so slight hop bitterness. For your new fall favorite, just say...YEE-HAW!",
                        Type = "Marzen",
                        ABV = 5.7,
                        IBU = 18,
                        Image = "https://pbs.twimg.com/media/DJk3lenXoAE8Dsu.jpg"
                    },

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