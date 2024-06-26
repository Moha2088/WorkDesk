﻿using Microsoft.EntityFrameworkCore;
using WorkDesk.Models;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Windows;

namespace WorkDesk.Data_Access
{
    public class MyDBContext : DbContext
    {
        private string connectionString;

        public DbSet<User> UsersWPF { get; set; } = null!;

        public DbSet<Team> Team { get; set; } = null!;

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

        public void Del_All_Teams()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM TEAM", con);
                    SqlCommand cmd2 = new SqlCommand("DBCC CHECKIDENT ('TEAM', RESEED, 0)", con);
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