using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class User
    {
        private static int currentUserId = 1;
        public int UserID { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public User(string userName, string password, string role)
        {
            UserID = currentUserId++;
            UserName = userName;
            Password = password;
            Role = role;
        }

        public void Register(List<User> users)
        {
            users.Add(this);
            Console.WriteLine($"{UserName} has been registered successfully with UserID: {UserID}");
        }
    }
}
