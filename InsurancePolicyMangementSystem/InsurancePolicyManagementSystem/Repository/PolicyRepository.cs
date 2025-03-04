using InsurancePolicyManagementSystem.Constants;
using InsurancePolicyManagementSystem.Exceptions;
using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{
    internal class PolicyRepository:IPolicyRepository
    {
        private Dictionary<int, Policy> policyDict = new Dictionary<int, Policy>();
        public void AddPolicy(Policy policy)
        {
            if (!policyDict.ContainsKey(policy.PolicyId))
            {
                policyDict[policy.PolicyId] = policy;
            }

        }
        public void SearchPolicyById(int id)
        {
            if (policyDict.ContainsKey(id))
            {
                Console.WriteLine($"Policy ID: {policyDict[id].PolicyId}, Holder: {policyDict[id].PolicyHolderName}, Type: {policyDict[id].PolicyType}, Start: {policyDict[id].StartDate.ToShortDateString()}, End: {policyDict[id].EndDate.ToShortDateString()}");
            }
        }
        public void UpdatePolicyDetails(Policy policy)
        {
            if (policyDict.ContainsKey(policy.PolicyId))
            {
                policyDict[policy.PolicyId] = policy;
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
                    Console.WriteLine("Active");
                    Console.WriteLine($"Policy ID: {item.PolicyId}, Holder: {item.PolicyHolderName}, Type: {item.PolicyType}, Start: {item.StartDate.ToShortDateString()}, End: {item.EndDate.ToShortDateString()}");
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
