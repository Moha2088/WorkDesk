using Microsoft.EntityFrameworkCore;
using DBTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace DBTestWPF.Data_Access
{
    public class MyDBContext : DbContext
    {
        private string connectionString;

        public DbSet<User> UsersWPF { get; set; } = null!;

        public MyDBContext()
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            connectionString = config.GetConnectionString("MyDBConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public void Del_All()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM USERSWPF", con);
                    SqlCommand cmd2 = new SqlCommand("DBCC CHECKIDENT ('USERSWPF', RESEED, 0)", con);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}