﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Domain;
using DataLayer.IDataService;
using DataLayer;

namespace DataLayer.DataService
{
    public class RatingDataService : IRatingDataService
    {
        public void CreateRatingPerson(Rating rating)
        {
            using var db = new NorthwindContext();
            db.name_ratings.Add(rating);
            db.SaveChanges();
        }
        public bool DeleteRatingPerson(string ratingnconst)
        {
            using var db = new NorthwindContext();
            var ratingP = db.name_ratings.Find(ratingnconst);
            if (ratingP != null)
            {
                db.name_ratings.Remove(ratingP);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public IList<Rating> GetRatingsPers()
        {
            using var db = new NorthwindContext();
            return db.name_ratings.ToList();
        }

        public IList<Rating> GetRatingsMov()
        {
            using var db = new NorthwindContext();
            return db.title_ratings.ToList();
        }
        public Rating? GetRatingsPers(string ratingAvergePerson)
        {
            using var db = new NorthwindContext();
            return db.name_ratings.Find(ratingAvergePerson);
            
        }
        public Rating? GetRatingsMov(string ratingAvergeTitle)
        {
            using var db = new NorthwindContext();
                return db.name_ratings.Find(ratingAvergeTitle);
        }
        public bool UpdateRatingPerson(Rating rating) 
        {
            using var db = new NorthwindContext();
            var dbRatingPerson = db.name_ratings.Find(rating.ratingnconst);
            if (dbRatingPerson == null) return false;
            dbRatingPerson.ratingAvergePerson = rating.ratingAvergePerson;
            dbRatingPerson.ratingNumPerson = rating.ratingNumPerson;
            db.SaveChanges();
            return true;
        }
        public void CreateRatingMovie(Rating rating)
        {
            using var db = new NorthwindContext();
            db.title_ratings.Add(rating);
            db.SaveChanges();
        }
        public bool DeleteRatingMovie(string ratingtonst)
        {
            using var db = new NorthwindContext();
            var ratingM = db.title_ratings.Find(ratingtonst);
            if (ratingM != null)
            {
                db.title_ratings.Remove(ratingM);
            }
            else { return false; }

            return db.SaveChanges() > 0;
        }
        public bool UpdateRatingMovie(Rating rating)
        {
            using var db = new NorthwindContext();
            var dbRatingMovie = db.title_ratings.Find(rating.ratingtonst);
            if (dbRatingMovie == null) return false;
            dbRatingMovie.ratingtonst = rating.ratingtonst;
            dbRatingMovie.ratingAvergePerson = rating.ratingAvergePerson;
            db.SaveChanges();
            return true;
        }
        public User CreateUser(string username, string password, string salt)
        {
            var user = new User
            {
                username = username,
                password = password,
                salt = salt
            };
        }
    }
}
