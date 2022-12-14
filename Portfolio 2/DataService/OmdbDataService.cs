﻿using DataLayer.Domain;
using DataLayer.Models;
using DataLayer.IDataService;
using Microsoft.EntityFrameworkCore;
using DataLayer.SqlFunctions;
using DataLayer;

namespace Portfolio_2.DataService
{
    public class OmdbDataService : IOmdbDataService
    {
       public Omdb GetOmdb(string omdbID)
        {   
            using var db = new NorthwindContext();
            if (omdbID != null)
            {
                return db.Omdb_data.Find(omdbID);
            }
           
            else return null;
               
        }
    }
}