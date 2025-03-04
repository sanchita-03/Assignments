using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{
    public interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        void ViewAllPolicies();
        void SearchPolicyById(int id);
        void UpdatePolicyDetails(Policy policy);
        void DeletePolicy(int id);
        void ViewActivePolicies();
    }
}
