using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Extensions.Configuration;
using ModelsAndInterfaces.Classes;
using ModelsAndInterfaces.Interfaces;
using MongoDB.Driver;

namespace Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        public IConfiguration _config;

        public PersonRepository(IConfiguration config)
        {
            _config = config;
            this._client = new MongoClient(_config["ConnectionStrings:peopleConfigurationPort"]);
            this._database = _client.GetDatabase(_config["ConnectionStrings:peopleConnectionString"]);
        }

        public IQueryable<Person> GetAll()
        {
            return _database.GetCollection<Person>(typeof(Person).Name).AsQueryable();
        }

        public bool Remove(Expression<Func<Person, bool>> expression)
        {
            var items = GetAll().Where(expression);
            foreach (var item in items)
            {
                Remove(item);
            }
            return true;
        }

        public bool Remove(Person person)
        {
            var collection = _database.GetCollection<Person>(typeof(Person).Name);
            collection.DeleteOneAsync(x => x.Id.Equals(person.Id));
            return true;
        }

        public bool RemoveAll()
        {
            _database.DropCollection(typeof(Person).Name);
            return true;
        }

        public bool Save(Person person)
        {
            var collection = _database.GetCollection<Person>(typeof(Person).Name);
            collection.ReplaceOneAsync(x => x.Id.Equals(person.Id), person, new UpdateOptions { IsUpsert = true });
            return true;
        }

        public bool Save(IEnumerable<Person> personItems)
        {
            foreach (var item in personItems)
            {
                Save(item);
            }
            return true;
        }

        public Person Single(Expression<Func<Person, bool>> expression)
        {
            return GetAll().Where(expression).FirstOrDefault();
        }
    }
}