using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ModelsAndInterfaces.Classes;

namespace ModelsAndInterfaces.Interfaces
{
    public interface IPersonRepository
    {
        bool Remove(Expression<Func<Person, bool>> expression);
        bool Remove(Person person);
        bool RemoveAll();
        Person Single(Expression<Func<Person, bool>> expression);
        IQueryable<Person> GetAll();
        bool Save(Person person);
        bool Save(IEnumerable<Person> personItems);
    }
}