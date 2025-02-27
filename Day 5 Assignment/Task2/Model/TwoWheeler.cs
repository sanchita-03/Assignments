namespace Task2.Model
{
    public class TwoWheeler:VehicleInsurance
    {
        public TwoWheeler(string policyholder) : base(policyholder, "Two Wheeler")
        {

        }
        public override decimal CalculatePrimium()
        {
            return 10000M;
        }
    }
}
