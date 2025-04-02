namespace UserInterface
{
    using System.Windows;
    using System.Windows.Controls;
    using UserInterface.MVVM;
    using UserInterface.Views;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class MainWindow : Window
    {
        private SharedViewModel sharedVM = new SharedViewModel();

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            App.RightSideFrame = this.RightSideFrame;
            App.MyAccountWindow = new AccountWindow();
            App.MyRecipesWindow = new RecipesWindow();
            App.MySettingsWindow = new SettingsWindow();
            App.MyStatisticsWindow = new StatisticsWindow();
            App.MyEditRecipeWindow = new UpdateRecipePage();
            App.MyAddRecipeWindow = new AddrecipePage();
            App.MySeeRecipeWindow = new SeeRecipePage();
            App.MyManageEntitesPage = new ManageEntitiesPage();

            App.MyAccountWindow.DataContext = this.sharedVM.AccountVM; // Bad idea
            App.MySettingsWindow.DataContext = this.sharedVM.AccountVM; // Bad idea

            App.RightSideFrame.Navigate(App.MyAccountWindow);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            switch (pressedButton.Name)
            {
                case "AccountButton":
                    this.RightSideFrame.Navigate(App.MyAccountWindow);
                    this.sharedVM.AccountVM.DisplayStatistics();
                    break;
                case "StatisticsButton":
                    this.RightSideFrame.Navigate(App.MyStatisticsWindow);
                    break;
                case "RecipesButton":
                    this.RightSideFrame.Navigate(App.MyRecipesWindow);
                    break;
                case "SettingsButton":
                    this.RightSideFrame.Navigate(App.MySettingsWindow);
                    break;
            }
        }
    }
}