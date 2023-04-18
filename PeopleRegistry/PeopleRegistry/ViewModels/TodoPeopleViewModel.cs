using PeopleRegistry.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleRegistry.ViewModels
{
    public class TodoPeopleViewModel : ViewModel
    {
        public People People { get; private set; }

        public TodoPeopleViewModel(People people) => People = people;
    }
}
