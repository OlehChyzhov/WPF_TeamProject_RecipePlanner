using BusinessLogic;
using DataAccess;
using System.Windows;
using System.Windows.Controls;

namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for FourthSurveyWindow.xaml
    /// </summary>
    public partial class FourthSurveyWindow : Page
    {
        public FourthSurveyWindow()
        {
            InitializeComponent();
        }

        private void MaleRadioButton_Click(object sender, RoutedEventArgs e)
        {
            DietCreator.Gender = Sex.Male;
        }

        private void FemaleRadioButton_Click(object sender, RoutedEventArgs e)
        {
            DietCreator.Gender = Sex.Female;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DietCreator.Age = int.Parse(AgeTextBox.Text);
                App.SurviesFrame.Navigate(App.SurveyWindow_5);
            }
            catch { MessageBox.Show("Enter valid age", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }

        }
    }

}