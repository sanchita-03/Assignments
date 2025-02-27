namespace Task2.Model
{
    public class FourWheeler : VehicleInsurance
    {
        public FourWheeler(string policyholder):base(policyholder,"Four Wheeler")
        {

        }
        public override decimal CalculatePrimium()
        {
            return 15000M;
        }
    }
}
