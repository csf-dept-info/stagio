using System.Data.Entity;
using Stagio.Domain.Entities;

namespace Stagio.DataLayer
{
    public class StagioDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<InternshipOffer> InternshipOffers { get; set; }
        public DbSet<InternshipApplication> InternshipApplications { get; set;}
        public DbSet<InternshipOfferDetails> InternshipOfferDetails { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<InternshipPeriod> InternshipPeriods { get; set; }
        public DbSet<DepartmentalArchives> DepartmentalArchives { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Relations between an InternshipOffer and its details.
            modelBuilder.Entity<InternshipOfferDetails>().HasKey(c => c.InternshipOfferId);

            modelBuilder.Entity<InternshipOfferDetails>()
                .HasRequired(c => c.InternshipOffer)
                .WithOptional(r => r.Details)
                .WillCascadeOnDelete();

            //Relations between an InternshipOffer and its staff members attributes
            modelBuilder.Entity<InternshipOffer>()
                .HasOptional(t => t.OtherContact)
                .WithMany()
                .HasForeignKey(t => t.OtherContactId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InternshipOffer>()
                .HasOptional(t => t.Contact)
                .WithMany()
                .HasForeignKey(t => t.ContactId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InternshipOffer>()
                .HasOptional(t => t.PersonInCharge)
                .WithMany()
                .HasForeignKey(t => t.PersonInChargeId)
                .WillCascadeOnDelete(false);

            //Relations between InternshipApplications, Students and InternshipOffers
            modelBuilder.Entity<InternshipApplication>()
                .HasRequired(t => t.InternshipOffer)
                .WithMany()
                .HasForeignKey(t => t.InternshipOfferId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<InternshipApplication>()
                .HasRequired(t => t.ApplyingStudent)
                .WithMany()
                .HasForeignKey(t => t.StudentId)
                .WillCascadeOnDelete(false);

            //Relations between Notifications, Senders and Receivers
            modelBuilder.Entity<Notification>()
                .HasRequired(t => t.Receiver)
                .WithMany(n => n.Notifications)
                .HasForeignKey(t => t.ReceiverId)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);

        }
    }
}