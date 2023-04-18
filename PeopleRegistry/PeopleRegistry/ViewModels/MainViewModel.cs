using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using PeopleRegistry.Repositories;
using PeopleRegistry.Models;
using PeopleRegistry.ViewModels;
using PeopleRegistry.Views;

namespace PeopleRegistry.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly PeopleRepository repository;

        public ObservableCollection<TodoPeopleViewModel> People { get; set; }

        public MainViewModel(PeopleRepository repository)
        {
            repository.OnItemAdded += (sender, people) => People.Add(CreateTodoPeopleViewModel(people));
            repository.OnItemUpdated += (sender, people) => Task.Run(async () => await LoadData());

            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var people = await repository.GetPeoples();
            var peopleViewModels = people.Select(i => CreateTodoPeopleViewModel(i));
            People = new ObservableCollection<TodoPeopleViewModel>(peopleViewModels);
        }

        private TodoPeopleViewModel CreateTodoPeopleViewModel(People people)
        {
            var peopleViewModel = new TodoPeopleViewModel(people);
            return peopleViewModel;
        }
        public ICommand AddItem => new Command(async () => {

            var peopleView = Resolver.Resolve<PeopleView>();
            await Navigation.PushAsync(peopleView);

        });
    }
}
