using ApiOntwikkelingProject.Controllers;
using ApiOntwikkelingProject.Entities;
using ApiOntwikkelingProject.Entities.Properties;
using ApiOntwikkelingProject.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class ClubControllerTests
    {
        private List<Club> mockList = new List<Club>
        {
            new Club
            {
                Id = 1,
                Name = "Test",
                HeadOfficeAddress = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                PartnerWithCampingId = 2
            },
            new Club
            {
                Id = 2,
                Name = "Test",
                HeadOfficeAddress = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                PartnerWithCampingId = 3
            },
            new Club
            {
                Id = 3,
                Name = "Test",
                HeadOfficeAddress = new Address
                {
                    Street = "Test",
                    HouseNumber = "0",
                    City = "Test"
                },
                PartnerWithCampingId = 1
            }
        };

        [TestMethod]
        public void IndexEndpoint_WhenData_IsEmpty()
        {
            List<Club> emptyList = new List<Club>();
            Mock<IClubData> mock = new Mock<IClubData>();
            mock.Setup(obj => obj.GetAll()).Returns(emptyList);

            ClubController controller = new ClubController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(emptyList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasOneEntry()
        {
            List<Club> oneEntryList = mockList.GetRange(0, 1);

            Mock<IClubData> mock = new Mock<IClubData>();
            mock.Setup(obj => obj.GetAll()).Returns(oneEntryList);

            ClubController controller = new ClubController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(oneEntryList, objectResult.Value);
        }

        [TestMethod]
        public void IndexEndpoint_WhenData_HasMultipleEntries()
        {
            List<Club> manyEntryList = mockList;

            Mock<IClubData> mock = new Mock<IClubData>();
            mock.Setup(obj => obj.GetAll()).Returns(manyEntryList);

            ClubController controller = new ClubController(mock.Object);
            OkObjectResult objectResult = controller.Index() as OkObjectResult;

            Assert.AreEqual(manyEntryList, objectResult.Value);
        }

        [TestMethod]
        public void DetailsEndpoint_WhenData_ReturnsNothing()
        {
            NotFoundResult notFound = new NotFoundResult();
            Club nullClub = null;

            Mock<IClubData> mock = new Mock<IClubData>();
            mock.Setup(obj => obj.Get(0)).Returns(nullClub);

            ClubController controller = new ClubController(mock.Object);
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
            Club expected = mockList[0];

            Mock<IClubData> mock = new Mock<IClubData>();
            mock.Setup(obj => obj.Get(0)).Returns(expected);

            ClubController controller = new ClubController(mock.Object);
            OkObjectResult objectResult = controller.Details(0) as OkObjectResult;

            Assert.AreEqual(expected, objectResult.Value);
        }
    }
}