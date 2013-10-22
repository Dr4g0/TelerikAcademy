using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Humans
{
    class Worker : Human
    {
        public decimal WeekSalary { get; set; }
        public decimal WorkHoursPerDay { get; set; }

        public Worker(string firstName, string lastName, decimal weekSalary, decimal workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal MoneyPerHour()
        {
            return (this.WeekSalary / (this.WorkHoursPerDay * 5)); //assume work week has 5 working days
        }

        public override string ToString()
        {
            StringBuilder worker = new StringBuilder();
            worker.AppendFormat("{0} - money per hour: {1}",this.FirstName+" "+this.LastName,Math.Round(this.MoneyPerHour(),2));
            return worker.ToString();
        }
    }
}
