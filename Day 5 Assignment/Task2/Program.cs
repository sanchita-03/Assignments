using Task2.Model;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleInsurance vehicle1 = new TwoWheeler("Sanchita");
            VehicleInsurance vehicle2 = new FourWheeler("Sanket");
            VehicleInsurance vehicle3 = new Commercial("Sanchu");

            Console.WriteLine($"{vehicle1.PolicyHolder}'s {vehicle1.VehicleType} premium is {vehicle1.CalculatePrimium()}");
            Console.WriteLine($"{vehicle2.PolicyHolder}'s {vehicle2.VehicleType} premium is {vehicle2.CalculatePrimium()}");
            Console.WriteLine($"{vehicle3.PolicyHolder}'s {vehicle3.VehicleType} premium is {vehicle3.CalculatePrimium()}");
        }
    }
}
