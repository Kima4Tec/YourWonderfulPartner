using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using YourWonderfulPartner.Data; // Adjust the namespace according to your project

namespace FakeUserGenerator
{
    public enum Hair 
    {
        Sort = 0,
        Blond = 1,
        Brun = 2,
        Rød = 3,
        Grå = 4,
        Lysebrun = 5,
        Mørkebrun = 6,
        Askeblond = 7,
        Mahogni = 8,
        Skaldet = 9
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Setup configuration to read from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .Build();

            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddDbContext<YWPContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .BuildServiceProvider();

            // Get the DbContext instance from the service provider
            using (var context = serviceProvider.GetService<YWPContext>())
            {
                AddFakeUsers(context);
            }
        }
        
        private static void AddFakeUsers(YWPContext context)
        {
            // Read all postcodes from the file into a list
            var postcodes = File.ReadAllLines("postnr.txt").ToList();

            // Read image data from file
            byte[] pictureData = File.ReadAllBytes("RandomMan.jpg");

            // Convert image data to Base64 data URL (optional, for usage elsewhere)
            string mimeType = "image/jpeg"; // MIME type of the image
            string imageDataUrl = $"data:{mimeType};base64,{Convert.ToBase64String(pictureData)}";

            Random rnd = new Random();
            for (int i = 1; i <= 10; i++)
            {
                var year = rnd.Next(1960, 2006);
                var month = rnd.Next(1, 13); // Months are 1 to 12
                var day = rnd.Next(1, 29);   // Days are 1 to 28 to ensure a valid date

                context.User.Add(new YourWonderfulPartner.Model.UserData
                {
                    Name = $"fakeuser{i}",
                    Birthday = new DateOnly(year, month, day),
                    Sex = "Mand",
                    Height = 150 + rnd.Next(1, 50),
                    Weight = 50 + rnd.Next(1, 50),
                    Haircolor = GetRandomHairColor(),
                    Postcode = postcodes[rnd.Next(postcodes.Count)],
                    Email = $"fakeuser{i}@example.com",
                    UserName = $"fakeuser{i}",
                    Password = "Passw0rd",
                    PictureData = pictureData,
                    PictureName = "RandomMan"
                });
            }
            context.SaveChanges();
        Console.WriteLine("Fake users added to the database.");
        }

        private static string GetRandomHairColor()
        {
            var values = Enum.GetValues(typeof(Hair));
            Random rnd = new Random();
            Hair randomHair = (Hair)values.GetValue(rnd.Next(values.Length));
            return randomHair.ToString();
        }
    }
}
