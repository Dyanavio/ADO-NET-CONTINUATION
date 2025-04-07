using ADO_NET_CONTINUATION.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Numerics;

namespace ADO_NET_CONTINUATION.Data
{
    public class DataContext : DbContext
    {
        // Data context is the mapping of the entire database
        // Tables are represent by collections (DbSet)
        public DbSet<Entities.User> Users { get; set; }
        public DbSet<Entities.UserAccess> UsersAccesses { get; set; }
        public DbSet<Entities.UserRole> UsersRoles { get; set; }
        public DataContext() : base() { }
        // Setting the context includes overriding two methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Setting the connection to the database
            IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            // Defining driver type
            optionsBuilder.UseSqlServer(config.GetConnectionString("LocalDb"));

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting the bonds between entities
            modelBuilder.Entity<Entities.UserAccess>().HasIndex(ua => ua.Login).IsUnique();
            modelBuilder.Entity<Entities.UserAccess>()
                .HasOne(ua => ua.User) // setting the bonds through navigation properties
                .WithMany() // Navigation properties
                .HasForeignKey(ua => ua.UserId) // Those instructions are not mandatory 
                .HasPrincipalKey(u => u.Id); // if you stick to the naming
            // Seeding
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = "SelfRegistered",
                    Description = "Self-registered user",
                    CanCreate = false,
                    CanRead = false,
                    CanUpdate = false,
                    CanDelete = false
                },
                new UserRole
                {
                    Id = "Employee",
                    Description = "Company's employee",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = false,
                    CanDelete = false
                },
                new UserRole
                {
                    Id = "Moderator",
                    Description = "Content editor",
                    CanCreate = false,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true
                },
                new UserRole
                {
                    Id = "Administrator",
                    Description = "System administrator",
                    CanCreate = true,
                    CanRead = true,
                    CanUpdate = true,
                    CanDelete = true
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = Guid.Parse("7687bebd-e8a3-4b28-abc8-8fc9cc403a8d"),
                    Name = "Lev Landau",
                    Email = "landau14@gmail.com",
                    Birthdate = new DateTime(1998, 3, 15),
                    RegisteredAt = new DateTime(2025, 3, 10)
                },
                new User
                {
                    Id = Guid.Parse("bdf41cd9-c0f1-4349-8a44-4e67755d0415"),
                    Name = "Dmitri Sivukhin",
                    Email = "sivukhon51gmail.com",
                    Birthdate = new DateTime(1999, 5, 11),
                    RegisteredAt = new DateTime(2025, 3, 15)
                },
                new User
                {
                    Id = Guid.Parse("03767d46-aab3-4cc4-989c-a696a7fdd434"),
                    Name = "Dmitri Shostakovich",
                    Email = "shostakovich178gmail.com",
                    Birthdate = new DateTime(1989, 7, 10),
                    RegisteredAt = new DateTime(2024, 8, 5)
                },
                new User
                {
                    Id = Guid.Parse("0d156354-89f1-4d58-a735-876b7add59d2"),
                    Name = "Ruu Lion",
                    Email = "astread35gmail.com",
                    Birthdate = new DateTime(2005, 2, 15),
                    RegisteredAt = new DateTime(2024, 12, 20)
                },
                new User
                {
                    Id = Guid.Parse("a3c55a79-05ea-4053-ad3c-7301f3b7a7e2"),
                    Name = "Bell Cranel",
                    Email = "cranel757gmail.com",
                    Birthdate = new DateTime(2005, 2, 15),
                    RegisteredAt = new DateTime(2024, 12, 20)
                },
                new User
                {
                    Id = Guid.Parse("eadb0b3b-523e-478b-88ee-b6cf57cbc05d"),
                    Name = "Task Asahina",
                    Email = "takt21@gmail.com",
                    Birthdate = new DateTime(2001, 12, 21),
                    RegisteredAt = new DateTime(2025, 1, 21)
                },
                new User
                {
                    Id = Guid.Parse("a0f7b463-6eef-4a70-8444-789bbea23369"),
                    Name = "Asuna Yuuki",
                    Email = "yuuki15@gmail.com",
                    Birthdate = new DateTime(1999, 10, 21),
                    RegisteredAt = new DateTime(2025, 2, 2)
                }
            );

            modelBuilder.Entity<UserAccess>().HasData(
                new UserAccess
                {
                    Id = Guid.Parse("e29b6a1a-5bc7-4f42-9fa4-db25de342b42"),
                    UserId = Guid.Parse("7687bebd-e8a3-4b28-abc8-8fc9cc403a8d"),
                    Login = "jakiv",
                    Salt = "Salt1",
                    Dk = "Salt1123",
                    RoleId = "SelfRegistered"
                },
                new UserAccess
                {
                    Id = Guid.Parse("fb4ad18c-d916-4708-be71-a9bbcf1eb806"),
                    UserId = Guid.Parse("bdf41cd9-c0f1-4349-8a44-4e67755d0415"),
                    Login = "storozh",
                    Salt = "Salt2",
                    Dk = "Salt2123",
                    RoleId = "Employee"
                },
                new UserAccess
                {
                    Id = Guid.Parse("b31355b7-aa02-4b10-afda-eb9ec8294e78"),
                    UserId = Guid.Parse("03767d46-aab3-4cc4-989c-a696a7fdd434"),
                    Login = "dnistr",
                    Salt = "Salt3",
                    Dk = "Salt3123",
                    RoleId = "SelfRegistered"
                },
                new UserAccess
                {
                    Id = Guid.Parse("92cd36b8-ea5a-4cbb-a232-268d942c97fd"),
                    UserId = Guid.Parse("0d156354-89f1-4d58-a735-876b7add59d2"),
                    Login = "dina",
                    Salt = "Salt4",
                    Dk = "Salt4123",
                    RoleId = "Employee"
                },
                new UserAccess
                {
                    Id = Guid.Parse("7a38a3aa-de9f-4519-bb48-eeb86c1efcdf"),
                    UserId = Guid.Parse("0d156354-89f1-4d58-a735-876b7add59d2"),
                    Login = "dina@ukr.net",
                    Salt = "Salt5",
                    Dk = "Salt5123",
                    RoleId = "Moderator"
                },
                new UserAccess
                {
                    Id = Guid.Parse("f1ea6b3f-0021-417b-95c8-f6cd333d7207"),
                    UserId = Guid.Parse("a3c55a79-05ea-4053-ad3c-7301f3b7a7e2"),
                    Login = "romashko",
                    Salt = "Salt6",
                    Dk = "Salt6123",
                    RoleId = "SelfRegistered"
                },
                new UserAccess
                {
                    Id = Guid.Parse("8806ca58-8daa-4576-92ba-797de42ffaa7"),
                    UserId = Guid.Parse("eadb0b3b-523e-478b-88ee-b6cf57cbc05d"),
                    Login = "erstenuk",
                    Salt = "Salt7",
                    Dk = "Salt7123",
                    RoleId = "Employee"
                },
                new UserAccess
                {
                    Id = Guid.Parse("97191468-a02f-4a78-927b-9ea660e9ea36"),
                    UserId = Guid.Parse("eadb0b3b-523e-478b-88ee-b6cf57cbc05d"),
                    Login = "erstenuk@ukr.net",
                    Salt = "Salt8",
                    Dk = "Salt8123",
                    RoleId = "Administrator"
                },
                new UserAccess
                {
                    Id = Guid.Parse("6a1d3de4-0d78-4d7d-8f6a-9e52694ff2ee"),
                    UserId = Guid.Parse("a0f7b463-6eef-4a70-8444-789bbea23369"),
                    Login = "bondarko",
                    Salt = "Salt9",
                    Dk = "Salt9123",
                    RoleId = "SelfRegistered"
                }
            );
        }
    }
}
