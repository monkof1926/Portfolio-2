using DataLayer.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer
{
    public class NorthwindContext : DbContext   
    {
        public DbSet<User> users { get; set; }
        public DbSet<Person> name_basics { get; set; }
        public DbSet<Movie> title_basics { get; set; }
        public DbSet<BookmarksPerson> name_bookmarks { get; set; }
        public DbSet<BookmarksMovie> title_bookmarks { get; set; }
        public DbSet<RatingPerson> name_ratings { get; set; }
        public DbSet<RatingMovie> title_ratings { get; set; }
        public DbSet<RatingHistoryPerson> name_ratings_hist { get; set; }
        public DbSet<RatingHistoryMovie> title_ratings_hist { get; set; }
        public DbSet<SearchHistory> searchhistory { get; set; }
        public DbSet<SearchResult> best_match_search { get; set; }
        public DbSet<SearchResult> exact_match_search { get; set; }
        public DbSet<SearchResult> name_search { get; set; }
        public DbSet<SearchResult> simplesearcher { get; set; }
        public DbSet<SearchResult> structured_string_search { get; set; }
        public DbSet<NameRating> rate_name { get; set; }
        public DbSet<TitleRating> rate_title { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql("host=cit.ruc.dk;db=cit08;uid=cit08;pwd=yrRrh0f2VBVd");
            //optionsBuilder
            //    .UseNpgsql("host=local;db=imdb;uid=emma;pwd=ILik3Cats!");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().HasKey(x => x.username);
            modelBuilder.Entity<User>().Property(x => x.username).HasColumnName("userid");
            modelBuilder.Entity<User>().Property(x => x.password).HasColumnName("password");


            modelBuilder.Entity<Person>().ToTable("name_basics");
            modelBuilder.Entity<Person>().HasKey(x => x.nameID);
            modelBuilder.Entity<Person>().Property(x => x.nameID).HasColumnName("nconst");
            modelBuilder.Entity<Person>().Property(x => x.fullName).HasColumnName("primaryname");
            modelBuilder.Entity<Person>().Property(x => x.birthYear).HasColumnName("birthyear");
            modelBuilder.Entity<Person>().Property(x => x.deathYear).HasColumnName("deathyear");

            modelBuilder.Entity<Person>().ToTable("charaters_played");
            //modelBuilder.Entity<Person>().HasNoKey();
            modelBuilder.Entity<Person>().Property(x => x.featuredInMovie).HasColumnName("tconst");
            modelBuilder.Entity<Person>().Property(x => x.featuredInRole).HasColumnName("characters");
            modelBuilder.Entity<Person>().Property(x => x.featuredInProffesion).HasColumnName("category");



            modelBuilder.Entity<Movie>().ToTable("title_basics");
            modelBuilder.Entity<Movie>().HasKey(x => x.movieID);
            modelBuilder.Entity<Movie>().Property(x => x.movieID).HasColumnName("tconst");
            modelBuilder.Entity<Movie>().Property(x => x.title).HasColumnName("primarytitle");
            modelBuilder.Entity<Movie>().Property(x => x.startYear).HasColumnName("startyear");
            modelBuilder.Entity<Movie>().Property(x => x.endYear).HasColumnName("endyear");


            modelBuilder.Entity<BookmarksPerson>().ToTable("name_bookmarks");
            modelBuilder.Entity<BookmarksPerson>().HasKey(x => x.bookmarkPersonBID);
            //modelBuilder.Entity<BookmarksPerson>().HasNoKey();
            modelBuilder.Entity<BookmarksPerson>().Property(x => x.bookmarkPersonBID).HasColumnName("nbookid");
            modelBuilder.Entity<BookmarksPerson>().Property(x => x.bookmarkPersonNconst).HasColumnName("nconst");
            modelBuilder.Entity<BookmarksPerson>().Property(x => x.bookmarkPersonName).HasColumnName("primaryname");


            modelBuilder.Entity<BookmarksMovie>().ToTable("title_bookmarks");
            modelBuilder.Entity<BookmarksMovie>().HasKey(x => x.bookmarkMovieBID);
            //modelBuilder.Entity<Bookmarks>().HasKey(x => new { x.bookmarkMovieBID, x.UserID }); --Eksempel på combosite key
            modelBuilder.Entity<BookmarksMovie>().Property(x => x.bookmarkMovieBID).HasColumnName("tbookid");
            modelBuilder.Entity<BookmarksMovie>().Property(x => x.bookmarkMovieTconst).HasColumnName("tconst");
            modelBuilder.Entity<BookmarksMovie>().Property(x => x.bookmarkMoviePrimarytitle).HasColumnName("primarytitle");
            //modelBuilder.Entity<BookmarksMovie>().Property(x => x.bookmarkUserID).HasColumnName("userid");




            modelBuilder.Entity<RatingPerson>().ToTable("name_ratings");
            modelBuilder.Entity<RatingPerson>().HasKey(x => x.ratingnconst);
            modelBuilder.Entity<RatingPerson>().Property(x => x.ratingnconst).HasColumnName("nconst");
            modelBuilder.Entity<RatingPerson>().Property(x => x.ratingAvergePerson).HasColumnName("averagerating");
            modelBuilder.Entity<RatingPerson>().Property(x => x.ratingNumPerson).HasColumnName("numvotes");
            //modelBuilder.Entity<RatingPerson>().Property(x => x.ratingUserID).HasColumnName("userid"); when add userid to rating 



            modelBuilder.Entity<RatingHistoryPerson>().ToTable("name_rating_hist");
            modelBuilder.Entity<RatingHistoryPerson>().HasKey(x => x.ratingHisPersonNID);
            modelBuilder.Entity<RatingHistoryPerson>().Property(x => x.ratingHisPersonNID).HasColumnName("nrateid");
            modelBuilder.Entity<RatingHistoryPerson>().Property(x => x.ratingHisPersonNconst).HasColumnName("nconst");
            modelBuilder.Entity<RatingHistoryPerson>().Property(x => x.ratingHisPersonRating).HasColumnName("rating");
            //modelBuilder.Entity<RatingHistoryPerson>().Property(x => x.ratingHisUserID).HasColumnName("userid");



            modelBuilder.Entity<RatingMovie>().ToTable("title_ratings");
            modelBuilder.Entity<RatingMovie>().HasKey(x => x.ratingtonst);
            modelBuilder.Entity<RatingMovie>().Property(x => x.ratingtonst).HasColumnName("tconst");
            modelBuilder.Entity<RatingMovie>().Property(x => x.ratingAvergeTitle).HasColumnName("averagerating");
            modelBuilder.Entity<RatingMovie>().Property(x => x.ratingNumTitle).HasColumnName("numvotes");
            //modelBuilder.Entity<RatingMovie>().Property(x => x.ratingHisUserID).HasColumnName("userid");





            modelBuilder.Entity<RatingHistoryMovie>().ToTable("title_rating_hist");
            modelBuilder.Entity<RatingHistoryMovie>().HasKey(x => x.ratingHisMovTID);
            modelBuilder.Entity<RatingHistoryMovie>().Property(x => x.ratingHisMovTID).HasColumnName("trateid");
            modelBuilder.Entity<RatingHistoryMovie>().Property(x => x.ratingHisMovTconst).HasColumnName("tconst");
            modelBuilder.Entity<RatingHistoryMovie>().Property(x => x.ratingHisMovRating).HasColumnName("rating");
            



            modelBuilder.Entity<SearchHistory>().ToTable("searchhistory");
            modelBuilder.Entity<SearchHistory>().HasKey(x => x.searchOrder);
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchWord).HasColumnName("searchword");
            modelBuilder.Entity<SearchHistory>().Property(x => x.searchOrder).HasColumnName("searchid");
            //Add userID here, when added to the database.

            //Functions:
            modelBuilder.Entity<SearchResult>().HasNoKey();
            modelBuilder.Entity<SearchResult>().Property(x => x.tconst).HasColumnName("t_const");
            modelBuilder.Entity<SearchResult>().Property(x => x.rank).HasColumnName("rank1");
            modelBuilder.Entity<SearchResult>().Property(x => x.title).HasColumnName("title");
            modelBuilder.Entity<SearchResult>().Property(x => x.nconst).HasColumnName("n_const");
            modelBuilder.Entity<SearchResult>().Property(x => x.pname).HasColumnName("pname");

            modelBuilder.Entity<NameRating>().HasNoKey();
            modelBuilder.Entity<NameRating>().Property(x => x.nconst).HasColumnName("rnconst");
            modelBuilder.Entity<NameRating>().Property(x => x.rating).HasColumnName("rating");
            modelBuilder.Entity<NameRating>().Property(x => x.userID).HasColumnName("ruserid");

            modelBuilder.Entity<TitleRating>().HasNoKey();
            modelBuilder.Entity<TitleRating>().Property(x => x.tconst).HasColumnName("rtconst");
            modelBuilder.Entity<TitleRating>().Property(x => x.rating).HasColumnName("rating");
            modelBuilder.Entity<TitleRating>().Property(x => x.userID).HasColumnName("ruserid");

        }


    }
   
}
