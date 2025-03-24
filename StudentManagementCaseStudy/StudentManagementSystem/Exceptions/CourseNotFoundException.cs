namespace StudentManagementSystem.Exceptions
{
    public class CourseNotFoundException : ApplicationException
    {
        public CourseNotFoundException(string msg) : base(msg)
        {

        }
    }
}
