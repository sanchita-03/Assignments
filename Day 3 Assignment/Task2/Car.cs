
namespace Task2
{
    internal class Car
    {
        private int carId;
        private string brand;
        private string model;
        private int year;
        private double price;

        public int CarId
        {
            get { return carId; }
            set { carId = value; }
        }
        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public Car(int car_Id, string car_Brand, string car_Model, int mfg_Year, double car_Price)
        {
            carId = car_Id;
            brand = car_Brand;
            model = car_Model;
            year = mfg_Year;
            price = car_Price;
        }

        public void Displayinfo()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("Car info is as follows");
            Console.WriteLine("**************************************************");
            Console.WriteLine($"Car Id : {CarId} \nCar Brand : {Brand} \nCar Model : {Model} \nCar Manufaturing Year : {Year} \nCar Price : {Price}");
        }

        public Car()
        {
            carId = 101;
            brand = "sdhsgd";
            model = "hweg";
            Year = 2002;
            price = 2000000;
        }
    }
}
