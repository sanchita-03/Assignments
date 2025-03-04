using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Exceptions;
using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{
    internal class PolicyRepository:IPolicyRepository
    {
        private Dictionary<int, Policy> policyDict;
        private int nextid = 0;
        public PolicyRepository()
        {
            policyDict = new Dictionary<int, Policy>
            {
                { ++nextid, new Policy(nextid, "Sanket", PolicyType.Health, new DateTime(2019, 6, 5), new DateTime(2023, 4, 10)) },
                { ++nextid, new Policy(nextid, "Meena", PolicyType.Life, new DateTime(2013, 10, 5), new DateTime(2025, 11, 12)) },
                { ++nextid, new Policy(nextid, "Prachi", PolicyType.Property, new DateTime(2008, 6, 5), new DateTime(2020, 8, 7)) },
                { ++nextid, new Policy(nextid, "Sanika", PolicyType.Health, new DateTime(2019, 3, 5), new DateTime(2022, 5, 7)) }
            };

        }
        public int CountDictItem()
        {
            int count = policyDict.Count;
            return ++count;
        }
        public void AddPolicy(Policy policy)
        {
            if (!policyDict.ContainsKey(policy.PolicyId))
            {
                policyDict[policy.PolicyId] = policy;
            }
        }
        public void SearchPolicyById(int id)
        {
            try
            {
                if (!policyDict.ContainsKey(id))
                {
                    throw new PolicyNotFoundException($"Policy No {id} not Found");
                }
                Console.WriteLine("Details Of searched Policy:");
                Console.WriteLine(policyDict[id]);
            }
            catch(PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdatePolicyDetails(int id)
        {
            try
            {
                if (policyDict.ContainsKey(id))
                {
                    while (true)
                    {
                        Console.WriteLine("choose the Option");
                        Console.WriteLine("1.Update name\n2.Update Policy Type\n3.Update Start Date\n4.Update End Date\n5.Exit");
                        Console.WriteLine("Enter Your Choice");
                        int option = Convert.ToInt32(Console.ReadLine());
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter Policy Holder name");
                                string name = Console.ReadLine();
                                policyDict[id].PolicyHolderName = name;
                                Console.WriteLine("Name Updated Successfuly");
                                break;
                            case 2:
                                Console.Write("Enter Policy Type (Life, Health, Vehicle, Property): ");
                                policyDict[id].PolicyType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                                Console.WriteLine("Policy Type Updated Successfuly");
                                break;
                            case 3:
                                Console.Write("Enter Start Date (yyyy-MM-dd): ");
                                policyDict[id].StartDate= DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("Start Date Updated successFuly");
                                break;
                            case 4:
                                Console.Write("Enter End Date (yyyy-MM-dd): ");
                                policyDict[id].EndDate = DateTime.Parse(Console.ReadLine());
                                Console.WriteLine("End Date Updated successFuly");
                                break;
                            case 5:
                                Console.WriteLine("Details Updated successFuly");
                                return;
                            default:
                                Console.WriteLine("please enter valid option(1-4)");
                                break;
                        }
                    }
                }
                else
                {
                    throw new PolicyNotFoundException($"Policy No {id} Not Found");
                }
            }
            catch (PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void DeletePolicy(int id)
        {
            try
            {
                if (!policyDict.ContainsKey(id))
                {
                    throw new PolicyNotFoundException($"Policy {id} not Found");
                }
                policyDict.Remove(id);
                Console.WriteLine("Policy Deleted successFuly");
            }
            catch(PolicyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public bool IsActive(Policy policy)
        {
            DateTime currentdate = DateTime.Now;
            if (currentdate.Date >= policy.StartDate.Date && currentdate.Date <= policy.EndDate.Date)
            {
                return true;
            }
            return false;
        }
         
        public void ViewActivePolicies()
        {
            DateTime currentdate = DateTime.Now;
            foreach (var item in policyDict.Values)
            {
                if (IsActive(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
        public void ViewAllPolicies()
        {
            //return policyDict;
            foreach (var item in policyDict.Values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
