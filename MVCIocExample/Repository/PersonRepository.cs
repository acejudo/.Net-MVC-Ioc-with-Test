using MVCIocExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCIocExample.Repository
{

  public interface IPersonRepository : IDisposable
  {
    List<Person> GetListPerson();
    List<Person> DeletePerson();
  }
  public class PersonRepository : IPersonRepository
  {
    public List<Person> listPerson = new List<Person>()
    {
      new Person() { Name = "Nombre1", Age = 17, IsSome = true },
      new Person() { Name = "Nombre2", Age = 22, IsSome = false },
      new Person() { Name = "Nombre3", Age = 25, IsSome = true },
    };


    public List<Person> GetListPerson()
    {
      return listPerson;
    }

    public List<Person> DeletePerson()
    {
      listPerson.RemoveAt(0);
      return listPerson;
    }

    public void Dispose()
    {
      
    }
  }


}