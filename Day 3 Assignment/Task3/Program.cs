namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter Your Password");
                string userPassword = Console.ReadLine();

                PasswordValidation password = new PasswordValidation();
                if (password.Valid(userPassword))
                {
                    Console.WriteLine("Password is valid");
                    break;
                }
            }

        }
    }
}
