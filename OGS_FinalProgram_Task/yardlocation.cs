using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OGS_FinalProgram_Task
{
    public class yardlocation
    {
        private int attendeenumbers { get; set; }
        public void addattendees(int numberOfAttendees)
        {
            attendeenumbers += numberOfAttendees;
        }
        public void removeattendees(int numberOfAttendees)
        {
            attendeenumbers -= numberOfAttendees;
        }
        public float returnattendees()
        {
            throw new NotImplementedException();
        }
    }
}
