using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class RatingTitleSqlProfile : Profile
    {
        public RatingTitleSqlProfile()
        {
            CreateMap<RatingTitleSql, RatingTitleSqlCreateModel>();
            CreateMap<RatingTitleSqlCreateModel, RatingTitleSql>();    
        }
    }
}
