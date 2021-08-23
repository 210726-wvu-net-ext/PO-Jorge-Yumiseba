using System;
using System.Collections.Generic;
using Models;

namespace BL
{
    public interface IBl
    {
         List<Restaurant> ViewAllRestaurants(); 
         Restaurant SearchRestaurant(string x);
         Customer AddUser(Customer x);
         Restaurant AddRestaurant(Restaurant a);
         Review AddAReview(Review review);

         List<Review> ViewAllReviews();

         Restaurant SearchCuisine(string x);

         List<Customer> ViewAllUsers(); 
    }
}