using InsurancePolicyManagementSystem.Model;

namespace InsurancePolicyManagementSystem.Repository
{
    public interface IPolicyRepository
    {
        int CountDictItem();
        void AddPolicy(Policy policy);
        void ViewAllPolicies();
        void SearchPolicyById(int id);
        void UpdatePolicyDetails(int id);
        void DeletePolicy(int id);
        void ViewActivePolicies();
    }
}
