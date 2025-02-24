namespace SchoolManagement
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
            if (student_email=="")
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
