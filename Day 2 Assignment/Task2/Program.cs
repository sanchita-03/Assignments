namespace Ticket_booking_task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const double General_tkt = 200D;
            const double Ac_tkt = 400D;
            const double Sleeper_tkt = 700D;
            bool book_tkt = true;
            double tkt_price = 0;
            int tkt_number;
            string choice;

            Console.WriteLine("************************************************");
            Console.WriteLine("Book Your Ticket");
            Console.WriteLine("1.General 200Rs \n2.A/c 400Rs \n3.Sleeper 700Rs");
            Console.WriteLine("************************************************");

            while (book_tkt)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("Enter Your Ticket Type (general/ac/sleeper)");
                Console.WriteLine("Type 'exit' to finish booking.");
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "general":
                        Console.WriteLine("Enter number of ticket");
                        tkt_number = Convert.ToInt32(Console.ReadLine());
                        tkt_price += (General_tkt * tkt_number);
                        Console.WriteLine($"price : {tkt_price}");
                        break;
                    case "ac":
                        Console.WriteLine("Enter number of ticket");
                        tkt_number = Convert.ToInt32(Console.ReadLine());
                        tkt_price += (Ac_tkt * tkt_number);
                        Console.WriteLine($"price : {tkt_price}");
                        break;
                    case "sleeper":
                        Console.WriteLine("Enter number of ticket");
                        tkt_number = Convert.ToInt32(Console.ReadLine());
                        tkt_price += (Sleeper_tkt * tkt_number);
                        Console.WriteLine($"price : {tkt_price}");
                        break;
                    case "exit":
                        Console.WriteLine("thank you for visit");
                        Console.WriteLine($"final price of booked tickets : {tkt_price}");
                        book_tkt = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input Provided");
                        break;

                }
            }

        }
    }
}



