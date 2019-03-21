using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using bit285_assignment3_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace bit285_assignment3_api
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await Seed(services.GetRequiredService<BitDataContext>());
        }

        public static async Task Seed(BitDataContext context)
        {
            if (context.Users.Any())
            {
                return; //already has data, don't add any more test data
            }

            //  NuGet Package "Bogus" fake data generator
            Randomizer.Seed = new Random(8672042);
            //Activities
            var testActivities = new Faker<Activity>()
                .RuleFor(a => a.ActivityDate, f => f.Date.Past(1))
                .RuleFor(a => a.Type, f => f.PickRandom<ActivityType>());
            //Users
            var testUsers = new Faker<User>()
                .RuleFor(u => u.Activities, f => testActivities.Generate(f.Random.Number(15)))
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u=>u.Program, f=>f.PickRandom<ProgramType>())
                .RuleFor(u=>u.Password, f=>f.Internet.Password(8,true));
            var users = testUsers.Generate(100);

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }
    }
}
