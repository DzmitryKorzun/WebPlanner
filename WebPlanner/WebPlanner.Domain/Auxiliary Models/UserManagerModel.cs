using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPlanner.Domain.Auxiliary_Models
{
    public class UserManagerModel
    {
        public string? LoginEmail { get; set; }
        public string? LoginPassword { get; set; }
        public string? RegEmail { get; set; }
        public string? RegPassword { get; set; }
        public string? RegName { get; set; }
    }
}
