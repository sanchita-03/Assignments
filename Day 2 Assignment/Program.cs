namespace Day_2_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your Basic Salary");
            double salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the Performance rating between 1-10");
            int ratings = Convert.ToInt32(Console.ReadLine());

            double Tax_deduction = salary * 0.1;
            double bonus = 0;
            if (ratings >= 8)
            {
                bonus = salary * 0.2;
            }
            else if (ratings >= 5)
            {
                bonus = salary * 0.1;
            }
             
            double net_salary = salary -Tax_deduction + bonus;
            Console.WriteLine($"Tax Deduction Amount = {Tax_deduction}");
            Console.WriteLine($"Bonus Amount = {bonus}");
            Console.WriteLine($"Net Salary Amount = {net_salary}");
        }
    }
}
