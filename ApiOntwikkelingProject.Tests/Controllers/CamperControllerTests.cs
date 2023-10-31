using ApiOntwikkelingProject.Controllers;
using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class CamperControllerTests
    {
        private List<Camper> mockList = new List<Camper>
        {
            new Camper
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                MemberFromClubId = 1
            },
            new Camper
            {
                Id = 2,
                FirstName = "Test",
                LastName = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                MemberFromClubId = 3
            },
            new Camper
            {
                Id = 3,
                FirstName = "Test",
                LastName = "Test",
                Address = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                MemberFromClubId = 2
            }
        };

        [TestMethod]
        public void IndexEndpoint_WhenData_IsEmpty()
        {
            List<Camper> emptyList = new List<Camper>();
            Mock<ICamperData> mock = new Mock<ICamperData>();
            mock.Setup(obj => obj.GetAll()).Returns(emptyList);

            CamperController controller = new CamperController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(emptyList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasOneEntry()
        {
            List<Camper> oneEntryList = mockList.GetRange(0, 1);

            Mock<ICamperData> mock = new Mock<ICamperData>();
            mock.Setup(obj => obj.GetAll()).Returns(oneEntryList);

            CamperController controller = new CamperController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(oneEntryList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasMultipleEntries()
        {
            List<Camper> manyEntryList = mockList;

            Mock<ICamperData> mock = new Mock<ICamperData>();
            mock.Setup(obj => obj.GetAll()).Returns(manyEntryList);

            CamperController controller = new CamperController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(manyEntryList, objectResult.Value);
        }

        [TestMethod]
        public void DetailsEndpoint_WhenData_ReturnsNothing()
        {
            NotFoundResult notFound = new NotFoundResult();
            Camper nullCamper = null;

            Mock<ICamperData> mock = new Mock<ICamperData>();
            mock.Setup(obj => obj.Get(0)).Returns(nullCamper);

            CamperController controller = new CamperController(mock.Object);
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
            Camper expected = mockList[0];

            Mock<ICamperData> mock = new Mock<ICamperData>();
            mock.Setup(obj => obj.Get(0)).Returns(expected);

            CamperController controller = new CamperController(mock.Object);
            OkObjectResult objectResult = controller.Details(0) as OkObjectResult;

            Assert.AreEqual(expected, objectResult.Value);
        }
    }
}