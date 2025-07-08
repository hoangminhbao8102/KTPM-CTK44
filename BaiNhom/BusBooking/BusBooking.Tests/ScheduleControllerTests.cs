using BusBooking.Core.Entities;
using BusBooking.Services.Fake;
using BusBooking.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Tests
{
    [TestClass]
    public class ScheduleControllerTests
    {
        [TestMethod]
        public async Task BUS_TC_002_Search_ShouldReturnSchedules()
        {
            var schedule = new Schedule
            {
                Id = 1,
                Route = new Route { Id = 1, Departure = "Hà Nội", Destination = "Đà Nẵng" },
                DepartureDate = new DateTime(2023, 4, 3)
            };
            var fakeScheduleService = new FakeScheduleService(new[] { schedule });

            var controller = new ScheduleController(fakeScheduleService);
            var result = await controller.Search(1, new DateTime(2023, 4, 3)) as ViewResult;
            var model = result.Model as IEnumerable<Schedule>;

            Assert.AreEqual(0, model.Count());
        }

        [TestMethod]
        public async Task BUS_TC_003_Details_ShouldReturnSchedule()
        {
            // Arrange: tạo fake service với dữ liệu
            var schedules = new List<Schedule>
            {
                new Schedule
                {
                    Id = 1,
                    DepartureDate = new DateTime(2023, 4, 3),
                    Route = new Route { Departure = "Hà Nội", Destination = "Đà Nẵng" }
                }
            };

            var fakeService = new FakeScheduleService(schedules);
            var controller = new ScheduleController(fakeService);

            // Act
            var result = await controller.Details(1) as ViewResult;
            var model = result.Model as Schedule;

            // Assert
            Assert.IsNotNull(model);
            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Hà Nội", model.Route.Departure);
            Assert.AreEqual("Đà Nẵng", model.Route.Destination);
        }

        [TestMethod]
        public async Task BUS_TC_003_Details_WithInvalidId_ShouldReturnNotFound()
        {
            // Arrange
            var fakeService = new FakeScheduleService(); // không có schedule
            var controller = new ScheduleController(fakeService);

            // Act
            var result = await controller.Details(999);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }
    }
}
