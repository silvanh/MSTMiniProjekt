using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void Test_GetAutos()
        {
            List<AutoDto> autos = Target.GetAutos();
            Assert.AreEqual(autos.Count, 3);
            Assert.AreEqual(autos[0].Marke, "Fiat Punto");
            Assert.AreEqual(autos[1].Marke, "VW Golf");
            Assert.AreEqual(autos[2].Marke, "Audi S6");
        }

        [TestMethod]
        public void Test_GetKunden()
        {
            List<KundeDto> kunden = Target.GetKunden();
            Assert.AreEqual(kunden.Count, 4);
            Assert.AreEqual(kunden[0].Vorname, "Anna");
            Assert.AreEqual(kunden[1].Vorname, "Timo");
            Assert.AreEqual(kunden[2].Vorname, "Martha");
            Assert.AreEqual(kunden[3].Vorname, "Rainer");
        }

        [TestMethod]
        public void Test_GetReservationen()
        {
            List<ReservationDto> reservationen = Target.GetReservationen();
            Assert.AreEqual(reservationen.Count, 3);
            Assert.AreEqual(reservationen[0].Kunde, 1);
            Assert.AreEqual(reservationen[1].Kunde, 2);
            Assert.AreEqual(reservationen[2].Kunde, 3);
        }

        [TestMethod]
        public void Test_GetAutoById()
        {
            Assert.AreEqual(Target.GetAuto(2).Marke, "VW Golf");
        }

        [TestMethod]
        public void Test_GetKundeById()
        {
            Assert.AreEqual(Target.GetKunde(4).Vorname, "Rainer");
        }

        [TestMethod]
        public void Test_GetReservationByNr()
        {
            Assert.AreEqual(Target.GetReservation(1).Auto, 1);
        }

        [TestMethod]
        public void Test_GetReservationByIllegalNr()
        {
            Assert.AreEqual(Target.GetReservation(4), null);
        }

        [TestMethod]
        public void Test_InsertAuto()
        {
            AutoDto auto = new AutoDto();
            auto.Id = 4;
            auto.Marke = "Tesla Model S";
            auto.Tagestarif = 100;
            auto.AutoKlasse = AutoKlasse.Luxusklasse;

            Target.AddAuto(auto);
            Assert.AreEqual(Target.GetAutos().Count, 4);
            Assert.AreEqual(Target.GetAuto(4).Marke, "Tesla Model S");
        }

        [TestMethod]
        public void Test_InsertKunde()
        {
            KundeDto kunde = new KundeDto();
            kunde.Id = 5;
            kunde.Nachname = "Lebowski";
            kunde.Vorname = "The Dude";
            kunde.Geburtsdatum = new DateTime(10000);
            
            Target.AddKunde(kunde);
            Assert.AreEqual(Target.GetKunden().Count, 5);
            Assert.AreEqual(Target.GetKunde(5).Nachname, "Lebowski");
        }

        [TestMethod]
        public void Test_InsertReservation()
        {
            ReservationDto reservation = new ReservationDto();
            reservation.ReservationNr = 4;
            reservation.Kunde = Target.GetKunde(4);
            reservation.Auto = Target.GetAuto(1);
            reservation.Bis = new DateTime(10000);
            reservation.Von = new DateTime(9999);

            Target.AddReservation(reservation);
            Assert.AreEqual(Target.GetReservationen().Count, 4);
            Assert.AreEqual(Target.GetReservation(4).Kunde.Id, 4);
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test not implemented.");
        }

        [TestMethod]
        public void Test_DeleteKunde()
        {
            Target.DeleteKunde(Target.GetKunde(1));
            Assert.AreEqual(Target.GetKunden().Count, 3);
            Assert.IsNull(Target.GetKunde(1));
        }

        [TestMethod]
        public void Test_DeleteAuto()
        {
            Target.DeleteAuto(Target.GetAuto(2));
            Assert.AreEqual(Target.GetAutos().Count, 2);
            Assert.IsNull(Target.GetKunde(2));

        }

        [TestMethod]
        public void Test_DeleteReservation()
        {
            Target.DeleteReservation(Target.GetReservation(3));
            Assert.AreEqual(Target.GetReservationen().Count, 2);
            Assert.IsNull(Target.GetReservation(3));
        }
    }
}
