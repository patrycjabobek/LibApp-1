using System;
using System.Linq;
using LibApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LibApp.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                SeedMembershipTypes(context);

                SeedBooks(context);

                SeedGenres(context);

                SeedCutomers(context);

            }
        }

        private static void SeedMembershipTypes(ApplicationDbContext context)
        {

            if (context.MembershipTypes.Any())
            {
                Console.WriteLine("Database has already been seeded with MemberShipTypes data");
                return;
            }


            context.MembershipTypes.AddRange(
                    new MembershipType
                    {
                        Id = 1,
                        Name = "Pay as You Go",
                        SignUpFee = 0,
                        DurationInMonths = 0,
                        DiscountRate = 0
                    },
                    new MembershipType
                    {
                        Id = 2,
                        Name = "Monthly",
                        SignUpFee = 30,
                        DurationInMonths = 1,
                        DiscountRate = 10
                    },
                    new MembershipType
                    {
                        Id = 3,
                        Name = "Quaterly",
                        SignUpFee = 90,
                        DurationInMonths = 3,
                        DiscountRate = 15
                    },
                    new MembershipType
                    {
                        Id = 4,
                        Name = "Yearly",
                        SignUpFee = 300,
                        DurationInMonths = 12,
                        DiscountRate = 20
                    });

            context.SaveChanges();
        }
        private static void SeedBooks(ApplicationDbContext context)
        {

            if (context.Books.Any())
            {
                Console.WriteLine("Database has already been seeded with Books data");
                return;
            }
            context.Books.AddRange(
                 new Book
                 {
                     Name = "Harry Potter",
                     AuthorName = "J.K Rowling",
                     GenreId = 1,
                     DateAdded = new DateTime(),
                     NumberAvailable = 17,
                     NumberInStock = 18,
                     ReleaseDate = new DateTime(1997, 7, 15)
                 },
                 new Book
                 {
                     Name = "Hamlet",
                     AuthorName = "William Shakespeare",
                     GenreId = 2,
                     DateAdded = new DateTime(),
                     NumberAvailable = 12,
                     NumberInStock = 13,
                     ReleaseDate = new DateTime(1890, 3, 11)
                 },
                 new Book
                 {
                     Name = "Złodziejska Magia",
                     AuthorName = "Trudi Canavan",
                     GenreId = 1,
                     DateAdded = new DateTime(),
                     NumberAvailable = 17,
                     NumberInStock = 17,
                     ReleaseDate = new DateTime(2013, 1, 29)
                 }
            );
            context.SaveChanges();

        }

        private static void SeedGenres(ApplicationDbContext context)
        {

            if (context.Genre.Any())
            {
                Console.WriteLine("Database has already been  seeded with Genre data");
                return;
            }
            context.Genre.AddRange(
                 new Genre
                 {
                     Id = 1,
                     Name = "Fantasy"
                 },
                 new Genre
                 {
                     Id = 2,
                     Name = "Drama"
                 },
                 new Genre
                 {
                     Id = 3,
                     Name = "Thriller"
                 },
                 new Genre
                 {
                     Id = 4,
                     Name = "Comedy"
                 },
                 new Genre
                 {
                     Id = 5,
                     Name = "Horrow"
                 },
                 new Genre
                 {
                     Id = 6,
                     Name = "Sci-Fi"
                 }
            );
            context.SaveChanges();

        }

        private static void SeedCutomers(ApplicationDbContext context)
        {

            if (context.Customers.Any())
            {
                Console.WriteLine("Database has already been seeded with Customers data");
                return;
            }

            context.Customers.AddRange(
                new Customer
                {
                    Name = "Anna Kowalska",
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 2,
                    Birthdate = new DateTime(1980, 3, 12)
                },
                new Customer
                {
                    Name = "Marian Nowak",
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 3,
                    Birthdate = new DateTime(1955, 5, 23)
                },
                new Customer
                {
                    Name = "Olaf Grzebień",
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 2,
                    Birthdate = new DateTime(2000, 3, 22)
                },
                new Customer
                {
                    Name = "Małgorzata Ptak",
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 1,
                    Birthdate = new DateTime(1997, 11, 30)
                },
                new Customer
                {
                    Name = "Ziemowit Wałęsa",
                    HasNewsletterSubscribed = true,
                    MembershipTypeId = 4,
                    Birthdate = new DateTime(1978, 12, 26)
                },
                new Customer
                {
                    Name = "Stanisław Ząb",
                    HasNewsletterSubscribed = false,
                    MembershipTypeId = 1,
                    Birthdate = new DateTime(1999, 9, 18)
                }

            );
            context.SaveChanges();

        }
    }
}