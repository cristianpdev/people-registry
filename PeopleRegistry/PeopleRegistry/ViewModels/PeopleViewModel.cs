using PeopleRegistry.Models;
using PeopleRegistry.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PeopleRegistry.ViewModels
{
    public class PeopleViewModel : ViewModel
    {
        private readonly PeopleRepository repository;

        public People People { get; set; }

        public PeopleViewModel(PeopleRepository repository)
        {
            this.repository = repository;
            People = new People();
        }

        public ICommand Save => new Command(async () => {

            await repository.AddOrUpdate(People);
            await Navigation.PopAsync();

        });

    }
}
