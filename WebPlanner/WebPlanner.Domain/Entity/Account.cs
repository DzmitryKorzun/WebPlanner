using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace WebPlanner.Domain.Entity
{
    public class Account
    {
        public Account() { }
        public Account(int id, string? name, string? email, string? hashPassword, string? salt, string? accountType, 
            string? bio, string? uRL, string? location, string? userName)
        {
            Id = id;
            Name = name;
            Email = email;
            HashPassword = hashPassword;
            Salt = salt;
            AccountType = accountType;
            Bio = bio;
            URL = uRL;
            Location = location;
            UserName = userName;
        }

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? HashPassword { get; set; }
        public string? Salt { get; set; }
        public string? AccountType { get; set; }
        public string? Bio { get; set; }
        public string? URL { get; set; }
        public string? Location { get; set; }
        public string? UserName { get; set; }
    }
}
