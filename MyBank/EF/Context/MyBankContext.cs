using Microsoft.EntityFrameworkCore;
using MyBank.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.EF.Context
{
    internal class MyBankContext : DbContext
    {

        private static readonly string Server = "localhost";
        private static readonly string User = "sa";
        private static readonly string DBname = "BankDataBase";
        private static readonly string Password = "blog_6109";

        public DbSet<Client> Client { get; set; }

        public DbSet<Account> Account { get; set; }

        public DbSet<Extract> Extract { get; set; } 

        //public DbSet<BankAccountStatement> BankAccountStatement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseSqlServer(string.Format(
                    "Server={0};User Id={1};Database={2};Password={3};TrustServerCertificate=True;MultipleActiveResultSets=true",
                    Server,
                    User,
                    DBname,
                    Password));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
