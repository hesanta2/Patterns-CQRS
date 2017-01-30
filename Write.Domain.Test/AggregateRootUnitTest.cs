using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CQRS.Write.Domain;
using System.Collections.Generic;
using CQRS.Write.Domain.Events;
using CQRS.Write.Domain.Test.ForTesting;

namespace CQRS.Write.Domain.Test
{
    [TestClass]
    public class AggregateRootUnitTest
    {

        private IAggregateRoot aggregateRoot;
        private TestAggregateRoot testAggregateRoot;

        [TestInitialize]
        public void Setup()
        {
            aggregateRoot = new TestAggregateRoot();
            testAggregateRoot = (TestAggregateRoot)aggregateRoot;
        }

        [TestMethod]
        public void AggregateRoot_Is_TypeOf_AggregateRoot()
        {
            Assert.IsInstanceOfType(aggregateRoot, typeof(AggregateRoot<int>));
        }

        [TestMethod]
        public void AggregateRoot_GetId_Equals_Id_Equals_Zero()
        {
            IAggregateRoot<int> aggregateRootGeneric = (IAggregateRoot<int>)aggregateRoot;

            Assert.AreEqual(aggregateRoot.GetId(), aggregateRootGeneric.Id);
            Assert.AreEqual(aggregateRoot.GetId(), 0);
        }

        [TestMethod]
        public void AggregateRoot_Version_Equals_Zero()
        {
            Assert.AreEqual(aggregateRoot.Version, 0);
        }

        [TestMethod]
        public void AggregateRoot_GetUncommittedChanges_GratherThan_Zero()
        {
            TestAgrregateRootCreateEvent @event = new TestAgrregateRootCreateEvent(1);
            testAggregateRoot.ApplyChange(@event);

            Assert.IsTrue(aggregateRoot.GetUncommittedChanges().Count() > 0);
            Assert.AreEqual(aggregateRoot.GetId(), 1);
            Assert.AreEqual(@event.Version, 1);
        }

        [TestMethod]
        public void AggregateRoot_MarkChangesAsCommitted_Makes_GetUncommittedChanges_Equals_Zero()
        {
            testAggregateRoot.ApplyChange(new TestAgrregateRootCreateEvent(1));
            aggregateRoot.MarkChangesAsCommitted();

            Assert.IsTrue(aggregateRoot.GetUncommittedChanges().Count() == 0);
        }

        [TestMethod]
        public void AggregateRoot_LoadsFormHistory_Id_Equals_One()
        {
            aggregateRoot.LoadsFromHistory(new List<IEvent>() { new TestAgrregateRootCreateEvent(1) });

            Assert.AreEqual(aggregateRoot.GetId(), 1);
        }

    }
}
