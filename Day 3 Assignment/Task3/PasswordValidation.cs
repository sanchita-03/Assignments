namespace Task3
{
    internal class PasswordValidation
    {
        //private string _password;

        //public PasswordValidation(String password)
        //{
        //    _password = password;
        //}
        public bool Valid(string password)
        {

            if (password.Length < 6)
            {
                Console.WriteLine("The password must be at least 6 characters long");
                return false;
            }
            if (!password.Any(char.IsUpper))
            {
                Console.WriteLine("Password must contain at least one uppercase letter. ");
                return false;
            }
            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("must contain at least one digit.");
                return false;
            }
            return true;
        }
    }
}