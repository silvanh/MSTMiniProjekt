using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService :IAutoReservationService
    {
        AutoReservationBusinessComponent businessComponent = new AutoReservationBusinessComponent();
        public void AddAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.InsertAuto(DtoConverter.ConvertToEntity(auto));
        }

        public void AddKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.InsertKunde(DtoConverter.ConvertToEntity(kunde));
        }

        public void AddReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.InsertReservation(DtoConverter.ConvertToEntity(reservation));
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessComponent.DeleteAuto(DtoConverter.ConvertToEntity(auto));
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessComponent.DeleteKunde(DtoConverter.ConvertToEntity(kunde));
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessComponent.DeleteReservation(DtoConverter.ConvertToEntity(reservation));
        }

        public AutoDto GetAuto(int id)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(businessComponent.LoadSpecificAuto(id));
        }

        public List<AutoDto> GetAutos()
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDtos(businessComponent.LoadAutos());
        }

        public KundeDto GetKunde(int id)
        {
            return DtoConverter.ConvertToDto(businessComponent.LoadSpecificKunde(id));
        }

        public List<KundeDto> GetKunden()
        {
            return DtoConverter.ConvertToDtos(businessComponent.LoadKunden());
        }

        public ReservationDto GetReservation(int id)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(businessComponent.LoadSpecificReservation(id));
        }

        public List<ReservationDto> GetReservationen()
        {
            return DtoConverter.ConvertToDtos(businessComponent.LoadReservationen());
        }

        public void UpdateAuto(AutoDto original, AutoDto modified)
        {
            WriteActualMethod();
            businessComponent.UpdateAuto(DtoConverter.ConvertToEntity(original), DtoConverter.ConvertToEntity(modified));
        }

        public void UpdateKunde(KundeDto original, KundeDto modified)
        {
            WriteActualMethod();
            businessComponent.UpdateKunde(DtoConverter.ConvertToEntity(original), DtoConverter.ConvertToEntity(modified));
        }

        public void UpdateReservation(ReservationDto original, ReservationDto modified)
        {
            WriteActualMethod();
            businessComponent.UpdateReservation(DtoConverter.ConvertToEntity(original), DtoConverter.ConvertToEntity(modified));
        }

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }
    }
}