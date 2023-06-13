using isk.GeneralAPI.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace isk.GeneralAPI.DAL
{
    public class IskContext : DbContext
    {
        public IskContext(DbContextOptions<IskContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Database seeding
            SeedUsers(modelBuilder);
        }

        public static readonly ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            var user1 = new User()
            {
                Id = Guid.NewGuid(),
                Country = "The Netherlands",
                CreatedBy = "db seed",
                CreatedOn = DateTime.UtcNow,
                Email = "michael@sample.com",
                FirstName = "Michael",
                LastName = "Knicks",
                HomeTown = "Home city",
                UserId = "5edd57723441370014991279"
            };
            modelBuilder.Entity<User>()
                .HasData(user1);
        }
    }
}
