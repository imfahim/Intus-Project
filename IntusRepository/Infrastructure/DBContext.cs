using IntusRepository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntusRepository.Infrastructure
{
    public class DBContext : DbContext/*, IDesignTimeDbContextFactory<DBContext>*/
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<SubElement> SubElements { get; set; }
        public DBContext() : base()
        {
        }

        public DBContext(DbContextOptions options) : base(options)
        {
            //Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    IConfigurationRoot configuration = new ConfigurationBuilder()
            //       .SetBasePath(Directory.GetCurrentDirectory())
            //       .AddJsonFile("appsettings.json")
            //       .Build();
            //    var connectionString = configuration.GetConnectionString("IntusConnection");
            //    optionsBuilder.UseSqlServer(connectionString);
            //}
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.ApplyConfiguration(new BilateralMapping());
        //    modelBuilder.ApplyConfiguration(new GameMapping());
        //    modelBuilder.ApplyConfiguration(new UsersMapping());

        //    modelBuilder.Entity<UserGameNegotiation>()
        //       .HasIndex(new string[] { nameof(UserGameNegotiation.GameId), nameof(UserGameNegotiation.UserId), nameof(UserGameNegotiation.Dimension) }, "IX_UserGameNegotiation_GameId_UserId_Dimension_Index");

        //    modelBuilder.Entity<Game>()
        //        .HasIndex(new string[] { nameof(Game.GameId), nameof(Game.Status) }, "IX_Game_GameId_Status_Index");

        //    modelBuilder.Entity<GameSettings>()
        //        .HasIndex(new string[] { nameof(Game.GameId) }, "IX_GameSettings_GameId_Index");

        //    convertDateTimesToUtc(modelBuilder);

        //    base.OnModelCreating(modelBuilder);
        //}

        ///*
        // * Needed for dotnet ef cli commands to work
        // */
        //public ApiContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
        //    optionsBuilder.UseSqlServer("CONNECTION_STRING_GOES_HERE", sqlOpts =>
        //    {
        //        sqlOpts.EnableRetryOnFailure(
        //            maxRetryCount: 5,
        //            maxRetryDelay: TimeSpan.FromSeconds(30),
        //            errorNumbersToAdd: null);
        //    });

        //    return new ApiContext(optionsBuilder.Options);
        //}

        //private void convertDateTimesToUtc(ModelBuilder modelBuilder)
        //{
        //    var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
        //        v => v.ToUniversalTime(),
        //        v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        //    var nullableDateTimeConverter = new ValueConverter<DateTime?, DateTime?>(
        //        v => v.HasValue ? v.Value.ToUniversalTime() : v,
        //        v => v.HasValue ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);

        //    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        //    {
        //        if (entityType.IsKeyless)
        //        {
        //            continue;
        //        }

        //        foreach (var property in entityType.GetProperties())
        //        {
        //            if (property.ClrType == typeof(DateTime))
        //            {
        //                property.SetValueConverter(dateTimeConverter);
        //            }
        //            else if (property.ClrType == typeof(DateTime?))
        //            {
        //                property.SetValueConverter(nullableDateTimeConverter);
        //            }
        //        }
        //    }
        //}

    }

}
