using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BankingSystemAfDEMP
{
    public class DatabaseAccessCtx : DbContext
    {

        //Create connection with the Database via the Connection string.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KINOPOULOS\SQLEXPRESS;Initial Catalog = 2;Integrated Security = true;");

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<User> Users { get; set; }

    }
}