using ColorsViewer.Controllers;
using ColorsViewer.DataAccess.DTO;
using ColorsViewer.Models;
using ColorsViewer.Services.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ColorsViewer.Tests
{
    [TestFixture]
    public class ColorsControllerTest
    {
        [Test]
        public void GetColorsAscendingOrderTest()
        {
            // Arrange
            var serviceMock = new Mock<IColorsService>();

            serviceMock.Setup(arg => arg.GetColors(5)).Returns(
                new List<ColorsDTO>
                {
                    new ColorsDTO { Id = 1},
                    new ColorsDTO { Id = 8 },
                    new ColorsDTO { Id = 5 },
                    new ColorsDTO { Id = 2 },
                    new ColorsDTO { Id = 4 }
                });

            var controller = new ColorsController(serviceMock.Object);

            // Act
            var result = controller.GetColors(5, false) as PartialViewResult;
            var colorsArray = ((IEnumerable<ColorModel>)result.ViewData.Model).ToArray();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, colorsArray.Length);
            Assert.AreEqual(1, colorsArray[0].Id);
            Assert.AreEqual(8, colorsArray[4].Id);
        }

        [Test]
        public void GetColorsDescendingOrderTest()
        {
            // Arrange
            var serviceMock = new Mock<IColorsService>();

            serviceMock.Setup(arg => arg.GetColors(5)).Returns(
                new List<ColorsDTO>
                {
                    new ColorsDTO { Id = 1},
                    new ColorsDTO { Id = 8 },
                    new ColorsDTO { Id = 5 },
                    new ColorsDTO { Id = 2 },
                    new ColorsDTO { Id = 4 }                   
                });

            var controller = new ColorsController(serviceMock.Object);

            // Act
            var result = controller.GetColors(5, true) as PartialViewResult;
            var colorsArray = ((IEnumerable<ColorModel>)result.ViewData.Model).ToArray();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, colorsArray.Length);
            Assert.AreEqual(8, colorsArray[0].Id);
            Assert.AreEqual(1, colorsArray[4].Id);
        }
    }
}
