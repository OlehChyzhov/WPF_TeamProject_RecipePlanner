// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using ConsoleLevel;
using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void FillDishes()
    {
        List<Dish> dishes = DefaultDataProvider.GetDefaultDishes("oleh.chyzhov@gmail.com");
        DbHelper.db.Dishes.AddRange(dishes);
        DbHelper.db.SaveChanges();
    }

    public static void FillAccount()
    {
        List<Account> accounts = DefaultDataProvider.GetDefaultAccounts();
        DbHelper.db.Accounts.AddRange(accounts);
        DbHelper.db.SaveChanges();
    }

    public static void FillAccountInformations()
    {
        List<AccountInfo> info = DefaultDataProvider.GetDefaultAccountsInfo();
        DbHelper.db.AccountInformations.AddRange(info);
        DbHelper.db.SaveChanges();
    }

    public static void FillStatisticEntities()
    {
        List<StatisticEntity> entities = DefaultDataProvider.GetStatisticEntities("oleh.chyzhov@gmail.com");
        DbHelper.db.StatisticEntities.AddRange(entities);
        DbHelper.db.SaveChanges();
    }

    public static void Main(string[] args)
    {
        DbHelper.ClearAccountInfo();
        DbHelper.ClearAccounts();
        DbHelper.ClearDishes();
        DbHelper.ClearStatisticEntities();
        FillAccount();
        FillAccountInformations();
        FillDishes();
        FillStatisticEntities();
    }
}