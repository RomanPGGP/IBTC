using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WRKT.Models
{
    public class TimeSlots
    {
        public int EmployeeID { get; set; }
        public int VenueID { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime FinishHour { get; set; }
        public int EmployerID { get; set; }

        public TimeSlots()
        {
            EmployeeID = 0;
            VenueID = 0;
            StartHour = DateTime.Now;
            FinishHour = DateTime.Now;
            EmployerID = 0;
        }

    }
}
