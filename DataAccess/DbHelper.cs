namespace DataAccess
{
    public static class DbHelper
    {
        public static DataBaseContext db = new DataBaseContext();

        public static void ClearAccounts()
        {
            foreach (var entity in db.Accounts)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearAccountInfo()
        {
            foreach (var entity in db.AccountInformations)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearDishes()
        {
            foreach (var entity in db.Dishes)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearStatisticEntities()
        {
            foreach (var entity in db.StatisticEntities)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearDishMeal()
        {
            foreach (var entity in db.DishMealConnectTable)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearFoodPlans()
        {
            foreach (var entity in db.FoodPlans)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearMeals()
        {
            foreach (var entity in db.Meals)
            {
                db.Remove(entity);
            }

            db.SaveChanges();
        }

        public static void ClearDatabase()
        {
            ClearFoodPlans();
            ClearStatisticEntities();
            ClearDishMeal();
            ClearDishes();
            ClearMeals();
            ClearAccountInfo();
            ClearAccounts();
        }
    }
}
