using DataLayer.Domain;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkPersonBID).HasColumnName("nbookid");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkPersonNconst).HasColumnName("nconst");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkPersonName).HasColumnName("primaryname");


            modelBuilder.Entity<Bookmarks>().ToTable("title_bookmarks");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkMovieBID).HasColumnName("tbookid");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkMovieTconst).HasColumnName("tconst");
            modelBuilder.Entity<Bookmarks>().Property(x => x.bookmarkMoviePrimarytitle).HasColumnName("primarytitle");


            modelBuilder.Entity<Rating>().ToTable("name_ratings");
            modelBuilder.Entity<Rating>().Property(x => x.ratingnconst).HasColumnName("nconst");
            modelBuilder.Entity<Rating>().Property(x => x.ratingAvergePerson).HasColumnName("averagerating");
            modelBuilder.Entity<Rating>().Property(x => x.ratingNumPerson).HasColumnName("numvotes");


            modelBuilder.Entity<RatingHistory>().ToTable("name_rating_hist");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisPersonNID).HasColumnName("nrateid");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisPersonNconst).HasColumnName("nconst");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisPersonRating).HasColumnName("rating");


            modelBuilder.Entity<Rating>().ToTable("title_ratings");
            modelBuilder.Entity<Rating>().Property(x => x.ratingtonst).HasColumnName("tconst");
            modelBuilder.Entity<Rating>().Property(x => x.ratingAvergeTitle).HasColumnName("averagerating");
            modelBuilder.Entity<Rating>().Property(x => x.ratingNumTitle).HasColumnName("numvotes");


            modelBuilder.Entity<RatingHistory>().ToTable("title_rating_hist");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisMovTID).HasColumnName("trateid");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisMovTconst).HasColumnName("tconst");
            modelBuilder.Entity<RatingHistory>().Property(x => x.ratingHisMovRating).HasColumnName("rating");


            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchWord).HasColumnName("searchword");
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchOrder).HasColumnName("searchid");
        }

    }
   
}
