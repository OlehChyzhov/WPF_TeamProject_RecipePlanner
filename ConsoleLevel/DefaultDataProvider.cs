namespace ConsoleLevel
{
    using DataAccess;
    using DataAccess.Models;
    using System;

    public static class DefaultDataProvider
    {
        public static List<Account> GetDefaultAccounts()
        {
            List<Account> accounts = new List<Account>();
            accounts.Add(new Account() { Email = "oleh.chyzhov@gmail.com", Password = "Oleg2005" });
            return accounts;
        }

        public static List<AccountInfo> GetDefaultAccountsInfo()
        {
            List<AccountInfo> info = new List<AccountInfo>();
            info.Add(new AccountInfo() { Sex = Sex.Male, Age = 19, Weight = 75, Height = 178, DesiredWeight = 89, Goal = WeightGoal.Gain, DailyCalories = 1711, AccountEmail = "oleh.chyzhov@gmail.com" });
            return info;
        }

        public static List<Dish> GetDefaultDishes(string email)
        {
            List<Dish> dishes = new List<Dish>();

            dishes.Add(new Dish()
            {
                Id = 1,
                Title = "Spaghetti Carbonara",
                Calories = 400,
                Protein = 14,
                Carbs = 50,
                Fat = 15,
                Recipe = "Cook the spaghetti in salted boiling water until al dente. Reserve 1 cup of pasta water before draining. In a bowl, whisk eggs, egg yolks, and Pecorino Romano. Season with black pepper. Set aside. Heat olive oil in a skillet over medium heat. Add pancetta and cook until crispy. Remove from heat. Add spaghetti to the skillet and toss. Gradually pour the egg mixture, stirring quickly to coat evenly. Adjust with pasta water if needed. Serve hot with extra Pecorino and black pepper on top.",
                Ingredients = "Spaghetti: 400 grams,Pancetta or guanciale: 150 grams,Pecorino Romano cheese: 100 grams,Olive oil: 2 tablespoons,Eggs: 2 large,Egg yolks: 2 large,Salt: to taste,Black pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 2,
                Title = "Chicken Tikka Masala",
                Calories = 430,
                Protein = 35,
                Carbs = 15,
                Fat = 25,
                Recipe = "Marinate chicken pieces in a mixture of yogurt, lemon juice, garlic, ginger, and spices (cumin, coriander, paprika, turmeric, and garam masala) for at least 1 hour. Grill or pan-fry the chicken until cooked. In a skillet, sauté onions, garlic, and ginger. Add tomato puree, heavy cream, and spices (cumin, coriander, paprika, turmeric, and garam masala). Simmer until thickened. Add the cooked chicken and simmer for a few more minutes. Serve hot with rice or naan.",
                Ingredients = "Chicken: 500 grams,Yogurt: 150 grams,Tomato puree: 200 grams,Heavy cream: 100 grams,Onions: 100 grams,Garlic: 10 grams,Ginger: 10 grams,Spices (cumin, coriander, paprika, turmeric, garam masala): to taste,Lemon juice: 1 tablespoon,Oil: 2 tablespoons,Salt: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 3,
                Title = "Beef Wellington",
                Calories = 700,
                Protein = 45,
                Carbs = 25,
                Fat = 50,
                Recipe = "Season the beef fillet with salt and pepper, then sear in a hot pan until browned on all sides. Allow to cool. Spread a layer of mushroom duxelles on a large sheet of puff pastry, then place the beef fillet on top. Wrap the beef tightly in the pastry, sealing the edges. Brush with egg wash and bake at 200°C (400°F) for 30-40 minutes, or until golden brown. Rest for 10 minutes before slicing and serving.",
                Ingredients = "Beef fillet: 500 grams,Puff pastry: 250 grams,Mushrooms: 200 grams,Shallots: 50 grams,Garlic: 10 grams,Butter: 30 grams,Eggs: 1 large,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 4,
                Title = "Shrimp Scampi",
                Calories = 350,
                Protein = 25,
                Carbs = 30,
                Fat = 15,
                Recipe = "Cook spaghetti or linguine until al dente and set aside. In a skillet, heat olive oil and butter over medium heat. Add minced garlic and cook until fragrant. Add shrimp and cook until pink, about 2-3 minutes per side. Deglaze the pan with white wine and lemon juice. Toss the cooked pasta in the sauce and garnish with chopped parsley. Serve hot.",
                Ingredients = "Shrimp: 400 grams,Pasta: 300 grams,Garlic: 10 grams,Olive oil: 2 tablespoons,Butter: 30 grams,White wine: 50 milliliters,Lemon juice: 2 tablespoons,Parsley: 10 grams,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 5,
                Title = "Pad Thai",
                Calories = 450,
                Protein = 20,
                Carbs = 50,
                Fat = 15,
                Recipe = "Soak rice noodles in warm water until softened, then drain. In a wok, heat oil and cook diced tofu until golden. Add garlic and shrimp, cooking until shrimp are pink. Push ingredients to the side and scramble eggs in the center of the wok. Mix in the noodles, then add tamarind paste, fish sauce, sugar, and chili flakes. Toss to combine and heat through. Garnish with peanuts, bean sprouts, and lime wedges before serving.",
                Ingredients = "Rice noodles: 200 grams,Shrimp: 150 grams,Tofu: 100 grams,Eggs: 2 large,Tamarind paste: 2 tablespoons,Fish sauce: 2 tablespoons,Sugar: 1 tablespoon,Chili flakes: to taste,Peanuts: 30 grams,Bean sprouts: 50 grams,Lime: 1 wedge,Oil: 2 tablespoons",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 6,
                Title = "Paella Valenciana",
                Calories = 450,
                Protein = 25,
                Carbs = 50,
                Fat = 15,
                Recipe = "Heat olive oil in a large pan. Sauté chicken, rabbit, and green beans until browned. Add grated tomato and paprika, stirring well. Pour in chicken broth and bring to a boil. Add saffron and rice, spreading evenly. Cook over medium heat without stirring until the liquid is absorbed. Let rest for a few minutes before serving.",
                Ingredients = "Chicken: 300 grams,Rabbit: 300 grams,Green beans: 100 grams,Rice: 250 grams,Chicken broth: 800 milliliters,Tomato: 100 grams,Olive oil: 50 milliliters,Saffron: 1 pinch,Paprika: 1 teaspoon,Salt: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 7,
                Title = "Sushi Nigiri",
                Calories = 200,
                Protein = 15,
                Carbs = 30,
                Fat = 3,
                Recipe = "Cook sushi rice and season it with rice vinegar, sugar, and salt. Shape the rice into small oval mounds. Place a thin slice of fresh fish or seafood on top, pressing gently. Serve with soy sauce, pickled ginger, and wasabi.",
                Ingredients = "Sushi rice: 200 grams,Fish or seafood: 150 grams,Rice vinegar: 2 tablespoons,Sugar: 1 teaspoon,Salt: 1 teaspoon,Soy sauce: to taste,Pickled ginger: to taste,Wasabi: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 8,
                Title = "Moussaka",
                Calories = 550,
                Protein = 30,
                Carbs = 35,
                Fat = 30,
                Recipe = "Slice eggplants, salt them, and let them sit to remove bitterness. Fry or bake the slices until tender. Cook ground lamb with onions, garlic, and tomatoes until thickened. Layer eggplant and meat sauce in a baking dish. Top with béchamel sauce and bake at 180°C (350°F) until golden.",
                Ingredients = "Eggplant: 500 grams,Ground lamb: 300 grams,Onions: 100 grams,Garlic: 10 grams,Tomatoes: 200 grams,Béchamel sauce: 200 milliliters,Olive oil: 50 milliliters,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 9,
                Title = "Beef Bourguignon",
                Calories = 600,
                Protein = 40,
                Carbs = 20,
                Fat = 35,
                Recipe = "Sear beef chunks in a hot pan until browned. Remove and set aside. In the same pan, sauté onions, carrots, and garlic. Add red wine, beef stock, and tomato paste. Return beef to the pan and simmer gently for 2-3 hours until tender. Add mushrooms in the last 30 minutes of cooking. Serve hot.",
                Ingredients = "Beef: 500 grams,Red wine: 250 milliliters,Beef stock: 500 milliliters,Carrots: 100 grams,Onions: 100 grams,Garlic: 10 grams,Tomato paste: 2 tablespoons,Mushrooms: 200 grams,Olive oil: 2 tablespoons,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 10,
                Title = "Tom Yum Soup",
                Calories = 250,
                Protein = 10,
                Carbs = 20,
                Fat = 10,
                Recipe = "Bring chicken stock to a boil. Add lemongrass, galangal, kaffir lime leaves, and chili. Simmer for a few minutes. Add shrimp, mushrooms, and tomatoes. Stir in fish sauce, lime juice, and sugar to balance the flavors. Serve hot with cilantro garnish.",
                Ingredients = "Chicken stock: 500 milliliters,Shrimp: 200 grams,Mushrooms: 100 grams,Tomatoes: 100 grams,Lemongrass: 2 stalks,Galangal: 10 grams,Kaffir lime leaves: 4 leaves,Chili: to taste,Fish sauce: 2 tablespoons,Lime juice: 2 tablespoons,Sugar: 1 teaspoon,Cilantro: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 11,
                Title = "Fish Tacos",
                Calories = 350,
                Protein = 20,
                Carbs = 40,
                Fat = 12,
                Recipe = "Grill or pan-fry the fish fillets until cooked through. Warm the tortillas and fill with the fish. Top with shredded cabbage, cilantro, and a squeeze of lime juice. Drizzle with sour cream or a creamy sauce of your choice. Serve with lime wedges on the side.",
                Ingredients = "White fish fillets: 300 grams,Tortillas: 4,Shredded cabbage: 50 grams,Cilantro: 10 grams,Lime: 1,Greek yogurt or sour cream: 2 tablespoons,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 12,
                Title = "Chicken Alfredo",
                Calories = 500,
                Protein = 30,
                Carbs = 40,
                Fat = 25,
                Recipe = "Cook the pasta in salted water until al dente. In a separate pan, cook the chicken breasts until golden and cooked through, then slice thinly. In another pan, melt butter and cook garlic until fragrant. Add heavy cream and grated Parmesan cheese, stirring until the sauce thickens. Toss the cooked pasta, chicken, and sauce together. Serve with extra Parmesan and parsley.",
                Ingredients = "Chicken breasts: 300 grams,Pasta: 250 grams,Butter: 30 grams,Garlic: 10 grams,Heavy cream: 200 milliliters,Parmesan cheese: 50 grams,Parsley: 10 grams,Salt: to taste,Pepper: to taste",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 13,
                Title = "Szechuan Pork",
                Calories = 400,
                Protein = 25,
                Carbs = 30,
                Fat = 20,
                Recipe = "Stir-fry thinly sliced pork in hot oil until browned. Add chopped onions, garlic, and ginger, cooking until fragrant. Stir in Szechuan peppercorns, soy sauce, and chili paste. Add bell peppers, mushrooms, and other vegetables, cooking until tender. Serve with steamed rice.",
                Ingredients = "Pork tenderloin: 300 grams,Onions: 100 grams,Garlic: 10 grams,Fresh ginger: 10 grams,Bell peppers: 100 grams,Mushrooms: 100 grams,Szechuan peppercorns: 1 tablespoon,Soy sauce: 2 tablespoons,Chili paste: 1 tablespoon,Oil: 2 tablespoons,Steamed rice: 200 grams",
                AccountEmail = email,
            });

            dishes.Add(new Dish()
            {
                Id = 14,
                Title = "Tandoori Chicken",
                Calories = 350,
                Protein = 30,
                Carbs = 10,
                Fat = 20,
                Recipe = "Marinate chicken in a mixture of yogurt, lemon juice, garlic, ginger, and tandoori spices for at least 2 hours. Grill or bake the chicken until cooked through and slightly charred. Serve with naan bread or rice, and garnish with cilantro.",
                Ingredients = "Chicken thighs: 400 grams,Yogurt: 100 grams,Lemon juice: 1 tablespoon,Garlic: 10 grams,Ginger: 10 grams,Tandoori spice mix: 2 tablespoons,Cilantro: 10 grams,Naan bread or rice: 200 grams",
                AccountEmail = email,
            });

            return dishes;
        }

        /*
        public static void FillMealTable()
        {
            DbHelper.db.Add(new Meal() { Id = 1, Title = "Breakfast ", FoodPlanId = 1 });
            DbHelper.db.Add(new Meal() { Id = 2, Title = "Lunch", FoodPlanId = 2 });
            DbHelper.db.Add(new Meal() { Id = 3, Title = "Lunch", FoodPlanId = 3 });
            DbHelper.db.Add(new Meal() { Id = 4, Title = "Lunch", FoodPlanId = 4 });
            DbHelper.db.Add(new Meal() { Id = 5, Title = "Breakfast ", FoodPlanId = 5 });
            DbHelper.db.Add(new Meal() { Id = 6, Title = "Lunch", FoodPlanId = 6 });
            DbHelper.db.Add(new Meal() { Id = 7, Title = "Supper", FoodPlanId = 7 });
            DbHelper.db.Add(new Meal() { Id = 8, Title = "Lunch", FoodPlanId = 8 });
            DbHelper.db.Add(new Meal() { Id = 9, Title = "Supper", FoodPlanId = 9 });
            DbHelper.db.Add(new Meal() { Id = 10, Title = "Breakfast ", FoodPlanId = 10 });
            DbHelper.db.Add(new Meal() { Id = 11, Title = "Lunch", FoodPlanId = 11 });
            DbHelper.db.Add(new Meal() { Id = 12, Title = "Lunch", FoodPlanId = 12 });
            DbHelper.db.Add(new Meal() { Id = 13, Title = "Supper", FoodPlanId = 13 });
            DbHelper.db.Add(new Meal() { Id = 14, Title = "Breakfast ", FoodPlanId = 14 });
            DbHelper.db.Add(new Meal() { Id = 15, Title = "Breakfast ", FoodPlanId = 15 });
            DbHelper.db.Add(new Meal() { Id = 16, Title = "Breakfast ", FoodPlanId = 16 });
            DbHelper.db.Add(new Meal() { Id = 17, Title = "Supper", FoodPlanId = 17 });
            DbHelper.db.Add(new Meal() { Id = 18, Title = "Breakfast ", FoodPlanId = 18 });
            DbHelper.db.Add(new Meal() { Id = 19, Title = "Supper", FoodPlanId = 19 });
            DbHelper.db.Add(new Meal() { Id = 20, Title = "Breakfast ", FoodPlanId = 20 });
            DbHelper.db.Add(new Meal() { Id = 21, Title = "Lunch", FoodPlanId = 21 });
            DbHelper.db.Add(new Meal() { Id = 22, Title = "Lunch", FoodPlanId = 22 });
            DbHelper.db.Add(new Meal() { Id = 23, Title = "Breakfast ", FoodPlanId = 23 });
            DbHelper.db.Add(new Meal() { Id = 24, Title = "Supper", FoodPlanId = 24 });
            DbHelper.db.Add(new Meal() { Id = 25, Title = "Breakfast ", FoodPlanId = 25 });
            DbHelper.db.Add(new Meal() { Id = 26, Title = "Supper", FoodPlanId = 26 });
            DbHelper.db.Add(new Meal() { Id = 27, Title = "Lunch", FoodPlanId = 27 });
            DbHelper.db.Add(new Meal() { Id = 28, Title = "Lunch", FoodPlanId = 28 });
            DbHelper.db.Add(new Meal() { Id = 29, Title = "Supper", FoodPlanId = 29 });
            DbHelper.db.Add(new Meal() { Id = 30, Title = "Lunch", FoodPlanId = 30 });
            DbHelper.db.SaveChanges();
        }
        public static void ConnectDishAndMeals()
        {
            for (int i = 1; i < Math.Min(DbHelper.db.Dishes.Count(), DbHelper.db.Meals.Count()); i++)
            {
                Meal mealFromDb = DbHelper.db.Meals.First(meal => meal.Id == i);
                Dish dishFromDb = DbHelper.db.Dishes.First(dish => dish.Id == i);
                DbHelper.db.DishMealConnectTable.Add(new DishMeal() { DishId = dishFromDb.Id, MealId = mealFromDb.Id });
            }
            DbHelper.db.SaveChanges();
        }
        public static void FillFoodPlanTable()
        {
            DbHelper.db.Add(new FoodPlan() { Id = 1, Title = "Nourish & Thrive", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "anastasiya.seliverstova@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 2, Title = "Balanced Bites", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "lilya.voloshchuk@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 3, Title = "Plate Perfection", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "maks.salo@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 4, Title = "Mindful Meals", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "markian.kravets@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 5, Title = "The Wellness Feast", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "nazar.midyk@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 6, Title = "Fuel for Life", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "nazar.valaga@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 7, Title = "Lean & Green", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "oleh.chyzhov@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 8, Title = "The Daily Dish", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "oleh.diduch@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 9, Title = "Savor & Sustain", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "oleh.kit@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 10, Title = "Healthy Habits Menu", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "olena.kupchak@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 11, Title = "FitFuel Meal Plan", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "roman.shmyhelskiy@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 12, Title = "Wholesome Eats", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "roman.torskiy@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 13, Title = "Meal Mastery", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "valeriya.ponomariova@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 14, Title = "Smart Bites", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "veronika.filippova@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 15, Title = "NutriPlan", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "yulia.tymochko@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 16, Title = "The Vital Plate", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "andriy.stefurak@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 17, Title = "Clean Plate Project", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "anna.lukianchuk@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 18, Title = "Simply Satisfied", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "anna.tkach@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 19, Title = "Energy Boost Eats", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "kristian.matiyishyn@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 20, Title = "LifeFuel Menu", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "maksym.kuzelyak@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 21, Title = "Fresh Start Food Plan", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "maksym.slipkevych@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 22, Title = "Purely Nourished", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "misha.chekan@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 23, Title = "Vibrant Eats", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "nastya.sashchack@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 24, Title = "Green Plate Special", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "olesia.rudevych@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 25, Title = "EatWell Program", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "pavlo.smahula@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 26, Title = "Happy & Healthy Plate", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "tanya.mazyr@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 27, Title = "Balanced Nutrition Blueprint", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "uliana.maydanska@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 28, Title = "The Essential Plate", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "vika.mochevynska@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 29, Title = "Simple Sustenance", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "yulia.bohatyr@gmail.com" });
            DbHelper.db.Add(new FoodPlan() { Id = 30, Title = "Whole Body Fuel", Calories = 300, Protein = 8, Carbs = 45, Fat = 7, AccountEmail = "yulia.holub@gmail.com" });
            DbHelper.db.SaveChanges();
        }
        */
        public static List<StatisticEntity> GetStatisticEntities(string email)
        {
            List<StatisticEntity> entities = new List<StatisticEntity>();

            entities.Add(new StatisticEntity() { Id = 1, Date = DateTime.Parse("01.11.2024"), Weight = 69, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 2, Date = DateTime.Parse("07.11.2024"), Weight = 70, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 3, Date = DateTime.Parse("9.11.2024"), Weight = 73, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 4, Date = DateTime.Parse("11.11.2024"), Weight = 75, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 5, Date = DateTime.Parse("15.11.2024"), Weight = 76, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 6, Date = DateTime.Parse("18.11.2024"), Weight = 74, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 7, Date = DateTime.Parse("23.11.2024"), Weight = 75, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 8, Date = DateTime.Parse("28.11.2024"), Weight = 76, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 9, Date = DateTime.Parse("30.11.2024"), Weight = 75, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 12, Date = DateTime.Parse("01.12.2024"), Weight = 73, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 13, Date = DateTime.Parse("07.12.2024"), Weight = 76, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 14, Date = DateTime.Parse("9.12.2024"), Weight = 77, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 15, Date = DateTime.Parse("11.12.2024"), Weight = 78, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 11, Date = DateTime.Parse("10.12.2024"), Weight = 79, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 16, Date = DateTime.Parse("15.12.2024"), Weight = 80, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 10, Date = DateTime.Parse("18.12.2024"), Weight = 82, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 17, Date = DateTime.Parse("23.12.2024"), Weight = 80, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 18, Date = DateTime.Parse("28.12.2024"), Weight = 86, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 19, Date = DateTime.Parse("31.12.2024"), Weight = 88, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 20, Date = DateTime.Parse("01.01.2025"), Weight = 89, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 21, Date = DateTime.Parse("07.01.2025"), Weight = 90, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 22, Date = DateTime.Parse("11.01.2025"), Weight = 92, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 23, Date = DateTime.Parse("15.01.2025"), Weight = 93, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 24, Date = DateTime.Parse("18.01.2025"), Weight = 93, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 25, Date = DateTime.Parse("20.01.2025"), Weight = 94, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 26, Date = DateTime.Parse("23.01.2025"), Weight = 93, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 27, Date = DateTime.Parse("25.01.2025"), Weight = 92, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 28, Date = DateTime.Parse("27.01.2025"), Weight = 89, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 29, Date = DateTime.Parse("28.01.2025"), Weight = 89, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 30, Date = DateTime.Parse("29.01.2025"), Weight = 87, AccountEmail = email });
            entities.Add(new StatisticEntity() { Id = 31, Date = DateTime.Parse("30.01.2025"), Weight = 85, AccountEmail = email });
            return entities;
        }
    }
}
