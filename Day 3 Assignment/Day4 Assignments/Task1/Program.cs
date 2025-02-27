using Task1.Model;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User_Login user1 = new User_Login();
            User_Login user2 = new User_Login();
            User_Login user3 = new User_Login();
            User_Login user4 = new User_Login();
            Console.WriteLine($"Total users logged in in the system is {User_Login.count}");

        }
    }
}
