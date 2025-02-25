
namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car_info = new Car(105,"sj","wy",2002,200000);
            car_info.Displayinfo();

            Console.WriteLine();
            Car car_info1 = new Car();
            car_info1.Displayinfo();

        }
    }
}
