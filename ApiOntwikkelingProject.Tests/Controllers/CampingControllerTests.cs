using ApiOntwikkelingProject.Controllers;
using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class CampingControllerTests
    {
        private List<Camping> mockList = new List<Camping>
        {
            new Camping
            {
                Id = 1,
                Name = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                }
            },
            new Camping
            {
                Id = 2,
                Name = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                }
            },
            new Camping
            {
                Id = 3,
                Name = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                }
            }
        };

        [TestMethod]
        public void IndexEndpoint_WhenData_IsEmpty()
        {
            List<Camping> emptyList = new List<Camping>();
            Mock<ICampingData> mock = new Mock<ICampingData>();
            mock.Setup(obj => obj.GetAll()).Returns(emptyList);

            CampingController controller = new CampingController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(emptyList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasOneEntry()
        {
            List<Camping> oneEntryList = mockList.GetRange(0, 1);

            Mock<ICampingData> mock = new Mock<ICampingData>();
            mock.Setup(obj => obj.GetAll()).Returns(oneEntryList);

            CampingController controller = new CampingController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(oneEntryList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasMultipleEntries()
        {
            List<Camping> manyEntryList = mockList;

            Mock<ICampingData> mock = new Mock<ICampingData>();
            mock.Setup(obj => obj.GetAll()).Returns(manyEntryList);

            CampingController controller = new CampingController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(manyEntryList, objectResult.Value);
        }

        [TestMethod]
        public void DetailsEndpoint_WhenData_ReturnsNothing()
        {
            NotFoundResult notFound = new NotFoundResult();
            Camping nullCamping = null;

            Mock<ICampingData> mock = new Mock<ICampingData>();
            mock.Setup(obj => obj.Get(0)).Returns(nullCamping);

            CampingController controller = new CampingController(mock.Object);
            IActionResult result = controller.Details(0);

            /* Doordat een 'NotFoundResult()' geen waarde meekrijgt om mee te vergelijken *
             * moet ik bij assertion testen of het type overeenkomt en daarom gebruik ik  *
             * het returntype van het endpoint (interface) 'IActionResult' om te testen   *
             * of het daadwerkelijk een instantie is van de 'NotFoundResult()' klasse.    */

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void DetailsEndpoint_WhenData_ReturnsOne()
        {
            Camping expected = mockList[0];

            Mock<ICampingData> mock = new Mock<ICampingData>();
            mock.Setup(obj => obj.Get(0)).Returns(expected);

            CampingController controller = new CampingController(mock.Object);
            OkObjectResult objectResult = controller.Details(0) as OkObjectResult;

            Assert.AreEqual(expected, objectResult.Value);
        }
    }
}