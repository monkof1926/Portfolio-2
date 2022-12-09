using AutoMapper;
using DataLayer.Domain;
using DataLayer.SqlFunctions;

namespace WebServer.Models.Profiles
{
    public class RatingNameSqlProfile : Profile
    {
        public RatingNameSqlProfile()
        {
            CreateMap<RatingNameSql, RatingNameSqlCreateModel>();
            CreateMap<RatingNameSqlCreateModel, RatingNameSql>();
        }
    }
}
