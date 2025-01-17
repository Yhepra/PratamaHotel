﻿using Microsoft.AspNetCore.Builder;
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
                        role = context.Roles.Where(x => x.id == 1).FirstOrDefault()
                    });
                    context.SaveChanges();
                }

                if (!context.RoomTypes.Any())
                {
                    context.RoomTypes.AddRange(new RoomType()
                    {
                        id = "SR",
                        name = "Singe Room",
                        price = 300000,
                        capacity = 1,
                        numberOfRooms = 1
                    }, new RoomType
                    {
                        id = "TR",
                        name = "Twin Room",
                        price = 400000,
                        capacity = 2,
                        numberOfRooms = 0
                    }, new RoomType
                    {
                        id = "DR",
                        name = "Double Room",
                        price = 450000,
                        capacity = 2,
                        numberOfRooms = 1
                    }, new RoomType
                    {
                        id = "FR",
                        name = "Family Room",
                        price = 600000,
                        capacity = 4,
                        numberOfRooms = 0
                    });
                    context.SaveChanges();
                }

                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new Room()
                    {
                        idRoom = "101",
                        roomType = context.RoomTypes.Where(x => x.id == "SR").FirstOrDefault()
                    },
                    new Room()
                    {
                        idRoom = "110",
                        roomType = context.RoomTypes.Where(x => x.id == "DR").FirstOrDefault()
                    }) ;
                    context.SaveChanges();
                }
            }
        }
    }
}
