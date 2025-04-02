namespace BusinessLogic
{
    using DataAccess;
    using DataAccess.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    public static class AccountManager
    {
        private static Account? _loginedAccount = null;

        public static Account LoginedAccount
        {
            get
            {
                if (_loginedAccount == null)
                {
                    throw new NotImplementedException("User didn't login");
                }

                return _loginedAccount;
            }

            set
            {
                _loginedAccount = value;
            }
        }

        public static Account UpdateLoginedAccount(string email)
        {
            LoginedAccount = DbHelper.db.Accounts.Where(acc => acc.Email == email).Include("AccountInfo")
                .Include("StatisticEntities").Include("Dishes").Include("FoodPlans").First();
            return LoginedAccount;
        }

        public static bool IsLogined()
        {
            return LoginedAccount == null ? false : true;
        }
    }
}
