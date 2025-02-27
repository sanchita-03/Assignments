namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task2
            Console.WriteLine("********************************************************************");
            Console.WriteLine("Handling Non-Numeric Value in age");
            Console.WriteLine("********************************************************************");
            // taking name as input
            Console.WriteLine("Enter Your Name :");
            String st_name = Console.ReadLine();

            // taking age as input
            Console.WriteLine("Enter your Age :");
            string ageinput = Console.ReadLine();
            if (!int.TryParse(ageinput, out int st_age))
            {
                Console.WriteLine("Invalid input provided");
                return;
            }

            // taking percentage as input 
            Console.WriteLine("Enter your Percentage :");
            float st_Percentage = float.Parse(Console.ReadLine());

            // information display
            Console.WriteLine("*************************Student Info***************************");
            Console.WriteLine($"student name is :{st_name}\nage : {st_age}\npercentage : {st_Percentage}");

            #endregion
        }
    }
}
