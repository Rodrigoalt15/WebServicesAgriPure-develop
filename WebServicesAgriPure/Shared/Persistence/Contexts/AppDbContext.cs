using Microsoft.EntityFrameworkCore;
using WebServicesAgriPure.AgriPure.Domain.Models;
using WebServicesAgriPure.Security.Domain.Models;

namespace WebServicesAgriPure.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserPlant> UserPlants { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //PLANTS
            builder.Entity<Plant>().ToTable("Plants");
            builder.Entity<Plant>().HasKey(p => p.Id);
            builder.Entity<Plant>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Plant>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Plant>().Property(p => p.Image).IsRequired().HasMaxLength(500);
            builder.Entity<Plant>().Property(p => p.Scientifistname).IsRequired().HasMaxLength(100);
            builder.Entity<Plant>().Property(p => p.Variety).IsRequired().HasMaxLength(30);
            builder.Entity<Plant>().Property(p => p.InfolandType).IsRequired().HasMaxLength(500);
            builder.Entity<Plant>().Property(p => p.Ph).IsRequired();
            builder.Entity<Plant>().Property(p => p.InfoDistanceBetween).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.DistancePlants).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.InfoIdealDepth).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.Depth).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.InfoWeatherConditions).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.Weather).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.InfoFertFumig).IsRequired().HasMaxLength(550);
            builder.Entity<Plant>().Property(p => p.IntervaleFert).IsRequired();
            builder.Entity<Plant>().Property(p => p.IntervaleFumig).IsRequired();
            builder.Entity<Plant>().Property(p => p.SavePlant);
            
            //PLOTS
            builder.Entity<Plot>().ToTable("Plots");
            builder.Entity<Plot>().HasKey(p => p.Id);
            builder.Entity<Plot>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Plot>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Plot>().Property(p => p.Area).IsRequired();
            builder.Entity<Plot>().Property(p => p.Detail).HasMaxLength(120);
            builder.Entity<Plot>().Property(p => p.Quantity).IsRequired();
            
            
            // Constraints
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => 
                p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => 
                p.Username).IsRequired().HasMaxLength(30);
            builder.Entity<User>().Property(p => p.FirstName).IsRequired();
            builder.Entity<User>().Property(p => p.LastName).IsRequired();


            //USERPLANTS
            builder.Entity<UserPlant>().ToTable("UserPlants");
            builder.Entity<UserPlant>().HasKey(up => new { up.UserId, up.PlantId });
            builder.Entity<UserPlant>().HasOne(up => up.User).WithMany(u => u.SavedPlants).HasForeignKey(up => up.UserId);
            builder.Entity<UserPlant>().HasOne(up => up.Plant).WithMany(p => p.SavedByUsers).HasForeignKey(up => up.PlantId);
        }
    }
}
