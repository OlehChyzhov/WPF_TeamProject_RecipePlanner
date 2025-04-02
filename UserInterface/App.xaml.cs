using System.Windows;
using System.Windows.Controls;
using UserInterface.Views;

namespace UserInterface
{
    public partial class App : Application
    {
        // Startup windows
        public static LoginWindow MyLoginWindow;

        //Additional information windows
        public static FirstSurveyWindow SurveyWindow_1;
        public static SecondSurveyWindow SurveyWindow_2;
        public static ThirdSurveyWindow SurveyWindow_3;
        public static FourthSurveyWindow SurveyWindow_4;
        public static FiveSurveyWindow SurveyWindow_5;
        public static CongratulationWindow SurveyWindow_6;

        public static Frame SurviesFrame;

        // Main application window and it's components
        public static Frame RightSideFrame;
        public static MainWindow MyMainWindow;

        // Main windows
        public static AccountWindow? MyAccountWindow;
        public static RecipesWindow? MyRecipesWindow;
        public static SettingsWindow? MySettingsWindow;
        public static StatisticsWindow? MyStatisticsWindow;

        // Secondary windows
        public static UpdateRecipePage MyEditRecipeWindow;
        public static AddrecipePage MyAddRecipeWindow;
        public static SeeRecipePage MySeeRecipeWindow;
        public static ManageEntitiesPage MyManageEntitesPage;
        public void Application_Startup(object sender, StartupEventArgs e)
        {
            MyLoginWindow = new LoginWindow();
            MyLoginWindow.Show();

            SurveyWindow_1 = new FirstSurveyWindow();
            SurveyWindow_2 = new SecondSurveyWindow();
            SurveyWindow_3 = new ThirdSurveyWindow();
            SurveyWindow_4 = new FourthSurveyWindow();
            SurveyWindow_5 = new FiveSurveyWindow();
            SurveyWindow_6 = new CongratulationWindow();
        }
    }
}
