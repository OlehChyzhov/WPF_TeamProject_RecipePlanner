using DataAccess.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace UserInterface.Views
{
    public partial class UpdateRecipePage : Page
    {
        public ObservableCollection<string> Ingredients = new ObservableCollection<string>();

        Account LoginedAccount;
        public UpdateRecipePage()
        {
            InitializeComponent();
        }
    }
}
