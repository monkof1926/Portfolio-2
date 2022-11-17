namespace DataLayer.Models
{
    public class SearchHistorySearchModel
    {
        public string? searchSearch { get; set; }
        public string? searchWord { get; set; }
        public int? searchOrder { get; set; }
        //Add public string? searchUserID { get; set; } Add when searchuserID is add to searchHistory on database
    }
}
