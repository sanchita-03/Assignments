namespace Task2.Model
{
    public abstract class VehicleInsurance
    {
        public string PolicyHolder {  get; set; }
        public string VehicleType { get; set; }

        public VehicleInsurance(string policyholder,string vehicletype)
        {
            PolicyHolder = policyholder;
            VehicleType = vehicletype;
        }

        public abstract decimal CalculatePrimium();
    }
}
