using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestWPF.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string UserName { get; set; } = null!;

        [Column(TypeName = "nvarchar(20)")]
        public string Password_ { get; set; } = null!;



        public User(string username)
        {
            UserName = username;
        }

        public User(string username, string password)
        {
            UserName = username;
            Password_ = password;
        }
            
        public User(int userId)
        {
            UserId = userId;
        }

        public override string ToString()
        {
            return $"{UserId}        {UserName}";
        }
    }

    public class UserBuilder
    {
        private int UserId;       
        private string Username;
        private string Password;

        public UserBuilder setUserName(string username)
        {
            Username = username;
            return this;
        }

        public UserBuilder setPassword(string password)
        {
            Password = password;
            return this;
        }

        public User Build()
        {
            return new User(Username, Password);
        }
    }

}
