using System.Collections.Generic;
using Models;

namespace DL
{
    public interface IDl
    {
         List<Models.Restaurant> ViewAllRestaurants();
         Restaurant SearchRestaurant(string x);
         Customer AddUser(Customer x);
         
         Restaurant AddRestaurant (Restaurant a);
         List<Models.Review> ViewAllReviews();
         Restaurant SearchCuisine(string x);
        Review AddAReview(Review review);
          List<Models.Customer> ViewAllUsers(); 
    }
    
}