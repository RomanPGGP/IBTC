using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIFE.Models
{
    public class Participant
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }

    }
}
