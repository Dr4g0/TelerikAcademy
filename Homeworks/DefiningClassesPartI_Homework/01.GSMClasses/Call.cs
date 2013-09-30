using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmInfo
{
    class Call
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        private string dialedPhone;

        public string DialedPhone
        {
            get { return dialedPhone; }
            set { dialedPhone = value; }
        }

        private int duration;

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public Call(DateTime date, string dialedPhone, int duration)
        {
            this.Date = date;
            this.DialedPhone = dialedPhone;
            this.Duration = duration;
        }
    }
}
