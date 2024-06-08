using Microsoft.Maui.Controls;
using RecordBookMauiApp.ViewModels;

namespace RecordBookMauiApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new UserViewModel();
        }
    }
}