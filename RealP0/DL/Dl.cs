using System;
using System.Collections.Generic;
using Models;
using DL.Entities;
using System.IO;
using System.Linq;

namespace DL
{
    public class Dl : IDl
    {
        private retdbContext _context;
        public Dl (retdbContext context)
        {
            _context = context;
            
                
        }

        public  List<Models.Restaurant> ViewAllRestaurants()
        {
            return _context.Restaurants.Select(
                x => new Models.Restaurant(x.Id,  x.Name ,x.Address, x.City,x.State, x.ZipCode , x.Cuisine, x.Rating )
               
            ).ToList();
        }
        public  List<Models.Customer> ViewAllUsers()
        {
            return _context.Customers.Select(
                x => new Models.Customer(x.Id,  x.Name ,x.LastName, x.Phone,x.Email)
               
            ).ToList();
        }
        public Models.Restaurant SearchRestaurant(string x)
        {
                
                Entities.Restaurant found = _context.Restaurants
                .FirstOrDefault(y => y.Name == x );
  
                if( found != null)
                {             
                    return new Models.Restaurant( found.Id, found.Name, found.Address, found.City, found.State, found.ZipCode, found.Cuisine, found.Rating) ; // you can also return the ID so it can be used later on
                }
                else
                {
                    return new Models.Restaurant();
                }
                    
                 

        }

         public Models.Restaurant SearchCuisine(string x)
        {
                
                Entities.Restaurant found = _context.Restaurants
                .FirstOrDefault(y => y.Cuisine == x );
  
                if( found != null)
                {             
                    return new Models.Restaurant( found.Id, found.Name, found.Address, found.City, found.State, found.ZipCode, found.Cuisine, found.Rating) ; // you can also return the ID so it can be used later on
                }
                else
                {
                    return new Models.Restaurant();
                }
                    
                 

        }

        public Models.Customer AddUser(Models.Customer x)
        {
            
            _context.Customers.Add(
                new Entities.Customer
                {
                    
                    Name = x.Name,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email 

                }

            );
            _context.SaveChanges();
            return x;



        }

        public Models.Review AddAReview(Models.Review review)
        {
            _context.Reviews.Add(
                 new Entities.Review
                {
                       
                        UserId= review.UserId,
                        Comments= review.Comments,
                        Rating = review.Rating,
                        RestaurantId = review.RestaurantId

                }
            );
                _context.SaveChanges();
                return review;

        }

        
        public Models.Restaurant AddRestaurant(Models.Restaurant a)
        {
             _context.Restaurants.Add(
                new Entities.Restaurant
                {
                   Id = a.Id,
                    Name = a.Name,
                    Address = a.Address,
                    City = a.City,
                    State = a.State,
                    ZipCode = a.ZipCode,
                    Cuisine = a.Cuisine,
                    Rating = a.Rating
    

                }
             );
                _context.SaveChanges();
                return a;
        }
        public  List<Models.Review> ViewAllReviews()
        {
            return _context.Reviews.Select(

                x => new Models.Review( x.UserId, x.Comments, x.Rating, x.RestaurantId)
               
            ).ToList();
        }
                        
            

    }
}