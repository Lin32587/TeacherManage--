namespace StudentsManagement.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StuDb : DbContext
    {
        public StuDb()
            : base("name=StuDb")
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Score> Score { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .Property(e => e.CID)
                .IsFixedLength();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.Course)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Score>()
                .Property(e => e.SID)
                .IsFixedLength();

            modelBuilder.Entity<Score>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<Score>()
                .Property(e => e.CID)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .Property(e => e.UserID)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Score)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
