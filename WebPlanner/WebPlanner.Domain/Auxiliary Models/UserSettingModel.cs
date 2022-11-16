using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPlanner.Domain.Entity;

namespace WebPlanner.Domain.Auxiliary_Models
{
    public class UserSettingModel
    {
        public UserSettingModel(int id, string? name, string? email, string? hashPassword, string? salt, 
            string? accountType, string? bio, string? uRL, string? location, string? userName)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.HashPassword = hashPassword;
            this.Salt = salt;
            this.AccountType = accountType;
            this.Bio = bio;
            this.URL = uRL;
            this.UserName = userName;
            this.Location = location;
        }
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
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
