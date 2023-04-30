using Microsoft.EntityFrameworkCore;
#nullable disable

namespace PositiveDevelopment
{
    public partial class PositiveDevelopmentContext : DbContext
    {


        public PositiveDevelopmentContext(DbContextOptions<PositiveDevelopmentContext> options)
            : base(options)
        {
            OnConfiguring(new DbContextOptionsBuilder());
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientStatus> ClientStatuses { get; set; }
        public virtual DbSet<ContactInfo> ContactInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.ClientId).IsRequired();

                entity.Property(e => e.ContactInfoId).IsRequired();

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false).IsRequired();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false).IsRequired();

                entity.Property(e => e.ClientStatusId);

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ContactInfoId);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientStatusId);
            });

            modelBuilder.Entity<ClientStatus>(entity =>
            {
                entity.ToTable("client_status");

                entity.Property(e => e.ClientStatusId).IsRequired();

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ContactInfo>(entity =>
            {
                entity.ToTable("contact_info");

                entity.Property(e => e.ContactInfoId);

                entity.Property(e => e.AState)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("a_state");

                entity.Property(e => e.AddressOne)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("address_one");

                entity.Property(e => e.AddressTwo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("address_two");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Zip).HasColumnName("zip");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public void CreateStatuses()
        {
            this.ClientStatuses.AddRange(
                new ClientStatus
                {
                    ClientStatusId = 1,
                    Status = "New"
                },
                new ClientStatus
                {
                    ClientStatusId = 2,
                    Status = "Active"
                },
                new ClientStatus
                {
                    ClientStatusId = 3,
                    Status = "Inactive"
                }
                );

            this.SaveChanges();
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
