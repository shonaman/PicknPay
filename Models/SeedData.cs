using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;

namespace PicknPay.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService <ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Heineken Lager Bottle 330ml", Description = "Brewed with passion for quality.",
                        Category = "Beer",
                        Price = 11
                    },
                     new Product
                     {
                         Name = "Castle Lager Beer Can 330ml",
                         Description = "Brewed under hot air.",
                         Category = "Beer",
                         Price = 14
                     },
                      new Product
                      {
                          Name = "Original Iced Margarita 300 ml",
                          Description = "Mixture of tequila, orange liqueur, and lime juice.",
                          Category = "Ciders & Coolers",
                          Price = 36
                      },
                       new Product
                       {
                           Name = "Klein Constantia KC Rose 750ml",
                           Description = "KLEIN CONSTANTIA PRODUCES a premium Estate range, an accessible " +
                           "and easy-drinking KC range and, of course, " +
                           "our iconic natural sweet dessert wine.",
                           Category = "Rose Wine",
                           Price = 75
                       },
                        new Product
                        {
                            Name = "Douglas Green Sprizzo Rose 750 ml",
                            Description = "Variety and value meet in Douglas Green's vibrant diversity range. Douglas " +
                            "Green knew that making great wine is a combination of good quality fruit, " +
                            "hands-on skill and the instincts of the winemaker.",
                            Category = "Rose Wine",
                            Price = 67
                        },
                         new Product
                         {
                             Name = "Swartland Sweet Red Jerepigo 750ml",
                             Description = "Swartland Winery is situated north of Cape Town, near the town of Malmesbury in the Swartland, a popular wine destination. " +
                             "The vineyards benefit from the constant cool breezes that blow off the Atlantic Ocean, effectively sustaining the many microclimates, while " +
                             "the proximity to mountain ranges adds it own dimension to the physical character of the fruit. Over the past 68 years this well known winery has " +
                             "changed from a cooperative cellar into a wine company with three business units that offer our clients an all-in-one wine experience.",
                             Category = "Dessert Wine",
                             Price = 59
                         },
                          new Product
                          {
                              Name = "Bushmills Blackbush Irish Whiskey 750ml",
                              Description = "We've been here for 400 years and don't plan on leaving soon. We often say that we're not necessarily " +
                              "the best because we're the oldest, just that we're the oldest because we're the best.",
                              Category = "Spirits",
                              Price = 349
                          },
                           new Product
                           {
                               Name = "Glenmorangie Lasanta Single Malt 750ml",
                               Description = "The nose is creamy and of caramel, crème anglaise and chocolate raisins, quite dry with notes of mixed " +
                               "sweet spices. The mouth feel is very thick as you chew through honeyed raisins. There is a little sweet beeswax, melted " +
                               "vanilla ice cream as the sherry weaves gently through the palate, a very buttery expression. Much more of that honey in " +
                               "the creamy finish, it has a slight oaky dryness and a dusting of cocoa powder.",
                               Category = "Spirits",
                               Price = 679
                           },
                            new Product
                            {
                                Name = "Veuve Clicquot Brut Rose 750ml",
                                Description = "Made using 50 to 60 different crus, the cuvee is based on Brut Yellow Label's traditional blend:" +
                                " 50 to 55% Pinot Noir, 15 to 20% Pinot Meunier, and 28 to 33% Chardonnay. The blend includes a particularly " +
                                "high percentage (25-35%, sometimes 40%) of reserve wines originating from several harvests (usually 5 or 6)," +
                                " which ensures the consistency of the house style. The reserve wines, some of which are 9 years old, are kept " +
                                "separately depending on the origin of the crus and the years in which the wines were produced. This blend is " +
                                "completed with 12% of red wines using red grapes especially raised and selected to give a marvellous balance " +
                                "to this rosé.",
                                Category = "Mcc Champagne and Sparkling Wwine",
                                Price = 1100
                            }
                    );
                context.SaveChanges();
            }
        }
    }
}
