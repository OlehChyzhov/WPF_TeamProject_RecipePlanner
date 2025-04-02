using System.Windows;
using System.Windows.Controls;


namespace UserInterface.Views
{
    /// <summary>
    /// Interaction logic for CongratulationWindow.xaml
    /// </summary>
    public partial class CongratulationWindow : Page
    {
        public CongratulationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.MyLoginWindow.LoginBorder.Visibility = Visibility.Visible;
            App.MyLoginWindow.SurviesBorder.Visibility = Visibility.Collapsed;
            App.MyLoginWindow.SurviesFrame.Navigate(App.SurveyWindow_1);
        }
    }
}
