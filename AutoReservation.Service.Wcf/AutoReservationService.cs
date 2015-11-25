using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService :IAutoReservationService
    {

        public void addAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void addKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void addReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public void deleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void deleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void deleteReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public AutoDto getAuto(int id)
        {
            throw new NotImplementedException();
        }

        public List<AutoDto> getAutos()
        {
            throw new NotImplementedException();
        }

        public KundeDto getKunde(int id)
        {
            throw new NotImplementedException();
        }

        public List<KundeDto> getKunden()
        {
            throw new NotImplementedException();
        }

        public ReservationDto getReservation(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReservationDto> getReservations()
        {
            throw new NotImplementedException();
        }

        public void updateAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public void updateKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public void updateReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
}