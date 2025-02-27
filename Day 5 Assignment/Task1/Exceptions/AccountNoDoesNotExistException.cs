namespace Task1.Exceptions
{
    public class AccountNoDoesNotExistException : Exception
    {
        public AccountNoDoesNotExistException() { 

        }
        public AccountNoDoesNotExistException(string message):base(message) 
        {

        }
    }
}
