using BusinessLogic;
using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for SecondSurveyWindow.xaml
    /// </summary>
    public partial class SecondSurveyWindow : Page
    {
        public SecondSurveyWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button PressedButton = (Button)sender;

            if (PressedButton == LessThan1000Button)
            {
                DietCreator.StepsPerDay = 999;
                UpTo3000Button.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_3);
            }
            else if (PressedButton == UpTo3000Button)
            {
                DietCreator.StepsPerDay = 3000;
                UpTo3000Button.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_3);
            }
            else if (PressedButton == UpTo7000Button)
            {
                DietCreator.StepsPerDay = 7000;
                UpTo7000Button.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_3);
            }
            else if (PressedButton == MoreThan7000Button)
            {
                DietCreator.StepsPerDay = 10001;
                MoreThan7000Button.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_3);
            }
            else if (PressedButton == NoIdeaButton)
            {
                DietCreator.StepsPerDay = 0;
                NoIdeaButton.Background = System.Windows.Media.Brushes.DarkGray;
                App.SurviesFrame.Navigate(App.SurveyWindow_3);
            }
        }
    }
}
