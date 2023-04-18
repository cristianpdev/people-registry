using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PeopleRegistry.Models;

namespace PeopleRegistry.Repositories.Postgres
{
    public class PeopleRepository : IPeopleRepository
    {
        public event EventHandler<People> OnItemAdded;
        public event EventHandler<People> OnItemUpdated;

        public Task AddOrUpdate(People people)
        {
            throw new NotImplementedException();
        }

        public Task AddPeople(People people)
        {
            throw new NotImplementedException();
        }

        public Task<List<People>> GetPeoples()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePeople(People people)
        {
            throw new NotImplementedException();
        }
    }
}
