using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        List<AutoDto> GetAutos();

        [OperationContract]
        AutoDto GetAuto(int id);

        [OperationContract]
        void AddAuto(AutoDto auto);

        [OperationContract]
        [FaultContract(typeof(FaultException<AutoDto>))]
        void UpdateAuto(AutoDto original, AutoDto modified);

        [OperationContract]
        void DeleteAuto(AutoDto auto);

        [OperationContract]
        List<ReservationDto> GetReservationen();

        [OperationContract]
        ReservationDto GetReservation(int id);

        [OperationContract]
        void AddReservation(ReservationDto reservation);

        [OperationContract]
        [FaultContract(typeof(FaultException<ReservationDto>))]
        void UpdateReservation(ReservationDto original, ReservationDto modified);

        [OperationContract]
        void DeleteReservation(ReservationDto reservation);

        [OperationContract]
        List<KundeDto> GetKunden();

        [OperationContract]
        KundeDto GetKunde(int id);

        [OperationContract]
        void AddKunde(KundeDto kunde);

        [OperationContract]
        [FaultContract(typeof(FaultException<KundeDto>))]
        void UpdateKunde(KundeDto original, KundeDto modified);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);
    }
}
