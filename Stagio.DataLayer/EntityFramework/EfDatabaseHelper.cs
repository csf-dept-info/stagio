using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer.EntityFramework
{
    public class EfDatabaseHelper : IDatabaseHelper
    {
        
        public void DropCreateDatabaseIfModelChanges()
        {
            SqlConnection.ClearAllPools();

            var initializer = new DropCreateDatabaseIfModelChanges<StagioDbContext>();
            Database.SetInitializer(initializer); 
            
        }


        public void DeleteAll()
        {
            var context = new StagioDbContext();
            context.Database.Initialize(false);
            context.Database.Delete();
            context.Database.CreateIfNotExists();
            context.SaveChanges();
        }

        public void CleanDatabase()
        {
            var context = new StagioDbContext();
            context.Database.Initialize(false);
            RemoveAll(context);
            context.SaveChanges();
        }

        private void RemoveAll(StagioDbContext context)
        {
            RemoveOfferApplication(context);
            RemoveInternshipOffer(context);
            RemoveStudent(context);
            RemoveStaffMember(context);
            RemoveOfferDetail(context);
            RemoveNotification(context);
        }

        private void RemoveStudent(StagioDbContext context)
        {
            IEnumerable<Student> query = context.Students.ToList().AsEnumerable();

            foreach (Student q in query)
            {
                context.Students.Remove(q);
            }
            context.SaveChanges();

        }

        private void RemoveOfferDetail(StagioDbContext context)
        {
            IEnumerable<InternshipOfferDetails> query = context.InternshipOfferDetails.ToList().AsEnumerable();

            foreach (InternshipOfferDetails q in query)
            {
                context.InternshipOfferDetails.Remove(q);
            }
            context.SaveChanges();
        }

        private void RemoveStaffMember(StagioDbContext context)
        {
            IEnumerable<StaffMember> query = context.StaffMembers.ToList().AsEnumerable();

            foreach (StaffMember q in query)
            {
                context.StaffMembers.Remove(q);
            }
            context.SaveChanges();
        }

        private void RemoveOfferApplication(StagioDbContext context)
        {
            IEnumerable<InternshipApplication> query = context.InternshipApplications.ToList().AsEnumerable();

            foreach (InternshipApplication q in query)
            {
                context.InternshipApplications.Remove(q);
            }
            context.SaveChanges();
        }

        private void RemoveInternshipOffer(StagioDbContext context)
        {
            IEnumerable<InternshipOffer> query = context.InternshipOffers.ToList().AsEnumerable();

            foreach (InternshipOffer q in query)
            {
                context.InternshipOffers.Remove(q);
            }
            context.SaveChanges();
        }

        private void RemoveNotification(StagioDbContext context)
        {
            IEnumerable<Notification> query = context.Notifications.ToList().AsEnumerable();

            foreach (Notification q in query)
            {
                context.Notifications.Remove(q);
            }
            context.SaveChanges();
        }

    }
}

