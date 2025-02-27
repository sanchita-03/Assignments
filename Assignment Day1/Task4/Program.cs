namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********************************************************************");
            Console.WriteLine("Hospital Management System - Patient Discharge");
            Console.WriteLine("********************************************************************");

            // Taking patient's name
            Console.WriteLine("Enter Patient Name:");
            string patient_name = Console.ReadLine();

            // Taking discharge date (nullable DateTime)
            Console.WriteLine("Enter Discharge Date (YYYY-MM-DD) or press Enter if not discharged:");
            string dischargeInput = Console.ReadLine();

            DateTime? dischargeDate = null;  // Default to null if not entered

            if (dischargeInput != "") // Check if input is not empty
            {
                dischargeDate = DateTime.Parse(dischargeInput);
            }

            // Displaying Patient Info
            Console.WriteLine("************************* Patient Info ***************************");
            Console.WriteLine($"Patient Name  : {patient_name}");

            if (dischargeDate != null)
            {
                Console.WriteLine($"Discharge Date : {dischargeDate:yyyy-MM-dd}");
            }
            else
            {
                Console.WriteLine("Discharge Date : Not Discharged");
            }
        }
    }
}
