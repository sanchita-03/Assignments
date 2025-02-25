
namespace Task1.Model
{
    internal class Car
    {
        public int carId;
        public string brand;
        public string model;
        public int year;
        public double price;

        public void AssignValue()
        {
            Console.WriteLine("Receiving Car Information");

            Console.WriteLine("enter car Id");
            carId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter car brand");
            brand = Console.ReadLine();

            Console.WriteLine("enter car model");
            model = Console.ReadLine();

            Console.WriteLine("enter manufaturing year");
            year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter car Price");
            price = Convert.ToDouble(Console.ReadLine());
        }

        public void DisplayInformation()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Car Id : {carId} \nCar Brand : {brand} \nCar Model : {model} \nCar Manufaturing Year : {year} \nCar Price : {price}");
        }
    }
}
