using Models;
using System;
using System.Collections.Generic;
using DL;

namespace BL
{
    public class Bl : IBl
    {
        private IDl _repo;
        public Bl(IDl repo)
        {
            _repo=repo;

           

        }

        public  List<Restaurant> ViewAllRestaurants()
        {
            return _repo.ViewAllRestaurants();
        }
         public Restaurant SearchRestaurant(string x)
       {
           return _repo.SearchRestaurant( x);
       }
        public Restaurant SearchCuisine(string x)
       {
           return _repo.SearchCuisine( x);
       }

        public  Customer AddUser(Customer x)
       {
           
           return _repo.AddUser(x);
       }
        public Restaurant AddRestaurant(Restaurant a )
       {
           return _repo.AddRestaurant(a);
       }
       public List<Review> ViewAllReviews()
        {
            return _repo.ViewAllReviews();
        }

       public  List<Customer> ViewAllUsers() 
       {
           return _repo.ViewAllUsers();
       }
         public Review AddAReview(Review review)
       {
            return _repo.AddAReview(review);
       }
        
    }
}