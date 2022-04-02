using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PratamaHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();
                if (!context.Roles.Any())
                {
                    context.Roles.AddRange(new Role()
                    {
                        name = "General Manager"
                    },
                    new Role()
                    {
                        name = "Receptionist"
                    },
                    new Role()
                    {
                        name = "Non-Receptionist"
                    });
                    context.SaveChanges();
                }

                if (!context.Employees.Any())
                {
                    context.Employees.AddRange(new Employee()
                    {
                        id = "07072000",
                        name = "Yoga Pratama",
                        address = "Ciamis",
                        email = "yhepra@gmail.com",
                        password = "20000707",
                        //role = 
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
