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
            Assert.AreEqual(reservationen[0].Kunde.Id, 1);
            Assert.AreEqual(reservationen[1].Kunde.Id, 2);
            Assert.AreEqual(reservationen[2].Kunde.Id, 3);
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
            // SCHMALENTIN! mer vergliicht kei autos mit nummere :-D
            Assert.AreEqual(Target.GetReservation(1).Auto.Id, 1);
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
            kunde.Geburtsdatum = new DateTime(1942, 12, 4);
            
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
            reservation.Bis = new DateTime(2011, 11, 11);
            reservation.Von = new DateTime(2012, 12, 12);

            Target.AddReservation(reservation);
            Assert.AreEqual(Target.GetReservationen().Count, 4);
            Assert.AreEqual(Target.GetReservation(4).Kunde.Id, 4);
        }

        [TestMethod]
        public void Test_UpdateAuto()
        {
            int id = 1;
            AutoDto auto = Target.GetAuto(id);
            auto.Marke = "Wayne Enterprises";
            auto.Tagestarif = 10000;

            Target.UpdateAuto(Target.GetAuto(id), auto);

            AutoDto updated = Target.GetAuto(id);
            Assert.AreEqual(auto.Marke, updated.Marke);
            Assert.AreEqual(auto.Tagestarif, updated.Tagestarif);
        }

        [TestMethod]
        public void Test_UpdateKunde()
        {
            int id = 2;
            KundeDto kunde = Target.GetKunde(id);
            kunde.Nachname = "none";
            kunde.Vorname = "Kvothe";
            Target.UpdateKunde(Target.GetKunde(id), kunde);

            KundeDto updated = Target.GetKunde(id);
            Assert.AreEqual(updated.Nachname, kunde.Nachname);
            Assert.AreEqual(updated.Vorname, kunde.Vorname);
        }

        [TestMethod]
        public void Test_UpdateReservation()
        {
            int id = 1;
            ReservationDto res = Target.GetReservation(id);
            res.Von = new DateTime(2016, 10, 10);
            res.Bis = new DateTime(2016, 11, 10);
            Target.UpdateReservation(Target.GetReservation(id), res);

            ReservationDto updated = Target.GetReservation(id);
            Assert.AreEqual(updated.Von, res.Von);
            Assert.AreEqual(updated.Bis, res.Bis);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<AutoDto>))]
        public void Test_UpdateAutoWithOptimisticConcurrency()
        {
            int id = 1;
            AutoDto auto = Target.GetAuto(id);
            auto.Marke = "Wayne Enterprises";
            auto.Tagestarif = 10000;

            AutoDto original = Target.GetAuto(id);
            Target.UpdateAuto(original, auto);

            auto.AutoKlasse = AutoKlasse.Standard;
            auto.Marke = "Lexus";
            Target.UpdateAuto(original, auto);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<KundeDto>))]
        public void Test_UpdateKundeWithOptimisticConcurrency()
        {
            int id = 2;
            KundeDto kunde = Target.GetKunde(id);
            kunde.Nachname = "none";
            kunde.Vorname = "Kvothe";

            KundeDto original = Target.GetKunde(id);
            Target.UpdateKunde(original, kunde);

            kunde.Nachname = "Bales";
            kunde.Vorname = "Arlen";
            Target.UpdateKunde(original, kunde);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ReservationDto>))]
        public void Test_UpdateReservationWithOptimisticConcurrency()
        {
            int id = 1;
            ReservationDto res = Target.GetReservation(id);
            res.Von = new DateTime(2016, 10, 10);
            res.Bis = new DateTime(2016, 11, 10);
            ReservationDto original = Target.GetReservation(id);
            Target.UpdateReservation(original, res);

            res.Auto = Target.GetAuto(2);
            Target.UpdateReservation(original, res);
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
            // Böse Valentin! nöd eifach Code kopiere und vergesse apasse:-D
            Assert.IsNull(Target.GetAuto(2));

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
