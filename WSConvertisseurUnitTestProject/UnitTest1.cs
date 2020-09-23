using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSConvertisseur.Controllers;
using WSConvertisseur.Model;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetById_ExistingIdPassedReturnOkObject()
        {
            var _controller = new DeviceController();

            var result = _controller.GetById(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas du bon type");
        }

        public void GetById_NoneExistingIdPassedReturn404()
        {
            var _controller = new DeviceController();

            var result = _controller.GetById(4);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas de 404");
        }

        [TestMethod]
        public void GetById_ExistingPassed_ReturnsRightItem()
        {
            // Arrange
            var _controller = new DeviceController();
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Device), "Pas une Devise");
            Assert.AreEqual(new Device(1, "Dollar", 1.08), (Device)result.Value, "Devises pas identiques");
        }
    }
}
