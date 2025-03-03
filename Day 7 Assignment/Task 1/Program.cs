using Task_1.Model;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employee = new List<Employee>
            {
                new Employee { Id = 101, Name = "John Doe", Joiningdate = new DateTime(2015, 6, 15) },
                new Employee { Id = 102, Name = "Alice Smith", Joiningdate = new DateTime(2018, 12, 1) },
                new Employee { Id = 103, Name = "Bob Johnson", Joiningdate = new DateTime(2020, 5, 20) },
                new Employee { Id = 104, Name = "Emma Brown", Joiningdate = new DateTime(2010, 3, 10) }
            };
            foreach (Employee emp in employee)
            {
                Console.WriteLine($"{emp.Name}'s Total Years Of Experience is {emp.GetExperience()}");
            }
        }
    }
}
