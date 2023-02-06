using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211DLabInheritance.Entities
{
    internal class Employee
    {
        protected string id;
        protected string name;
        protected string address;

        public string ID { get => id; }
        public string Name { get => name; }
        public string Address { get => address; }

        public Employee() { }

        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }


    }
}