using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211DLabInheritance.Entities
{
    internal class PartTime : Employee
    {
        private double rate;
        private double hours;

        public double Rate { get => rate; }
        public double Hours { get => hours; }

        public PartTime(string id, string name, string address, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
        }
    }
}