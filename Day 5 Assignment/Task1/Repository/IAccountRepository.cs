using Task1.Model;

namespace Task1.Repository
{
    internal interface IAccountRepository
    {
       
            User_Account GetAccountNo(int number);
            bool VerifyAccount(User_Account account);
        
    }
}
