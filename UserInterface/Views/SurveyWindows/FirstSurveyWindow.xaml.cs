using BusinessLogic;
using DataAccess;
using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for FirstSurveyWindow.xaml
    /// </summary>
    public partial class FirstSurveyWindow : Page
    {
        public FirstSurveyWindow()
        {
            InitializeComponent();
        }

        private void LoseWeightButton_Click(object sender, RoutedEventArgs e)
        {
            DietCreator.WeightGoal = WeightGoal.Lose;
            LoseWeightButton.Background = System.Windows.Media.Brushes.DarkGray;
            App.SurviesFrame.Navigate(App.SurveyWindow_2);
        }


        private void GainWeightButton_Click(object sender, RoutedEventArgs e)
        {
            DietCreator.WeightGoal = WeightGoal.Gain;
            GainWeightButton.Background = System.Windows.Media.Brushes.DarkGray;
            App.SurviesFrame.Navigate(App.SurveyWindow_2);
        }

        private void MaintainWeightButton_Click(object sender, RoutedEventArgs e)
        {
            DietCreator.WeightGoal = WeightGoal.Maintain;
            MaintainWeightButton.Background = System.Windows.Media.Brushes.DarkGray;
            App.SurviesFrame.Navigate(App.SurveyWindow_2);
        }

    }
}
