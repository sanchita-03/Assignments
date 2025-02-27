namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task1
            // taking name as input
            Console.WriteLine("Enter Your Name :");
            String name = Console.ReadLine();

            // taking age as input
            Console.WriteLine("Enter your Age :");
            int age = Convert.ToInt32(Console.ReadLine());

            // taking percentage as input 
            Console.WriteLine("Enter your Percentage :");
            float Percentage = float.Parse(Console.ReadLine());

            // information display
            Console.WriteLine("*************************Student Info***************************");
            Console.WriteLine($"student name is :{name}\nage : {age}\npercentage : {Percentage}");

            #endregion
        }
    }
}
