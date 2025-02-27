using Task1.Model;
using Task1.Repository;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();

            while (true)
            {
                IAccountRepository accountRepository = new AccountRepository();
                
                Console.WriteLine("Enter Account Number");
                int acnumber = Convert.ToInt32(Console.ReadLine());

                User_Account user1 = new User_Account() { Username = name, Account_No = acnumber };

                bool valid = accountRepository.VerifyAccount(user1);
                if (valid)
                {
                    Console.WriteLine("This account is valid");
                    break;
                }
                else
                {
                    Console.WriteLine("Try Again");
                }
            }

        }
    }
}
