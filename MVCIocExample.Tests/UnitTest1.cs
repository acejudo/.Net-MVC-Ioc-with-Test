using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCIocExample.Controllers;
using System.Web.Mvc;
using MVCIocExample.Repository;
using MVCIocExample.Models;
using System.Collections.Generic;

namespace MVCIocExample.Tests
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void TestRespository()
    {
      PersonRepository _personRepository = new PersonRepository();
      List<Person> listPerson =  _personRepository.GetListPerson();
      Assert.IsTrue(listPerson.Count >0);
    }

    [TestMethod]
    public void TestController()
    {
      PersonRepository _personRepository = new PersonRepository();
      PersonController personController = new PersonController(_personRepository);
      ActionResult actionResult =  personController.Index();
      Assert.IsNotNull(actionResult);
      var result = personController.Index() as ViewResult;
      var lstPerson = (List<Person>)result.Model;
      Assert.IsTrue(lstPerson.Count>0);
    }

    [TestMethod]
    public void TestDelete()
    {
      PersonRepository _personRepository = new PersonRepository();
      int nPerson = _personRepository.GetListPerson().Count;
      var lstPersonUpdate = _personRepository.DeletePerson();
      Assert.IsTrue(nPerson > lstPersonUpdate.Count);
      Assert.IsTrue(nPerson - lstPersonUpdate.Count == 1);
    }
  }
}
