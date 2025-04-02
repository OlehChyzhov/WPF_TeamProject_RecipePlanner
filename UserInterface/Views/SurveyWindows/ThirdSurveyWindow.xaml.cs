using BusinessLogic;
using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for ThirdSurveyWindow.xaml
    /// </summary>
    public partial class ThirdSurveyWindow : Page
    {
        public ThirdSurveyWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button PressedButton = (Button)sender;
            if (PressedButton == NotVeryActiveButton)
            {
                DietCreator.ActivityLevel = DataAccess.ActivityLevel.Inactive;
                NotVeryActiveButton.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_4);


            }
            else if (PressedButton == ActiveButton)
            {
                DietCreator.ActivityLevel = DataAccess.ActivityLevel.Medium;
                ActiveButton.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_4);
            }
            else if (PressedButton == VeryActiveButton)
            {
                DietCreator.ActivityLevel = DataAccess.ActivityLevel.Active;
                VeryActiveButton.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_4);
            }
        }
    }
}
