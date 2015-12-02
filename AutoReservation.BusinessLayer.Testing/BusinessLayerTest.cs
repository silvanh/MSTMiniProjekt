using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AutoReservation.Dal;
using System;
using System.Collections.Generic;

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
            modified.Von = new DateTime(2015, 10, 10);
            Target.UpdateReservation(original, modified);

            var updated = Target.LoadSpecificReservation(1);
            Assert.AreEqual(new DateTime(2015, 10, 10), updated.Von);
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            int oldCount = Target.LoadAutos().Count;
            Auto auto = new StandardAuto();
            auto.Marke = "Lexus";
            auto.Tagestarif = 120;
            Target.InsertAuto(auto);

            List<Auto> autos = Target.LoadAutos();
            Assert.AreNotEqual(autos.Count, oldCount);
            Assert.IsNotNull(autos.Find(a => a.Marke == "Lexus" && a.Tagestarif == 120));
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            int oldCount = Target.LoadKunden().Count;
            Kunde kunde = new Kunde();
            kunde.Nachname = "Holmes";
            kunde.Vorname = "Sherlock";
            kunde.Geburtsdatum = new DateTime(1854, 8, 1);
            Target.InsertKunde(kunde);

            Assert.IsTrue(kunde.Id > 0);

            List<Kunde> kunden = Target.LoadKunden();
            Assert.AreNotEqual(kunden.Count, oldCount);
            Assert.IsNotNull(kunden.Find(k => k.Vorname == "Sherlock" && k.Nachname == "Holmes"));
        }


        [TestMethod]
        public void Test_InsertReservation()
        {
            List<Auto> autos = Target.LoadAutos();
            List<Kunde> kunden = Target.LoadKunden();

            if (autos.Count > 0 && kunden.Count > 0)
            {
                Reservation res = new Reservation();
                res.KundeId = kunden[0].Id;
                res.AutoId = autos[0].Id;
                res.Von = new DateTime(2015, 11, 30);
                res.Bis = new DateTime(2015, 12, 13);
                Target.InsertReservation(res);

                Assert.IsTrue(res.ReservationNr > 0);
            }
            else
            {
                Assert.Inconclusive("Cannot run test, since there are no cars or customers available.");
            }
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Auto a = Target.LoadSpecificAuto(1);
            Target.DeleteAuto(a);
            Assert.IsNull(Target.LoadSpecificAuto(1));
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Kunde k = Target.LoadSpecificKunde(1);
            Target.DeleteKunde(k);
            Assert.IsNull(Target.LoadSpecificKunde(1));
        }


        [TestMethod]
        public void Test_DeleteReservation()
        {
            Reservation res = Target.LoadSpecificReservation(1);
            Target.DeleteReservation(res);
            Assert.IsNull(Target.LoadSpecificReservation(1));
        }

    }
}
