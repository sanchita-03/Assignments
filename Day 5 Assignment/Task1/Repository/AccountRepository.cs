using Task1.Exceptions;
using Task1.Model;

namespace Task1.Repository
{
    internal class AccountRepository : IAccountRepository
    {
        //create a List
        List<User_Account> user_account;
        //constructor
        public AccountRepository()
        {
            //Initialising the list
            user_account = new List<User_Account>
            {
                new User_Account(){Username="Ola",Account_No=201},
                new User_Account(){Username="Sanchita",Account_No=202},
                new User_Account(){Username="anar",Account_No=203}

            };
        }

        public bool VerifyAccount(User_Account user_account)
        {
            try
            {
                User_Account searchResult = GetAccountNo(user_account.Account_No);
                if (searchResult == null)
                {
                    throw new AccountNoDoesNotExistException("invalid account");
                }
                return true;
            }
            catch (AccountNoDoesNotExistException acex)
            {
                Console.WriteLine(acex.Message);
            }
            return false;
        }

        public User_Account GetAccountNo(int acnumber)
        {
            return user_account.Find(p => p.Account_No == acnumber);
        }
    }
}
