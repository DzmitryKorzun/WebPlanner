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
