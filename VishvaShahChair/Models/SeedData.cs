using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VishvaShahChair.Data;
using System;
using System.Linq;

namespace VishvaShahChair.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new VishvaShahChairContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<VishvaShahChairContext>>()))
            {
                // Look for any movies.
                if (context.Chair.Any())
                {
                    return;   // DB has been seeded
                }

                context.Chair.AddRange(
                    new Chair
                    {
                        Type = "Office chair",                      //1
                        Material = "Soft Material",
                        Color = "Black",
                        ErgonomicDesign = "Seat Height",
                        Accessories = "Caster Wheels",
                        Price = 100,
                        Ratings = 5
                    },

                    new Chair
                    {
                        Type = "Dining room chair",             //2
                        Material = "Wooden",
                        Color = "Brown",
                        ErgonomicDesign = "Reclining Angle",
                        Accessories = "Chair Cover",
                        Price = 95,
                        Ratings = 4
                    },

                    new Chair
                    {
                        Type = "Work chair",                //3
                        Material = "Soft Material",
                        Color = "Black",
                        ErgonomicDesign = "Reclining Angle",
                        Accessories = "Chair Cover",
                        Price = 75,
                        Ratings = 5
                    },

                    new Chair
                    {
                        Type = "Rocking chair",                 //4
                        Material = "Wood",
                        Color = "Brown",
                        ErgonomicDesign = "Back and head support",
                        Accessories = "Chair pads",
                        Price = 115,
                        Ratings = 3
                    },

                    new Chair
                    {
                        Type = "Kneeling chair",              //5
                        Material = "Flexible Materials",
                        Color = "Black",
                        ErgonomicDesign = "Seat height",
                        Accessories = "Chair Cover",
                        Price = 150,
                        Ratings = 5
                    },

                    new Chair
                    {
                        Type = "Dental chair",                  //6
                        Material = "Soft Material",
                        Color = "Black",
                        ErgonomicDesign = "Chair-side appliance",
                        Accessories = "Soft Seat",
                        Price = 500,
                        Ratings = 5
                    },

                    new Chair
                    {
                        Type = "Bean bag chair",                  //7
                        Material = "Fabric",
                        Color = "Red",
                        ErgonomicDesign = "Seat height",
                        Accessories = " Chair Cover",
                        Price = 40,
                        Ratings = 4
                    },

                    new Chair
                    {
                        Type = "Wooden chair",                  //8
                        Material = "Wood",
                        Color = "Gold browen",
                        ErgonomicDesign = "Back and head support",
                        Accessories = "Soft seat",
                        Price = 100,
                        Ratings = 2
                    },

                    new Chair
                    {
                        Type = "Gaming chair",              //9
                        Material = "high-end seat",
                        Color = "Black and Red",
                        ErgonomicDesign = "Seat height",
                        Accessories = " Cover",
                        Price = 175,
                        Ratings = 5
                    },

                    new Chair
                    {
                        Type = "Wheel chair",                  //10
                        Material = "Soft Material",
                        Color = "Black",
                        ErgonomicDesign = "Seat",
                        Accessories = " Caster wheels",
                        Price = 30,
                        Ratings = 4
                    }

                    );
                context.SaveChanges();
            }
        }
    }
}
