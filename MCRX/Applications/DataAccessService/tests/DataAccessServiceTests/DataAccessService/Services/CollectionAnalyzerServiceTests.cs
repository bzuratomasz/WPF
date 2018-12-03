using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Infrastructure.Interfaces.Services;
using DataModel;
using DataModel.Models;
using System.Collections.Generic;
using DataAccessService.Services;

namespace DataAccessServiceTests.DataAccessService.Services
{
    [TestClass]
    public class CollectionAnalyzerServiceTests
    {
        private PersonsList _personList = new PersonsList();
        private CollectionAnalyzerService _instance = new CollectionAnalyzerService();

        public CollectionAnalyzerServiceTests()
        {
            _personList.PersonList = new List<PersonEntity>();

            _personList.PersonList.Add(new PersonEntity()
            {
                Id = 1,
                FirstName = "John"
            });
        }

        [TestMethod]
        public void UpdarePerson_CorrectEntity_UpdatedValues()
        {
            var result = _instance.UpdatePersonLogic(new PersonEntity()
            {
                Id = 1,
                FirstName = "Jack"
            }, _personList);

            Xunit.Assert.Equal(result.PersonList[0].FirstName, "Jack");
        }

        [TestMethod]
        public void UpdarePerson_BadId_NoUpdate()
        {
            var result = _instance.UpdatePersonLogic(new PersonEntity()
            {
                Id = 2,
                FirstName = "Jack"
            }, _personList);

            Xunit.Assert.NotEqual(result.PersonList[0].FirstName, "Jack");
        }

        [TestMethod]
        public void UpdarePerson_BadId_ThrowException()
        {
            Xunit.Assert.Throws(typeof(Exception), () => _instance.UpdatePersonLogic(new PersonEntity()
            {
                Id = 0
            }, _personList));
        }
    }
}
