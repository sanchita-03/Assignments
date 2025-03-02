namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> customerqueue = new Queue<int>();
            int tokennumber = 1;
            int choice;
            Console.WriteLine("*****************************************");
            Console.WriteLine("1. add new customer in line press 1");
            Console.WriteLine("2. know next customer in the line press 2");
            Console.WriteLine("3. remove served customer from line press 3");
            Console.WriteLine("4. know the total customers in the line");
            Console.WriteLine("5. Exit");
            while (true)
            {
                Console.WriteLine("Enter your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        customerqueue.Enqueue(tokennumber);
                        Console.WriteLine($"Customer{tokennumber} added successfuly");
                        tokennumber++;
                        break;
                    case 2:
                        if (customerqueue.Count > 0)
                        {
                            Console.WriteLine($"Token Number of Next customer in the queue is {customerqueue.Peek()}");
                        }
                        else
                        {
                            Console.WriteLine("customer queue is empty");
                        }
                        break;
                    case 3:
                        if (customerqueue.Count > 0)
                        {
                            Console.WriteLine($"Customer {customerqueue.Dequeue()} served successfuly");
                        }
                        else
                        {
                            Console.WriteLine("customer queue is empty");
                        }
                        break;
                    case 4:
                        Console.WriteLine($"total customers in the line are {customerqueue.Count()}");
                        break;
                    case 5:
                        Console.WriteLine("Existing the system");
                        return;
                    default:
                        Console.WriteLine("invalid input please enter valid input (1-4)");
                        break;
                }
                Console.WriteLine("*****************************************\n");
            }
        }
    }
}
