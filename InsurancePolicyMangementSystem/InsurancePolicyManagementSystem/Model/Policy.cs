using InsurancePolicyManagementSystem.Constants;

namespace InsurancePolicyManagementSystem.Model
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Policy(int id,string name,PolicyType type,DateTime startDate,DateTime endDate )
        {
            PolicyId = id;
            PolicyHolderName = name;
            PolicyType = type;
            StartDate = startDate;
            EndDate = endDate;

        }
        public override string ToString()
        {
            return $"Policy ID: {PolicyId}, Holder: {PolicyHolderName}, Type: {PolicyType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
        }
    }
}
