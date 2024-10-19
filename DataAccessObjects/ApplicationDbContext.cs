using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessObjects
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<RoomInformation> Rooms { get; set; }

        public virtual DbSet<RoomType> RoomTypes { get; set; }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; }

        public virtual DbSet<BookingReservation> BookingReservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.EmailAddress).IsUnique();

            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerID);
            modelBuilder.Entity<RoomInformation>().HasKey(r => r.RoomID);
            modelBuilder.Entity<RoomType>().HasKey(rt => rt.RoomTypeID);
            modelBuilder.Entity<BookingReservation>().HasKey(br => br.BookingReservationID);
            modelBuilder.Entity<BookingDetail>().HasKey(bd => new { bd.BookingReservationID, bd.RoomID });


            modelBuilder.Entity<BookingReservation>()
                .HasOne(br => br.Customer)
                .WithMany(c => c.BookingReservations)
                .HasForeignKey(br => br.CustomerID);

            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.BookingReservation)
                .WithMany(br => br.BookingDetails)
                .HasForeignKey(bd => bd.BookingReservationID);
            modelBuilder.Entity<BookingDetail>()
                .HasOne(bd => bd.RoomInformation)
                .WithMany(r => r.BookingDetail)
                .HasForeignKey(bd => bd.RoomID);
            modelBuilder.Entity<RoomInformation>()
                .HasOne(r => r.RoomType)
                .WithMany(rt => rt.Rooms)
                .HasForeignKey(r => r.RoomTypeID);


            modelBuilder.Entity<RoomType>().HasData(
                new RoomType
                {
                    RoomTypeID = 1,
                    RoomTypeName = "Standard",
                    TypeDescription = "Basic room with essential amenities",
                    TypeNote = "Includes free breakfast"
                },
                new RoomType
                {
                    RoomTypeID = 2,
                    RoomTypeName = "Deluxe",
                    TypeDescription = "Spacious room with additional features",
                    TypeNote = "Sea view, includes free breakfast and gym access"
                }
            );

            modelBuilder.Entity<RoomInformation>().HasData(
                new RoomInformation
                {
                    RoomID = 1,
                    RoomNumber = "101",
                    RoomDescription = "Standard room with queen bed",
                    RoomMaxCapacity = 2,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 100m,
                    RoomTypeID = 1
                    
                },
                new RoomInformation
                {
                    RoomID = 2,
                    RoomNumber = "202",
                    RoomDescription = "Deluxe room with king bed and balcony",
                    RoomMaxCapacity = 3,
                    RoomStatus = RoomStatus.Active,
                    RoomPricePerDate = 200m,
                    RoomTypeID = 2
             
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1,
                    CustomerFullName = "Nguyen Van A",
                    Password = "password123",
                    Telephone = "0123456789",
                    EmailAddress = "nguyenvana@example.com",
                    CustomerBirthday = new DateOnly(1990, 1, 1),
                    CustomerStatus = CustomerStatus.Active
                },
                new Customer
                {
                    CustomerID = 2,
                    CustomerFullName = "Tran Thi B",
                    Password = "password456",
                    Telephone = "0987654321",
                    EmailAddress = "tranthib@example.com",
                    CustomerBirthday = new DateOnly(1985, 5, 15),
                    CustomerStatus = CustomerStatus.Active
                },

                new Customer
                {
                    CustomerID = 3,
                    CustomerFullName = "Tran Thi C",
                    Password = "123",
                    Telephone = "0987654321",
                    EmailAddress = "test@example.com",
                    CustomerBirthday = new DateOnly(1985, 5, 15),
                    CustomerStatus = CustomerStatus.Active
                }
            );
        }

        public static void Main( string[] args)
        {

        }
    }
}
