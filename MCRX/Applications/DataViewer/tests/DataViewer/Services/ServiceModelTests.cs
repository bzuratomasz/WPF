using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataModel.Models;
using System.ServiceModel;
using Infrastructure.Interfaces.DataViewer.Services;

namespace DataViewer.Services
{
    [TestClass]
    public class ServiceModelTests
    {
        [TestMethod]
        public void UpdatePerson_CorrectId_ReturnTrue()
        {
            var instance = new Mock<IServiceModel>();
            var result = instance.Object.UpdatePerson(new PersonEntity() { Id = 0 });
            Xunit.Assert.Equal(result, false);
        }
    }
}
