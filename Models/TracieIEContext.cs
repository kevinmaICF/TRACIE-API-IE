using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TRACIE_API_IE.Models;


namespace TRACIE_API_IE.Models
{
    public class TracieIEContext : DbContext
    {
        public TracieIEContext(DbContextOptions<TracieIEContext> options)
        : base(options)
        { }


        public DbSet<AspNetUsers> AspNetUsers { get; set; }
        public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }

        public DbSet<IE_ascDirUser> IE_ascDirUser { get; set; }
        public DbSet<IE_ascDirUserAdmin> IE_ascDirUserAdmin { get; set; }
        public DbSet<IE_ascDirUserNotification> IE_ascDirUserNotification { get; set; }
        public DbSet<IE_ascDirUserUnsubscribe> IE_ascDirUserUnsubscribe { get; set; }
        public DbSet<IE_ascMBFilePost> IE_ascMBFilePost { get; set; }
        public DbSet<IE_ascThreadUser> IE_ascThreadUser { get; set; }
        public DbSet<IE_ascThreadUserNotification> IE_ascThreadUserNotification { get; set; }
        public DbSet<IE_ascThreadUserUnsubscribe> IE_ascThreadUserUnsubscribe { get; set; }

        public DbSet<IE_luEventType> IE_luEventType { get; set; }
        public DbSet<IE_luMBType> IE_luMBType { get; set; }
        public DbSet<IE_luNotificationTemplate> IE_luNotificationTemplate { get; set; }
        public DbSet<IE_tblLogErr> IE_tblLogErr { get; set; }
        public DbSet<IE_tblLogEvent> IE_tblLogEvent { get; set; }
        public DbSet<IE_tblLogEventUser> IE_tblLogEventUser { get; set; }
        public DbSet<IE_tblMBDir> IE_tblMBDir { get; set; }
        public DbSet<IE_tblMBFile> IE_tblMBFile { get; set; }
        public DbSet<IE_tblMBPost> IE_tblMBPost { get; set; }
        public DbSet<IE_tblMBThread> IE_tblMBThread { get; set; }
        public DbSet<IE_tblNotification> IE_tblNotification { get; set; }
        public DbSet<IE_tblNotificationQueue> IE_tblNotificationQueue { get; set; }
        public DbSet<IE_tblPendingRejectedUser> IE_tblPendingRejectedUser { get; set; }
        

        public DbSet<IE_tblUserContactInformation> IE_tblUserContactInformation { get; set; }
        public DbSet<IE_tblUserContactInformationUnregistered> IE_tblUserContactInformationUnregistered { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<IE_ascDirUser>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascDirUserAdmin>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascDirUserNotification>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascDirUserUnsubscribe>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascMBFilePost>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascThreadUser>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascThreadUserNotification>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_ascThreadUserUnsubscribe>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_luEventType>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_luMBType>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_luMBType>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_luNotificationTemplate>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_luNotificationTemplate>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblLogEvent>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBDir>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBDir>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBDir>().Property(sample => sample.DateLatest).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBFile>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBFile>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBPost>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBPost>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBPost>().Property(sample => sample.DateLatest).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBThread>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBThread>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblMBThread>().Property(sample => sample.DateLatest).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblNotification>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblNotification>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblNotificationQueue>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblNotificationQueue>().Property(sample => sample.DateSent).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblLogEventUser>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblPendingRejectedUser>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblPendingRejectedUser>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblUserContactInformation>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblUserContactInformation>().Property(sample => sample.DateUpdated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblUserContactInformation>().Property(sample => sample.DateLogin).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblUserContactInformationUnregistered>().Property(sample => sample.DateCreated).HasColumnType("datetime");
            modelBuilder.Entity<IE_tblUserContactInformationUnregistered>().Property(sample => sample.DateUpdated).HasColumnType("datetime");


            modelBuilder.Entity<AspNetUserRoles>()
             .HasOne(p => p.AspNetUsers)
             .WithMany(b => b.AspNetUserRoles)
             .HasForeignKey(p => p.UserId)
             .HasPrincipalKey(b => b.ID);

            modelBuilder.Entity<AspNetUserRoles>()
                .HasKey(a => new { a.RoleId, a.UserId });

            modelBuilder.Entity<AspNetUserTokens>()
                .HasKey(a => new { a.UserId, a.LoginProvider, a.Name });



        }
    }
}