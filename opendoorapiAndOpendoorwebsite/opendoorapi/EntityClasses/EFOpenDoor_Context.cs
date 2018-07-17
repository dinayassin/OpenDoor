namespace OpenDoorAPI
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Infrastructure.Annotations;

    public partial class EFOpenDoor_Context : DbContext
    {
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Visitor> Visitor { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Log> Log { get; set; }
        public DbSet<UserCredntials> UserCredntials { get; set; }
        public EFOpenDoor_Context() : base("name=EFOpenDoor_Context")
        {
            //Database.SetInitializer(new EFOpenDoorInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EFOpenDoor_Context, EFOpenDoor_Configuration>());
            //without s in tbl name
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<UserProfile>()
                .ToTable("tblUserProfiles")
                .HasKey(u => u.UserID)
                .Property(t => t.UserID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Visitor>()
                .ToTable("TblVisitors")
                .HasKey(v => v.VisitorID)
                .Property(v => v.VisitorID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Visitor>()
               .HasRequired(v => v.UserProfile).WithMany().HasForeignKey(v => v.UserProfileId);

            modelBuilder.Entity<Visitor>()
                .Property(v => v.UserProfileId)
               .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[] { new IndexAttribute("userProfile") { IsUnique = true } }));

            modelBuilder.Entity<Visitor>()
                .Property(v => v.RFCCard)
                .HasMaxLength(50)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[] { new IndexAttribute("RFCCard") { IsUnique = true } }));


            modelBuilder.Entity<UserCredntials>()
                .ToTable("tblUserCredntials")
             .HasKey(u => u.UserCredntialsID)
              .Property(t => t.UserCredntialsID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserCredntials>()
                .HasRequired(v => v.UserProfile).WithMany().HasForeignKey(v => v.UserProfileId);

            modelBuilder.Entity<UserCredntials>()
                .Property(v => v.UserProfileId)
               .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[] { new IndexAttribute("userProfile") { IsUnique = true } }));


            modelBuilder.Entity<Role>()
              .ToTable("TblRoles")
              .HasKey(r => r.RoleID)
              .Property(r => r.RoleID)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);



            modelBuilder.Entity<Log>()
               .ToTable("tblLogs")
               .HasKey(l => l.LogID)
              .Property(l => l.LogID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Log>()
              .Property(x => x.Picture)
              .IsOptional();

            modelBuilder.Entity<Log>()
                .HasRequired(l => l.UserProfile).WithMany().HasForeignKey(l => l.UserProfileId);


        }
    }
}
