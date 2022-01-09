using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DL
{
    // Need to re-write seed after BL/DL complete
    public class Seed
    {
        public static async Task SeedReservationData(DataContext context)
        {
            if (context.Reservations.Any()) return;
            var carList = new List<Vehicle>();
            var car = new Vehicle
            {
                make = "Subaru",
                model = "WRX", 
                licensePlate = "FA20F",
                state = "Colorado"
            };            
            carList.Add(car);
            var carList2 = new List<Vehicle>();
            var car2 = new Vehicle
            {
                make = "Honda",
                model = "S2000", 
                licensePlate = "S2K",
                state = "Colorado"
            };            
            carList2.Add(car2);
            var reservations = new List<Reservation>
            {
                new Reservation
                {
                    Spot = new Spot
                    {
                        Lot = new Lot
                        {
                            name = "Lot One",
                            contactInfo = new ContactInfo
                            {
                                countryCode = 1,
                                phone = "1593577895",
                                address = new Address
                                {
                                    line1 = "123 Fake st",
                                    line2 = "",
                                    city = "Tyler",
                                    state = "TX",
                                    zip = "30358"
                                }
                            },
                            Spots = new List<Spot>()
                        },
                        number = 1,
                        Reservation = new List<Reservation>()
                    },
                    User = new User
                    {
                         fName = "Timmy",
                        lName = "Smith",
                        DoB = new DateTime(1996, 1, 1),
                        vehicles = carList,
                        Reservations = new List<Reservation>(),
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "7894561235",
                            address = new Address
                            {
                                line1 = "123 Fake st",
                                line2 = "",
                                city = "Denver",
                                state = "Colorado",
                                zip = "30358"
                            }
                        },
                        emergencyName = "Jimmy Smith",
                        emergencyContact = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "1237894565",
                            address = new Address
                            {
                                line1 = "4563 Test st",
                                line2 = "",
                                city = "Austin",
                                state = "TX",
                                zip = "58963"
                            }
                        },
                    },
                    date = new DateTime(2022, 4, 5),
                    description = "",
                    review = "",
                },
                new Reservation
                {
                    Spot = new Spot
                    {
                        Lot = new Lot
                        {
                            name = "Lot One",
                            contactInfo = new ContactInfo
                            {
                                countryCode = 1,
                                phone = "1593577895",
                                address = new Address
                                {
                                    line1 = "123 Fake st",
                                    line2 = "",
                                    city = "Tyler",
                                    state = "TX",
                                    zip = "30358"
                                }
                            },
                            Spots = new List<Spot>()
                        },
                        number = 2,
                        Reservation = new List<Reservation>()
                    },
                    User = new User
                    {
                        fName = "Robby",
                        lName = "Philips",
                        DoB = new DateTime(2000, 10, 5),
                        vehicles = carList2,
                        Reservations = new List<Reservation>(),
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "4569637418",
                            address = new Address
                            {
                                line1 = "123 False st",
                                line2 = "",
                                city = "Clifton",
                                state = "Colorado",
                                zip = "81520"
                            }
                        },
                        emergencyName = "Bobby Tables",
                        emergencyContact = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "7458963210",
                            address = new Address
                            {
                                line1 = "999 Test st",
                                line2 = "",
                                city = "Fruita",
                                state = "Colorado",
                                zip = "81521"
                            }
                        },
                    },
                    date = new DateTime(2023, 1, 1),
                    description = "",
                    review = "",
                }
            };
            await context.Reservations.AddRangeAsync(reservations);
            await context.SaveChangesAsync();
        }
        public static async Task SeedUserData(DataContext context)
        {
            if (context.Users.Any()) return;
            var carList = new List<Vehicle>();
            var car = new Vehicle
            {
                make = "Subaru",
                model = "WRX", 
                licensePlate = "FA20F",
                state = "Colorado"
            };            
            carList.Add(car);
            var carList2 = new List<Vehicle>();
            var car2 = new Vehicle
            {
                make = "Honda",
                model = "S2000", 
                licensePlate = "S2K",
                state = "Colorado"
            };            
            carList2.Add(car2);
            var users = new List<User>
            {
                new User
                {
                    fName = "Timmy",
                    lName = "Smith",
                    DoB = new DateTime(1996, 1, 1),
                    vehicles = carList,
                    Reservations = new List<Reservation>(),
                    contactInfo = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "7894561235",
                        address = new Address
                        {
                            line1 = "123 Fake st",
                            line2 = "",
                            city = "Denver",
                            state = "Colorado",
                            zip = "30358"
                        }
                    },
                    emergencyName = "Jimmy Smith",
                    emergencyContact = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "1237894565",
                        address = new Address
                        {
                            line1 = "4563 Test st",
                            line2 = "",
                            city = "Austin",
                            state = "TX",
                            zip = "58963"
                        }
                    },
                },
                new User
                {
                    fName = "Robby",
                    lName = "Philips",
                    DoB = new DateTime(2000, 10, 5),
                    vehicles = carList2,
                    Reservations = new List<Reservation>(),
                    contactInfo = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "4569637418",
                        address = new Address
                        {
                            line1 = "123 False st",
                            line2 = "",
                            city = "Clifton",
                            state = "Colorado",
                            zip = "81520"
                        }
                    },
                    emergencyName = "Bobby Tables",
                    emergencyContact = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "7458963210",
                        address = new Address
                        {
                            line1 = "999 Test st",
                            line2 = "",
                            city = "Fruita",
                            state = "Colorado",
                            zip = "81521"
                        }
                    },
                },
            };
            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        public static async Task SeedSpotData(DataContext context)
        {
            if (context.Spots.Any()) return;
            var spots = new List<Spot>
            {
                new Spot
                {
                    Lot = new Lot
                    {
                        name = "Lot One",
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "1593577895",
                            address = new Address
                            {
                                line1 = "123 Fake st",
                                line2 = "",
                                city = "Tyler",
                                state = "TX",
                                zip = "30358"
                            }
                        },
                        Spots = new List<Spot>()
                    },
                    number = 1,
                    Reservation = new List<Reservation>()
                },
                new Spot
                {
                    Lot = new Lot
                    {
                        name = "Lot One",
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "1593577895",
                            address = new Address
                            {
                                line1 = "123 Fake st",
                                line2 = "",
                                city = "Tyler",
                                state = "TX",
                                zip = "30358"
                            }
                        },
                        Spots = new List<Spot>()
                    },
                    number = 2,
                    Reservation = new List<Reservation>()
                },
                new Spot
                {
                    Lot = new Lot
                    {
                        name = "Lot One",
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "1593577895",
                            address = new Address
                            {
                                line1 = "123 Fake st",
                                line2 = "",
                                city = "Tyler",
                                state = "TX",
                                zip = "30358"
                            }
                        },
                        Spots = new List<Spot>()
                    },
                    number = 3,
                    Reservation = new List<Reservation>()
                },
                new Spot
                {
                    Lot = new Lot
                    {
                        name = "Lot One",
                        contactInfo = new ContactInfo
                        {
                            countryCode = 1,
                            phone = "1593577895",
                            address = new Address
                            {
                                line1 = "123 Fake st",
                                line2 = "",
                                city = "Tyler",
                                state = "TX",
                                zip = "30358"
                            }
                        },
                        Spots = new List<Spot>()
                    },
                    number = 4,
                    Reservation = new List<Reservation>()
                },
            };
            await context.Spots.AddRangeAsync(spots);
            await context.SaveChangesAsync();
        }

        public static async Task SeedLotData(DataContext context)
        {
            if (context.Lots.Any()) return;
            var lots = new List<Lot>
            {
                new Lot
                {
                    name = "Lot One",
                    contactInfo = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "1593577895",
                        address = new Address
                        {
                            line1 = "123 Fake st",
                            line2 = "",
                            city = "Tyler",
                            state = "TX",
                            zip = "30358"
                        }
                    },
                    Spots = new List<Spot>(),
                },
                new Lot
                {
                    name = "Lot Two",
                    contactInfo = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "7569871236",
                        address = new Address
                        {
                            line1 = "789 False st",
                            line2 = "",
                            city = "Tyler",
                            state = "TX",
                            zip = "30358"
                        }
                    },
                    Spots = new List<Spot>(),
                },
                new Lot
                {
                    name = "Lot Three",
                    contactInfo = new ContactInfo
                    {
                        countryCode = 1,
                        phone = "5138469574",
                        address = new Address
                        {
                            line1 = "123 Test st",
                            line2 = "",
                            city = "Clifton",
                            state = "Colorado",
                            zip = "81520"
                        }
                    },
                    Spots = new List<Spot>(),
                }
            };
            await context.Lots.AddRangeAsync(lots);
            await context.SaveChangesAsync();
        }
    }
}