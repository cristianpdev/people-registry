using PeopleRegistry.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PeopleRegistry.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PeopleView : ContentPage
    {
        public PeopleView(PeopleViewModel viewModel)
        {
            InitializeComponent();

            viewModel.Navigation = Navigation;
            BindingContext = viewModel;
        }
    }
}