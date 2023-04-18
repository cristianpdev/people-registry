using PeopleRegistry.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleRegistry.Repositories
{
    public interface IPeopleRepository
    {
        event EventHandler<People> OnItemAdded;
        event EventHandler<People> OnItemUpdated;

        Task<List<People>> GetPeoples();
        Task AddPeople(People people);
        Task UpdatePeople(People people);
        Task AddOrUpdate(People people);  
    }
}
