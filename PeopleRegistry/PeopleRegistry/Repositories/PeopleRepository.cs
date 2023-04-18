using PeopleRegistry.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using System.Linq;

namespace PeopleRegistry.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private SQLiteAsyncConnection connection;

        private async Task CreateConnection()
        {
            if (connection != null)
                return;

            var documentPath =
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments
                );

            var databasePath =
                Path.Combine(documentPath, "Peoples.db");

            connection = new SQLiteAsyncConnection(databasePath);

            await connection.CreateTableAsync<People>();

            if (await connection.Table<People>().CountAsync() == 0)
            {
                await connection.InsertAsync(
                    new People()
                    {
                        Name = "Teste"
                    }
                );
            }

        }

        public event EventHandler<People> OnItemAdded;
        public event EventHandler<People> OnItemUpdated;

        public async Task AddPeople(People people)
        {
            await CreateConnection();
            await connection.InsertAsync(people);
            OnItemAdded?.Invoke(this, people);
        }

        public async Task AddOrUpdate(People people)
        {
            if (people.Id == 0)
            {
                await AddPeople(people);
            }
            else
            {
                await UpdatePeople(people);
            }
        }

        public async Task<List<People>> GetPeoples()
        {
            await CreateConnection();
            return await connection.Table<People>()
                .ToListAsync();
        }

        public async Task UpdatePeople(People people)
        {
            await CreateConnection();
            await connection.UpdateAsync(people);
            OnItemUpdated?.Invoke(this, people);
        }
    }
}
