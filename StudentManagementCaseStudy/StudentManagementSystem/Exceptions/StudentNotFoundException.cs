namespace StudentManagementSystem.Exceptions
{
    public class StudentNotFoundException : ApplicationException
    {
        public StudentNotFoundException(string msg) : base(msg)
        {

        }
    }
}
