// <copyright file="LoginTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using UserInterface.MVVM;

    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void LoginTest()
        {
            LoginViewModel vm = new LoginViewModel();
            vm.Email = "oleh.chyzhov@gmail.com";
            vm.Password = "Oleg2005";
            AccountManager.LoginedAccount = AccountManager.UpdateLoginedAccount(vm.Email);
            Assert.AreEqual(AccountManager.LoginedAccount.Email, "oleh.chyzhov@gmail.com");
        }
    }
}