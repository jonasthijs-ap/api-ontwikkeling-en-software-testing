namespace ApiOntwikkelingProject.Tests.Controllers
{
    [TestClass]
    public class CampingControllerTests
    {
        private Mock<ICampingData> mock;
        private CampingController controller;

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
        
        #region INDEX_ENDPOINT_TESTS
            [TestMethod]
            public void IndexEndpoint_WhenData_IsEmpty()
            {
                // ARRANGE
                CreateArrangements();
                List<Camping> emptyList = new List<Camping>();

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
                List<Camping> oneEntryList = mockList.GetRange(0, 1);

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
                List<Camping> manyEntryList = mockList;

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
                Camping nullCamping = null;

                // ACT
                mock.Setup(obj => obj.Get(0)).Returns(nullCamping);
                IActionResult result = controller.Details(0);

                // ASSERT
                Assert.IsTrue(result is NotFoundResult);
            }

            [TestMethod]
            public void DetailsEndpoint_WhenData_ReturnsOne()
            {
                // ARRANGE
                CreateArrangements();
                Camping expected = mockList[0];

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

                CampingCreateViewModel model = new CampingCreateViewModel
                {
                    Name = "Camping Berkenbosch",
                    Address = new Address { City = "Nijlen", Street = "Vossenweg", HouseNumber = "66" }
                };

                // ACT
                IActionResult result = controller.Create(model);

                // ASSERT
                Assert.IsTrue(result is CreatedAtActionResult);
                mock.Verify(obj => obj.Add(It.IsAny<Camping>()), Times.Once);
            }

            [TestMethod]
            public void CreateEndpoint_WhenModelState_IsNotValid()
            {
                // ARRANGE
                CreateArrangements();

                // ACT
                CampingCreateViewModel model = new CampingCreateViewModel { };

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
                Camping campingToBeDeleted = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(campingToBeDeleted);
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
                Camping campingToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(campingToBeUpdated);
                CampingUpdateViewModel model = new CampingUpdateViewModel
                {
                    Name = "Camping Millenium",
                    Address = new Address { City = "Asse", Street = "De Dam", HouseNumber = "1" }
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
                CampingUpdateViewModel model = new CampingUpdateViewModel
                {
                    Name = "Camping De Zwaan",
                    Address = new Address { City = "Turnhout", Street = "Weg naar Mol", HouseNumber = "285" }
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
                Camping campingToBeUpdated = mockList.First();

                // ACT
                mock.Setup(obj => obj.Get(1)).Returns(campingToBeUpdated);
                CampingUpdateViewModel model = new CampingUpdateViewModel();
                controller.ModelState.AddModelError("MockError", "MockError");
                IActionResult result = controller.Update(model, 1);

                // ASSERT
                Assert.IsTrue(result is BadRequestObjectResult);
            }
        #endregion

        private void CreateArrangements()
        {
            mock = new Mock<ICampingData>();
            controller = new CampingController(mock.Object);
        }
    }
}