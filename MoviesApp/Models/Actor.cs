using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataOfBirth { get; set; }
    }
}
