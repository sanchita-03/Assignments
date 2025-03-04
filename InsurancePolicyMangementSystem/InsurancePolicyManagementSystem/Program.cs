using InsurancePolicyManagementSystem.Repository;
using InsurancePolicyManagementSystem.Model;
using System.Transactions;
using InsurancePolicyManagementSystem.Constants;

namespace InsurancePolicyManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To NeoInsurance");
            IPolicyRepository policyRepository = new PolicyRepository();
            int nextid = policyRepository.CountDictItem();
            int choice;
            while (true)
            {
                Console.WriteLine("*****************************************************************************");
                Console.WriteLine("Choose The Options :");
                Console.WriteLine("1.Add a New Policy\n2.View All Policies\n3.Search Policy by ID\n4.Update Policy Details");
                Console.WriteLine("5.Delete a Policy\n6.View Active Policies\n7.Exit");
                Console.WriteLine("Enter Your Choice");
                Console.WriteLine("*****************************************************************************");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter Policy Holder name");
                        string name=Console.ReadLine();
                        Console.Write("Enter Policy Type (1.Life, 2.Health, 3.Vehicle, 4.Property): ");
                        PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                        //Console.Write("Enter Start Date (yyyy-MM-dd): ");
                        DateTime startDate = DateTime.Now.Date;
                        Console.WriteLine(startDate);
                        Console.Write("Enter End Date (yyyy-MM-dd): ");
                        DateTime endDate = DateTime.Parse(Console.ReadLine());
                        policyRepository.AddPolicy(new Policy(nextid, name, type, startDate, endDate));
                        Console.WriteLine("Policy Added Successfuly");
                        Console.WriteLine("*****************************************************************************");
                        nextid++;
                        break;
                    case 2:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Details Of All Policies");
                        policyRepository.ViewAllPolicies();
                        Console.WriteLine("*****************************************************************************");
                        break;
                    case 3:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Enter Policy Id You Want To Search");
                        int id=Convert.ToInt32(Console.ReadLine());
                        policyRepository.SearchPolicyById(id);
                        Console.WriteLine("*****************************************************************************");
                        break;
                    case 4:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Enter Policy Id for which you want to update Details");
                        id = Convert.ToInt32(Console.ReadLine());
                        policyRepository.UpdatePolicyDetails(id);
                        Console.WriteLine("*****************************************************************************");
                        break;
                    case 5:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Enter Policy Id You Want To Delete");
                        id = Convert.ToInt32(Console.ReadLine());
                        policyRepository.DeletePolicy(id);
                        
                        Console.WriteLine("*****************************************************************************");
                        break;
                    case 6:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Details Of Active Policies:");
                        policyRepository.ViewActivePolicies();
                        Console.WriteLine("*****************************************************************************");
                        break;
                    case 7:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("Exit");
                        Console.WriteLine("Thank you For Visiting");
                        Console.WriteLine("*****************************************************************************");
                        return;
                    default:
                        Console.WriteLine("*****************************************************************************");
                        Console.WriteLine("invalid Input Provided Please give valid input(1-7)");
                        Console.WriteLine("*****************************************************************************");
                        break;
                }
            }

        }
    }
}
