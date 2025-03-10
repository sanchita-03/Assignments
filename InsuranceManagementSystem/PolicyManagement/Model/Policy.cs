using PolicyManagement.Constants;

namespace PolicyManagement.Model
{
    public class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override string ToString()
        {
            return $"Policy Id: {PolicyId} Holder: {PolicyHolderName}, Type: {PolicyType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
        }
    }
}
