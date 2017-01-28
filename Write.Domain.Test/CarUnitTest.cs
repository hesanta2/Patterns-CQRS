using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Write.Domain;
using Write.Domain.Cars;
using Rhino.Mocks;

namespace Domain.Test
{
    [TestClass]
    public class CarUnitTest
    {
        private Car car;

        [TestInitialize]
        public void Setup()
        {
            this.car = new Car(1, CarClass.Normal, "Car", 200, 5);
        }

        [TestMethod]
        public void CarAggregate_Id_Is_Not_Null()
        {
            Assert.IsNotNull(car.Id);
        }

        [TestMethod]
        public void CarAggregate_Is_Typeof_AggregateRoot()
        {
            Assert.IsInstanceOfType(car, typeof(IAggregateRoot));
        }

        [TestMethod]
        public void CarAggregate_New_Is_Not_Null()
        {
            Assert.IsNotNull(new Car());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_New_With_Name_Null_ThrowsException()
        {
            Car nullNameCar = new Car(1, CarClass.Normal, null, 240, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CarAggregate_New_Without_Id_With_Name_Null_ThrowsException()
        {
            Car nullNameCar = new Car(CarClass.Normal, null, 240, 5);
        }

        [TestMethod]
        public void CarAggregate_New_Without_Id_Is_Not_Null()
        {
            Car newCar = new Car(CarClass.Normal, "Car", 240, 5);

            Assert.IsNotNull(newCar);
        }

        [TestMethod]
        public void CarAggregate_ToString_IsNotNull()
        {
            Assert.IsNotNull(car.ToString());
        }

        [TestMethod]
        public void CarAggregate_Delete_Produces_UncommittedChanges()
        {
            this.car.Delete();

            Assert.AreEqual(this.car.GetUncommittedChanges().Count(), 2);
        }

        [TestMethod]
        public void CarAggregate_CarDeletedEvent_AggregateId_Equals_1()
        {
            CarDeletedEvent @event = new CarDeletedEvent(1);

            Assert.AreEqual(@event.AggregateId, 1);
        }

        [TestMethod]
        public void CarAggregate_CarEventHandlers_Handle_CarCreatedEvent_VerifyAllExpectations()
        {
            Read.Infrastructure.Persistence.Cars.ICarRepository carRepository
                = MockRepository.GenerateMock<Read.Infrastructure.Persistence.Cars.ICarRepository>();
            carRepository.Expect(c => c.Insert(null)).IgnoreArguments();

            CarEventHandlers eventHandlers = new CarEventHandlers(carRepository);
            CarCreatedEvent @event = new CarCreatedEvent(1, Write.Domain.Cars.CarClass.Normal, "Car", 200, 5);
            eventHandlers.Handle(this, @event);

            carRepository.VerifyAllExpectations();
        }

        [TestMethod]
        public void CarAggregate_CarEventHandlers_Handle_CarDeletedEvent_VerifyAllExpectations()
        {
            Read.Infrastructure.Persistence.Cars.ICarRepository carRepository
                = MockRepository.GenerateMock<Read.Infrastructure.Persistence.Cars.ICarRepository>();
            carRepository.Expect(c => c.Delete(1)).IgnoreArguments();

            CarEventHandlers eventHandlers = new CarEventHandlers(carRepository);
            CarDeletedEvent @event = new CarDeletedEvent(1);
            eventHandlers.Handle(this, @event);

            carRepository.VerifyAllExpectations();
        }
    }
}
