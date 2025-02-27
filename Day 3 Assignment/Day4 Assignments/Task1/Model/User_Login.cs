namespace Task1.Model
{
    internal class User_Login
    {
        public static int count = 0;
        public static int count1 = 0;

        public User_Login()
        {
            count++;
            Console.WriteLine($"User{count} is successfully logged in");
        }
    }
}
