using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using System.ServiceModel;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        [OperationContract]
        List<AutoDto> getAutos();

        [OperationContract]
        AutoDto getAuto(int id);

        [OperationContract]
        void addAuto(AutoDto auto);

        [OperationContract]
        void updateAuto(AutoDto auto);

        [OperationContract]
        void deleteAuto(AutoDto auto);

        [OperationContract]
        List<ReservationDto> getReservations();

        [OperationContract]
        ReservationDto getReservation(int id);

        [OperationContract]
        void addReservation(ReservationDto reservation);

        [OperationContract]
        void updateReservation(ReservationDto reservation);

        [OperationContract]
        void deleteReservation(ReservationDto reservation);

        [OperationContract]
        List<KundeDto> getKunden();

        [OperationContract]
        KundeDto getKunde(int id);

        [OperationContract]
        void addKunde(KundeDto kunde);

        [OperationContract]
        void updateKunde(KundeDto kunde);

        [OperationContract]
        void deleteKunde(KundeDto kunde);
    }
}
