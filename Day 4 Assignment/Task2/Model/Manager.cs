using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Model
{
    internal class Manager:Employee
    {
        public double Bonus {  get; set; }

        public Manager(string name,double salary,double bonus) : base(name, salary)
        {
            Bonus = bonus;
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Employee Name is {Name}\nSalary is {Salary}\nBonus is {Bonus}");
        }
    }
}
