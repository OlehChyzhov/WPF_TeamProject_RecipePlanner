// <copyright file="StatisticTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace UnitTests
{
    using BusinessLogic;
    using DataAccess;
    using DataAccess.Models;
    using LiveCharts;
    using LiveCharts.Defaults;
    using UserInterface.MVVM;

    [TestClass]
    public class StatisticTests
    {
        [TestMethod]
        public void ToggleZoomModeTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            StatisticsViewModel vm = new StatisticsViewModel();
            Assert.AreEqual(vm.ZoomingMode, ZoomingOptions.None);
            vm.ExecuteToggleZoomModeCommand();
            Assert.AreEqual(vm.ZoomingMode, ZoomingOptions.X);
            vm.ExecuteToggleZoomModeCommand();
            Assert.AreEqual(vm.ZoomingMode, ZoomingOptions.Y);
            vm.ExecuteToggleZoomModeCommand();
            Assert.AreEqual(vm.ZoomingMode, ZoomingOptions.Xy);
        }

        [TestMethod]
        public void ResetWeightTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            StatisticsViewModel vm = new StatisticsViewModel();
            int oldWeight = AccountManager.LoginedAccount.AccountInfo.Weight;
            StatisticEntity entity = new StatisticEntity() { AccountEmail = "oleh.chyzhov@gmail.com", Date = DateTime.Now, Weight = 1000 };
            DbHelper.db.StatisticEntities.Add(entity);
            vm.ResetCurrentWeight();
            Assert.AreEqual(entity.Weight, AccountManager.LoginedAccount.AccountInfo.Weight);

            DbHelper.db.StatisticEntities.Remove(entity);
            DbHelper.db.SaveChanges();

            vm.ResetCurrentWeight();
            Assert.AreEqual(oldWeight, AccountManager.LoginedAccount.AccountInfo.Weight);
        }

        [TestMethod]
        public void ResetZoomTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            StatisticsViewModel vm = new StatisticsViewModel();
            vm.ExecuteResetZoomCommand();
            Assert.AreEqual(vm.XMin, double.NaN);
            Assert.AreEqual(vm.XMax, double.NaN);
            Assert.AreEqual(vm.YMin, double.NaN);
            Assert.AreEqual(vm.YMax, double.NaN);
            Assert.AreEqual(vm.FromDateTime, null);
            Assert.AreEqual(vm.ToDateTime, null);
        }

        [TestMethod]
        public void PopulateEntitesTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            StatisticsViewModel vm = new StatisticsViewModel();
            vm.PopulateEntities();
            Assert.IsNotNull(vm.Entities);
        }

        [TestMethod]
        public void AddNewEntityTest()
        {
            AccountManager.UpdateLoginedAccount("oleh.chyzhov@gmail.com");
            StatisticsViewModel vm = new StatisticsViewModel();
            vm.Date = "24.11.5000";
            vm.Weight = "1000";
            vm.ExecuteAddNewEntityCommand();
            StatisticEntity? entity = DbHelper.db.StatisticEntities.Where(entitiy => entitiy.Weight == 1000).FirstOrDefault();

            Assert.IsNotNull(entity);
            DbHelper.db.Remove(entity);
            DbHelper.db.SaveChanges();
            vm.ResetCurrentWeight();
        }
    }
}
