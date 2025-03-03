namespace Task_1.Model
{
    static class EmployeeExtensionMethod
    {
        public static int GetExperience(this Employee employee)
        {
            DateTime currentDate = DateTime.Now;
            int experience = currentDate.Year - employee.Joiningdate.Year;
            if(currentDate.Month< employee.Joiningdate.Month || (currentDate.Month == employee.Joiningdate.Month && currentDate.Day < employee.Joiningdate.Day))
            {
                experience--;
            }
            return experience;
        }
    }
}
