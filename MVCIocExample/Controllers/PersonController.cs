using MVCIocExample.Models;
using MVCIocExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCIocExample.Controllers
{
  public class PersonController : Controller
  {
    private IPersonRepository _personRepository;
    public PersonController(IPersonRepository personRepository)
    {
      _personRepository = personRepository;
    }

    /// <summary>
    /// return Index
    /// </summary>
    /// <returns></returns>
    public ActionResult Index()
    {
        List<Person> lstPerson = _personRepository.GetListPerson();
        return View("Index",lstPerson);
    }

    /// <summary>
    /// Delete first person
    /// </summary>
    /// <returns></returns>
    public ActionResult Delete()
    {
      List<Person> lstPerson =_personRepository.DeletePerson();
      return View(lstPerson);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        _personRepository.Dispose();
    }
  }
}
