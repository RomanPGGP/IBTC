using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace APIPT.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        public DateTime BirthDate { get; set; }

        public char Gender { get; set; }
    }
}
