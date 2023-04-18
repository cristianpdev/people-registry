using PeopleRegistry.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleRegistry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : ContentPage
    {
        public MainView(MainViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}