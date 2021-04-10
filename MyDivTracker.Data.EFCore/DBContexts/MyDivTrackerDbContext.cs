using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace MyDivTracker.Data.EFCore.DBContexts
{
    public class MyDivTrackerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Dividend> Dividends { get; set; }
        public DbSet<Ticker> Ticker { get; set; }

        public MyDivTrackerDbContext(DbContextOptions<MyDivTrackerDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = _configuration.GetConnectionString(nameof(MyDivTrackerDbContext));
            options.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dividend>().ToTable(nameof(Dividend));
            modelBuilder.Entity<Account>().ToTable(nameof(Account));
            modelBuilder.Entity<Ticker>().ToTable(nameof(Ticker));

            modelBuilder.Entity<Dividend>()
                .Property(dividend => dividend.AmountGBP)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Dividend>()
                .HasOne(dividend => dividend.Ticker)
                .WithMany(ticker => ticker.Dividends)
                .IsRequired();

            modelBuilder.Entity<Dividend>()
                .HasOne(dividend => dividend.Account)
                .WithMany(account => account.Dividends)
                .IsRequired();

            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    Id = Guid.Parse("{DF1917D7-D66A-4AD6-B58A-847C99D9662F}"),
                    Name = "Vanguard S&S ISA",
                    Description = "S&S ISA With Vanguard",
                    IsIsa = true
                },
                new Account
                {
                    Id = Guid.Parse("{EF680A27-6B09-463A-8C75-25278938101F}"),
                    Name = "Trading 212 S&S ISA",
                    Description = "S&S ISA With Trading 212",
                    IsIsa = true
                },
                new Account
                {
                    Id = Guid.Parse("{6ADD380F-9AA8-489A-AFA3-BEA7F6F10D28}"),
                    Name = "Trading 212 General Acc.",
                    Description = "General Acc. with Trading 212",
                    IsIsa = false
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
