using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Infrastructure.Interfaces.Services;
using Moq;

namespace DataAccessServiceTests.DataAccessService.Services
{
    [TestClass]
    public class FileManagerServiceTests
    {

        [TestMethod]
        public void DeleteRow_BadId_ReturnFalse()
        {
            var instance = new Mock<IFileManager>();
            Xunit.Assert.Equal(false, instance.Object.DeleteRow(-1));
        }
    }
}
