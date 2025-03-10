using PolicyManagement.Model;

namespace PolicyManagement.Repository
{
    public interface IPolicyRepository
    {
        public int AddPolicy(Policy policy);
        public List<Policy> ViewAllPolicies();
        public Policy SearchPolicyById(int id);
        int UpdatePolicyDetails(int id);
        int DeletePolicy(int id);
        List<Policy> ViewActivePolicies();
    }
}
