// <copyright file="ConsoleLevelTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using ConsoleLevel;
    using DataAccess.Models;

    [TestClass]
    public class ConsoleLevelTests
    {
        [TestMethod]
        public void TestGetDefaultAccounts()
        {
            List<Account> accounts = new List<Account>();
            accounts = DefaultDataProvider.GetDefaultAccounts();
            Assert.IsNotNull(accounts);
        }

        [TestMethod]
        public void TestGetDefaultAccountInfo()
        {
            List<AccountInfo> info = new List<AccountInfo>();
            info = DefaultDataProvider.GetDefaultAccountsInfo();
            Assert.IsNotNull(info);
        }

        [TestMethod]
        public void TestGetDefaultDishes()
        {
            List<Dish> dishes = new List<Dish>();
            dishes = DefaultDataProvider.GetDefaultDishes("oleh.chyzhov@gmail.com");
            foreach (var dish in dishes)
            {
                Assert.AreEqual(dish.AccountEmail, "oleh.chyzhov@gmail.com");
            }

            Assert.IsNotNull(dishes);
        }

        [TestMethod]
        public void TestgetDefaultStatisticEntities()
        {
            List<StatisticEntity> entities = new List<StatisticEntity>();
            entities = DefaultDataProvider.GetStatisticEntities("oleh.chyzhov@gmail.com");
            foreach (var entity in entities)
            {
                Assert.AreEqual(entity.AccountEmail, "oleh.chyzhov@gmail.com");
            }

            Assert.IsNotNull(entities);
        }
    }
}
