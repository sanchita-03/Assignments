namespace Task2.Model
{
    public class Commercial: VehicleInsurance
    {
        public Commercial(string policyholder) : base(policyholder, "Commercial")
        {

        }
        public override decimal CalculatePrimium()
        {
            return 20000M;
        }
    }
}
