using AutoReservation.Dal;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {
        public void loadAutos()
        {
            using (var context = new AutoReservationEntities())
            {
                var autos = context.Auto;
            }
        }

        public void insertAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Add(auto);
                context.SaveChanges();
            }
        }

        public void updateAuto(Auto original, Auto modified)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Attach(original);
                context.Entry(original).CurrentValues.SetValues(modified);
                context.SaveChanges();
            }
        }

        public void deleteAuto(Auto auto)
        {
            using (var context = new AutoReservationEntities())
            {
                context.Auto.Attach(auto);
                context.Auto.Remove(auto);
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