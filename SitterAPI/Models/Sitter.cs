using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitterAPI.Models
{
    public class Sitter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool NoCriminalRecord { get; set; }
        public bool NoChildRecord { get; set; }
        public double HourlyWage { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
    }
}
