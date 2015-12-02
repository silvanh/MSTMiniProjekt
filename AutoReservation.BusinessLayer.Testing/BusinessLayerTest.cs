using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }


        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void Test_UpdateAuto()
        {
            var original = Target.LoadSpecificAuto(1);
            var modified = Target.LoadSpecificAuto(1);
            modified.Marke = "BMW";
            Target.UpdateAuto(original, modified);
            var updated = Target.LoadSpecificAuto(1);
            Assert.AreEqual("BMW",updated.Marke);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            var original = Target.LoadSpecificKunde(1);
            var modified = Target.LoadSpecificKunde(1);
            modified.Nachname = "Testman";
            Target.UpdateKunde(original, modified);
            var updated = Target.LoadSpecificKunde(1);
            Assert.AreEqual("Testman", updated.Nachname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            var original = Target.LoadSpecificReservation(1);
            var modified = Target.LoadSpecificReservation(1);
            modified.Von = new System.DateTime(10000);
            Target.UpdateReservation(original, modified);
            var updated = Target.LoadSpecificReservation(1);
            Assert.AreEqual(new System.DateTime(10000), updated.Von);
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }
        [TestMethod]
        public void Test_InsertKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }


        [TestMethod]
        public void Test_InsertReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }
        [TestMethod]
        public void Test_DeleteKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }


        [TestMethod]
        public void Test_DeleteReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

    }
}
