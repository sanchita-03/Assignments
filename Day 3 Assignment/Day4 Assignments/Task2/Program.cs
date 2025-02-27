using Task2.Model;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Manager("Sanket", 20000, 2000);
            emp.DisplayDetails();
        }
    }
}
