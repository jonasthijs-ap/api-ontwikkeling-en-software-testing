namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class ClubControllerTests
    {
        private Mock<IClubData> mock;
        private ClubController controller;

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
                }
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
                }
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
                }
            }
        };
        
        #region INDEX_ENDPOINT_TESTS
            [TestMethod]
            public void IndexEndpoint_WhenData_IsEmpty()
            {
                // ARRANGE
                CreateArrangements();
                List<Club> emptyList = new List<Club>();

                // ACT
                mock.Setup(obj => obj.GetAll()).Returns(emptyList);
                OkObjectResult objectResult = controller.Index() as OkObjectResult;

                // ASSERT
                Assert.AreEqual(emptyList, objectResult.Value);
            }

            [TestMethod]
            public void IndexEndpoint_WhenData_HasOneEntry()
            {
                // ARRANGE
                CreateArrangements();
                List<Club> oneEntryList = mockList.GetRange(0, 1);

                // ACT
                mock.Setup(obj => obj.GetAll()).Returns(oneEntryList);
                OkObjectResult objectResult = controller.Index() as OkObjectResult;

                // ASSERT
                Assert.AreEqual(oneEntryList, objectResult.Value);
            }

            [TestMethod]
            public void IndexEndpoint_WhenData_HasMultipleEntries()
            {
                // ARRANGE
                CreateArrangements();
                List<Club> manyEntryList = mockList;

                // ACT
                mock.Setup(obj => obj.GetAll()).Returns(manyEntryList);
                OkObjectResult objectResult = controller.Index() as OkObjectResult;

                // ASSERT
                Assert.AreEqual(manyEntryList, objectResult.Value);
            }
        #endregion

        #region DETAILS_ENDPOINT_TESTS
            [TestMethod]
            public void DetailsEndpoint_WhenData_ReturnsNothing()
            {
                // ARRANGE
                CreateArrangements();
                Club nullClub = null;

                // ACT
                mock.Setup(obj => obj.Get(0)).Returns(nullClub);
                IActionResult result = controller.Details(0);

                // ASSERT
                Assert.IsTrue(result is NotFoundResult);
            }

            [TestMethod]
            public void DetailsEndpoint_WhenData_ReturnsOne()
            {
                // ARRANGE
                CreateArrangements();
                Club expected = mockList[0];

                // ACT
                mock.Setup(obj => obj.Get(0)).Returns(expected);
                OkObjectResult objectResult = controller.Details(0) as OkObjectResult;

                // ASSERT
                Assert.AreEqual(expected, objectResult.Value);
            }
        #endregion

        #region CREATE_ENDPOINT_TESTS
            [TestMethod]
            public void CreateEndpoint_When_CreatedSuccessfully()
            {
                // ARRANGE
                CreateArrangements();

                ClubCreateViewModel model = new ClubCreateViewModel
                {
                    Name = "Aalstse Kampeervereniging",
                    HeadOfficeAddress = new Address { City = "Aalst", Street = "Grote Markt", HouseNumber = "47" }
                };

                // ACT
                IActionResult result = controller.Create(model);

                // ASSERT
                Assert.IsTrue(result is CreatedAtActionResult);
                mock.Verify(obj => obj.Add(It.IsAny<Club>()), Times.Once);
            }

            [TestMethod]
            public void CreateEndpoint_WhenModelState_IsNotValid()
            {
                // ARRANGE
                CreateArrangements();

                // ACT
                ClubCreateViewModel model = new ClubCreateViewModel { };

                controller.ModelState.AddModelError("MockError", "MockError");
                BadRequestObjectResult result = controller.Create(model) as BadRequestObjectResult;

                // ASSERT
                Assert.IsTrue(result is BadRequestObjectResult);
            }
        #endregion

        #region DELETE_ENDPOINT_TESTS
            [TestMethod]
            public void DeleteEndpoint_WhenId_IsNotFound()
            {
                // ARRANGE
                CreateArrangements();

                // ACT
                IActionResult result = controller.Delete(5000);

                // ASSERT
                Assert.IsTrue(result is NotFoundResult);
            }

            [TestMethod]
            public void DeleteEndpoint_When_DeletedSuccessfully()
            {
                // ARRANGE
                CreateArrangements();
                Club clubToBeDeleted = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(clubToBeDeleted);
                IActionResult result = controller.Delete(1);

                // ASSERT
                Assert.IsTrue(result is NoContentResult);
            }
        #endregion

        #region UPDATE_ENDPOINT_TESTS
            [TestMethod]
            public void UpdateEndpoint_When_UpdatedSuccessfully()
            {
                // ARRANGE
                CreateArrangements();
                Club clubToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(clubToBeUpdated);
                ClubUpdateViewModel model = new ClubUpdateViewModel
                {
                    Name = "De Reisgenoten",
                    HeadOfficeAddress = new Address { City = "Arendonk", Street = "Dorpsplein", HouseNumber = "12" }
                };
                IActionResult result = controller.Update(model, 1);

                // ASSERT
                Assert.IsTrue(result is NoContentResult);
            }

            [TestMethod]
            public void UpdateEndpoint_WhenId_IsNotFound()
            {
                // ARRANGE
                CreateArrangements();

                // ACT
                ClubUpdateViewModel model = new ClubUpdateViewModel
                {
                    Name = "Pasar Voerenstreek",
                    HeadOfficeAddress = new Address { City = "Voeren", Street = "Vaalsebaan", HouseNumber = "135" }
                };
                IActionResult result = controller.Update(model, 5000);

                // ASSERT
                Assert.IsTrue(result is NotFoundResult);
            }

            [TestMethod]
            public void UpdateEndpoint_WhenModelState_IsNotValid()
            {
                // ARRANGE
                CreateArrangements();
                Club clubToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(clubToBeUpdated);
                ClubUpdateViewModel model = new ClubUpdateViewModel();
                controller.ModelState.AddModelError("MockError", "MockError");
                IActionResult result = controller.Update(model, 1);

                // ASSERT
                Assert.IsTrue(result is BadRequestObjectResult);
            }
        #endregion

        private void CreateArrangements()
        {
            mock = new Mock<IClubData>();
            controller = new ClubController(mock.Object);
        }
    }
}