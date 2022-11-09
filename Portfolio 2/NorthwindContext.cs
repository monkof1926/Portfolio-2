using DataLayer.Domain;
using Microsoft.EntityFrameworkCore;
using Portfolio_2.Domain;

namespace DataLayer
{
    public class NorthwindContext : DbContext   
    {
        public DbSet<User> users { get; set; }
        public DbSet<Person> name_basics { get; set; }
        public DbSet<Movie> title_basics { get; set; }
        public DbSet<Bookmarks> name_bookmarks { get; set; }
        public DbSet<Bookmarks> title_bookmarks { get; set; }
        public DbSet<Rating> name_ratings { get; set; }
        public DbSet<Rating> title_ratings { get; set; }
        public DbSet<RatingHistory> name_ratings_hist { get; set; }
        public DbSet<RatingHistory> title_ratings_hist { get; set; }
        public DbSet<SearchHistory> searchhistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("host=localhost;db=imdbtest;uid=nikol;pwd=1702Ruc");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.username).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(x => x.password).HasColumnName("password");


            modelBuilder.Entity<Person>().ToTable("name_basics");
            modelBuilder.Entity<Person>().Property(x => x.nameID).HasColumnName("nconst");
            modelBuilder.Entity<Person>().Property(x => x.fullName).HasColumnName("primaryname");
            modelBuilder.Entity<Person>().Property(x => x.birthYear).HasColumnName("birthyear");
            modelBuilder.Entity<Person>().Property(x => x.deathYear).HasColumnName("deathyear");

            modelBuilder.Entity<Person>().ToTable("charaters_played");
            modelBuilder.Entity<Person>().Property(x => x.featuredInMovie).HasColumnName("tconst");
            modelBuilder.Entity<Person>().Property(x => x.featuredInRole).HasColumnName("characters");
            modelBuilder.Entity<Person>().Property(x => x.featuredInProffesion).HasColumnName("category");



            modelBuilder.Entity<Movie>().ToTable("title_basics");
            modelBuilder.Entity<Movie>().Property(x => x.movieID).HasColumnName("tconst");
            modelBuilder.Entity<Movie>().Property(x => x.title).HasColumnName("primarytitle");
            modelBuilder.Entity<Movie>().Property(x => x.startYear).HasColumnName("startyear");
            modelBuilder.Entity<Movie>().Property(x => x.endYear).HasColumnName("endyear");


            modelBuilder.Entity<Bookmarks>().ToTable("name_bookmarks");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkPerson).HasColumnName("");


            modelBuilder.Entity<Bookmarks>().ToTable("title_bookmarks");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkMovie).HasColumnName("");


            modelBuilder.Entity<Rating>().ToTable("name_ratings");
            modelBuilder.Entity<Rating>().Property(x => x.ratingn).HasColumnName("");


            modelBuilder.Entity<Rating>().ToTable("title_ratings");
            modelBuilder.Entity<Rating>().Property(x => x.ratingt).HasColumnName("");


            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchWord).HasColumnName("");
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchOrder).HasColumnName("");
        }

    }
   
}
