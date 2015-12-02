using AutoReservation.Dal;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        public List<Auto> LoadAutos()
        {
            using (var context = new AutoReservationEntities())
            {
                var autos =  context.Auto.ToList();
                return autos;
            }
        }

        public Auto LoadSpecificAuto(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                var query = from a in context.Auto
                            where a.Id == id
                            select a;
                return query.First();
                //return context.Auto.Where(a=>a.Id==id).First();
            }
        }

        public void InsertAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Add(auto);
                context.SaveChanges();
            }
        }

        public void UpdateAuto(Auto original, Auto modified)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Attach(auto);
                context.Auto.Remove(auto);
                context.SaveChanges();
            }
        }

        public List<Reservation> LoadReservationen()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservation.ToList();
            }
        }

        public Reservation LoadSpecificReservation(int reservationNr)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Reservation.ToList().Where(r => r.ReservationNr == reservationNr).First();
            }
        }

        public void InsertReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservation.Add(reservation);
                context.SaveChanges();
            }
        }

        public void UpdateReservation(Reservation original, Reservation modified)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservation.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Reservation.Attach(reservation);
                context.Reservation.Remove(reservation);
                context.SaveChanges();
            }
        }

        public List<Kunde> LoadKunden()
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunde.ToList();
            }
        }

        public Kunde LoadSpecificKunde(int id)
        {
            using (var context = new AutoReservationEntities())
            {
                return context.Kunde.ToList().Where(k => k.Id == id).First();
            }
        }

        public void InsertKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunde.Add(kunde);
                context.SaveChanges();
            }
        }

        public void UpdateKunde(Kunde original, Kunde modified)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunde.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Kunde.Attach(kunde);
                context.Kunde.Remove(kunde);
                context.SaveChanges();
            }
        }

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }
    }
}