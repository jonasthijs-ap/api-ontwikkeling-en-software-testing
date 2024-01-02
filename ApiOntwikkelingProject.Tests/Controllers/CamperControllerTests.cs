namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class CamperControllerTests
    {
        private Mock<ICamperData> mock;
        private CamperController controller;

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
                }
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
                }
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
                }
            }
        };
        
        #region INDEX_ENDPOINT_TESTS
            [TestMethod]
            public void IndexEndpoint_WhenData_IsEmpty()
            {
                // ARRANGE
                CreateArrangements();
                List<Camper> emptyList = new List<Camper>();

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
                List<Camper> oneEntryList = mockList.GetRange(0, 1);

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
                List<Camper> manyEntryList = mockList;

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
                Camper nullCamper = null;

                // ACT
                mock.Setup(obj => obj.Get(0)).Returns(nullCamper);
                IActionResult result = controller.Details(0);

                // ASSERT
                Assert.IsTrue(result is NotFoundResult);
            }

            [TestMethod]
            public void DetailsEndpoint_WhenData_ReturnsOne()
            {
                // ARRANGE
                CreateArrangements();
                Camper expected = mockList[0];

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

                CamperCreateViewModel model = new CamperCreateViewModel
                {
                    FirstName = "Bertrand",
                    LastName = "De Laet",
                    Address = new Address { City = "Vilvoorde", Street = "Brusselstraat", HouseNumber = "15" }
                };

                // ACT
                IActionResult result = controller.Create(model);

                // ASSERT
                Assert.IsTrue(result is CreatedAtActionResult);
                mock.Verify(obj => obj.Add(It.IsAny<Camper>()), Times.Once);
            }

            [TestMethod]
            public void CreateEndpoint_WhenModelState_IsNotValid()
            {
                // ARRANGE
                CreateArrangements();

                // ACT
                CamperCreateViewModel model = new CamperCreateViewModel { };

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
                Camper camperToBeDeleted = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(camperToBeDeleted);
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
                Camper camperToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(camperToBeUpdated);
                CamperUpdateViewModel model = new CamperUpdateViewModel
                {
                    FirstName = "Andy",
                    LastName = "Geenens",
                    Address = new Address { City = "Hoogstraten", Street = "Waterkringstraat", HouseNumber = "75b" }
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
                CamperUpdateViewModel model = new CamperUpdateViewModel
                {
                    FirstName = "Vicky",
                    LastName = "Michiels",
                    Address = new Address { City = "Herentals", Street = "Stationstraat", HouseNumber = "105" }
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
                Camper camperToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(camperToBeUpdated);
                CamperUpdateViewModel model = new CamperUpdateViewModel();
                controller.ModelState.AddModelError("MockError", "MockError");
                IActionResult result = controller.Update(model, 1);

                // ASSERT
                Assert.IsTrue(result is BadRequestObjectResult);
            }
        #endregion

        private void CreateArrangements()
        {
            mock = new Mock<ICamperData>();
            controller = new CamperController(mock.Object);
        }
    }
}