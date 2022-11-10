using DataLayer.Domain;
using Portfolio_2.Domain;
using Portfolio_2.Models;


namespace Portfolio_2
{
    public interface IDataService
    {
        IList<User> GetUsers();
        User? GetUser(string username);
        IList<Person> GetPersons(int page, int pageSize);
        Person? GetPersons(string nameID);
        IList<Movie> GetMovies(int page, int pageSize);
        Movie? GetMovies(string movieID);
        IList<Bookmarks> GetBookmarks();
        Bookmarks? GetBookmarks(string bookmarkPersonBID, string bookmarkMovieBID);
        IList<Rating> GetRatings();
        Rating GetRatings(string ratingnconst, string ratingtonst);
        IList<RatingHistory> GetRatingHistories(int page, int pageSize);
        RatingHistory GetRatingHistory(string ratingHisMovTID, string ratingHisPersonNID);
        IList<SearchHistory> GetSearchHistories(int page, int pageSize);
        SearchHistory GetSearchHistories(int searchOrder);
        int GetNumberOfMovies();
        int GetNumberOfPerons();
        int GetNumberOfSearchHistories();
        void CreateUser(User user);
        bool UpdateUser(User user);
        bool DeleteUser(string username);
        void CreatePerson(Person person);
        bool UpdatePerson(Person person);
        bool DeletePerson(string personID);
        void CreateMovie(Movie movie);
        bool UpdateMovie(Movie movie);
        bool DeleteMovie(string movieID);
        void CreateBookmarksPerson(Bookmarks bookmarksP);
        bool UpdateBookmarksPerson(Bookmarks bookmarksP);
        bool DeleteBookmarksPerson(string bookmarkPersonBID);
        void CreateBookmarksMovie(Bookmarks bookmarksM);
        bool UpdateBookmarksMovie(Bookmarks bookmarksM);
        bool DeleteBookmarksMovie(string bookmarkMovieBID);
        void CreateRatingPerson(Rating ratingP);
        bool UpdateRatingPerson(Rating ratingP);
        bool DeleteRatingPerson(string ratingnconst);
        void CreateRatingMovie(Rating ratingM);
        bool UpdateRatingMovie(Rating ratingM);
        bool DeleteRatingMovie(string ratingtonst);
        void CreateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool UpdateRatingHistoryPerson(RatingHistory ratingHistoryP);
        bool DeleteRatingHistoryPerson(string ratingHisPersonNID);
        void CreateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool UpdateRatingHistoryMovie(RatingHistory ratingHistoryM);
        bool DeleteRatingHistoryMovie(string ratingHisMovTID);
        void CreateSearchHistory(SearchHistory searchHistory);
        bool UpdateSearchHistory(SearchHistory searchHistoryM);
        bool DeleteSearchHistory(int searchOrder);

        IList<PersonSearchModel> GetPersonSearches(string searchPerson);
        IList<MovieSearchModel> GetMovieSearches(string searchMovie);




        

        

    }
}
