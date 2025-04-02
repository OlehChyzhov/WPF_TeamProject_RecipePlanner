// <copyright file="DietCreator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace BusinessLogic
{
    using DataAccess;

    public static class DietCreator
    {
        public static WeightGoal WeightGoal { get; set; }

        public static ActivityLevel ActivityLevel { get; set; }

        public static Sex Gender { get; set; }

        public static int StepsPerDay { get; set; }

        public static int Height { get; set; }

        public static int CurrentWeight { get; set; }

        public static int DesiredWeight { get; set; }

        public static int Age { get; set; }

        private static double CalculateRawDailyCalories()
        {
            double value = (10 * CurrentWeight) + (6.25 * Height) - (5 * Age);
            double bmr = (Gender == Sex.Male) ? value + 5 : value - 161;

            double activityMultiplier = 1.2;
            switch (ActivityLevel)
            {
                case ActivityLevel.Inactive:
                    activityMultiplier = 1.2;
                    break;
                case ActivityLevel.Medium:
                    activityMultiplier = 1.55;
                    break;
                case ActivityLevel.Active:
                    activityMultiplier = 1.9;
                    break;
            }

            double dailyCalories = bmr * activityMultiplier;
            return dailyCalories;
        }

        public static double CalculateCalories()
        {
            double dailyCalories = CalculateRawDailyCalories();
            switch (WeightGoal)
            {
                case WeightGoal.Gain:
                    dailyCalories += 500;
                    break;
                case WeightGoal.Lose:
                    dailyCalories -= 500;
                    break;
            }

            if (StepsPerDay > 10_000)
            {
                dailyCalories += 200;
            }

            return dailyCalories;
        }
    }
}
