namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int id;

            EventRegistration eventRegistration = new EventRegistration();
            int choice;
            Console.WriteLine("1.Register\n2.Exit");
            while (true)
            {
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Workshop Name");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter Your Id");
                        id = Convert.ToInt32(Console.ReadLine());

                        eventRegistration.Registration(name, id);
                        break;
                    case 2:
                        Console.WriteLine("Exiting Successfuly");
                        goto print;
                    default:
                        Console.WriteLine("Invalid Input please enter valid input(1-2)");
                        break;
                }
            }
            print:
                eventRegistration.PrintAllDetails();

        }
    }
}
