using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitterAPI.Models
{
    public class Baby
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string SpecialNeeds { get; set; }
    }
}
