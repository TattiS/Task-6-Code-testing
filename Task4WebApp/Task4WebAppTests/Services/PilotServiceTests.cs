using System;
using System.Collections.Generic;
using System.Text;
using AirportService.Services;
using DALProject.Models;
using NUnit.Framework;
using Task4WebAppTests.Fakes;

namespace Task4WebAppTests.Services
{
	[TestFixture]
    public class PilotServiceTests
    {
		private readonly FakeUnitOfWork _unit;
		private readonly FakeRepository<Pilot> _repo;

		public PilotServiceTests()
		{
			_repo = new FakeRepository<Pilot>();
			_unit = new FakeUnitOfWork();
			_unit.SetRepository(_repo);
		}

		[SetUp]
		public void TestSetUp()
		{
			Pilot pilot1 = new Pilot() { Id = 1, Name = "Adam", Surname = "Benn", BirthDate = DateTime.Parse("1978-11-01"), Experience = DateTime.Today - DateTime.Parse("2004-12-01") };
			Pilot pilot2 = new Pilot() { Id = 2, Name = "Max", Surname = "Payne", BirthDate = DateTime.Parse("1964-06-12"), Experience = DateTime.Today - DateTime.Parse("1987-03-24") };
			Pilot pilot3 = new Pilot() { Id = 3, Name = "Francis", Surname = "Castle", BirthDate = DateTime.Parse("1974-02-01"), Experience = DateTime.Today - DateTime.Parse("1992-04-30") };
			_repo.dataSet.AddRange(new[] { pilot1, pilot2, pilot3});
		}

		[TearDown]
		public void TestTearDown()
		{
			_repo.dataSet.Clear();
		}

		[Test]
		public void Create_When_gets_null_Then_return_exception()
		{
			////Arrange

			//var fakePilotRepo = A.Fake<Repository<Pilot>>();

			//A.CallTo(() => fakePilotRepo.GetEntities(null, null, string.Empty)).Returns(new List<Pilot> { new Pilot { Id = 45 }, new Pilot { Id = 46 }, new Pilot { Id = 47 } });

			//var fakeUnitOfWork = A.Fake<IUnitOfWork>();

			//A.CallTo(() => fakeUnitOfWork.PilotsRepo).Returns(fakePilotRepo);

			//var service = new PilotService(fakeUnitOfWork as UnitOfWork);

			////Act & Assert
			//Assert.Throws<ArgumentNullException>(() => service.CreatePilot(null));

			var service = new PilotService(_unit);

			Assert.Throws<ArgumentNullException>(() => service.CreatePilot(null));

		}
	}
}
