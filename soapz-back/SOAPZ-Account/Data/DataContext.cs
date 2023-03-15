using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace SOAPZ_Account.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();

            //Seeder.Seed(this);
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreList> GenreLists { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }

    internal class Seeder
    {
        public static void Seed(DataContext db)
        {
            db.Languages.Add(new Language { Name = "English" });
            db.SaveChanges();
            db.PublishingHouses.Add(new PublishingHouse { Name = "Bloomsbury" });
            db.SaveChanges();
            db.Authors.Add(new Author { FullName = "Joanne Rowling", Description = "Wrote Harry Potter, a seven-volume children's fantasy series published from 1997 to 2007" });
            db.SaveChanges();
            db.Books.AddRange(new Book[]
            {
                new Book
                {
                    Title = "Harry Potter and the Philosopher's Stone",
                    Description = "The first novel in the Harry Potter series and Rowling's debut novel, it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh birthday, when he receives a letter of acceptance to Hogwarts School of Witchcraft and Wizardry",
                    YearPublished = 1997,
                    Isbn = "0 - 7475 - 3269 - 9",
                    Pages = 223,
                    Amount = 4,
                    AuthorId = 1,
                    PublishingHouseId = 1,
                    LanguageId = 1,
                },
                new Book
                {
                    Title = "Harry Potter and the Chamber of Secrets",
                    Description = "The plot follows Harry's second year at Hogwarts School of Witchcraft and Wizardry, during which a series of messages on the walls of the school's corridors warn that the \"Chamber of Secrets\" has been opened and that the \"heir of Slytherin\" would kill all pupils who do not come from all-magical families",
                    YearPublished = 1998,
                    Isbn = "0 - 7475 - 3849 - 2",
                    Pages = 251,
                    Amount = 3,
                    AuthorId = 1,
                    PublishingHouseId = 1,
                    LanguageId = 1,
                }
            });

            db.SaveChanges();
        }
    }
}
