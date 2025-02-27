namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 3
            Console.WriteLine("********************************************************************");
            Console.WriteLine("Email Null ");
            Console.WriteLine("********************************************************************");
            // taking name as input
            Console.WriteLine("Enter Your Name :");
            String student_name = Console.ReadLine();

            // taking age as input
            Console.WriteLine("Enter your Age :");
            string st_ageinput = Console.ReadLine();
            if (!int.TryParse(st_ageinput, out int student_age))
            {
                Console.WriteLine("Invalid input provided");
                return;
            }

            // taking percentage as input 
            Console.WriteLine("Enter your Percentage :");
            float student_Percentage = float.Parse(Console.ReadLine());

            //taking email as input
            Console.WriteLine("Enter Your Email");
            String student_email = Console.ReadLine();
            if (student_email == "")
            {
                Console.WriteLine("Email Cannot be empty");
                return;
            }
            // information display
            Console.WriteLine("*************************Student Info***************************");
            Console.WriteLine($"student name is :{student_name}\nage : {student_age}\npercentage : {student_Percentage}\nemail : {student_email}");
            #endregion
        }
    }
}
