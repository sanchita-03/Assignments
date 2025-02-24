namespace ShopingPlatform_task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] username = { "sanchita_25", "sanket03", "soniya@12" };
            double[] Wallet_amount = { 12000, 15000, 30000 };
            bool IsValidUserId = false;

            while (true)
            {
                Console.WriteLine("Enter your User ID");
                string User_id = Console.ReadLine();

                for(int i=0;i<username.Length;i++)
                {
                    if (username[i] == User_id)
                    {
                        Console.WriteLine("***************************************");
                        Console.WriteLine($"Your user name : {User_id} \nAmount in your Wallet : {Wallet_amount[i]}");
                        IsValidUserId = true;
                        break;
                    }
                }
                if (IsValidUserId)
                {   
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid User Id Please Try Again");
                    Console.WriteLine("***************************************");
                }
            }
        }
    }
}
