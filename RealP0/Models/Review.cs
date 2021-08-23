using System;
using System.Collections.Generic;

namespace Models
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public int RestaurantId { get; set; }

        public Review()
        {
            
        }
       // public Review(string user)
       // {
          //  this.Users=user;
       // }
        public Review(int userid, string comments,int rating,int restauraintid )
        {
            this.UserId = userid;
            this.RestaurantId=restauraintid;
            this.Comments = comments;
            this.Rating=rating;
        }
        //public Review(string user,string comments,decimal rating)
       // {
       //     Users=user;
        //    Comments = comments;
       //     Rating=rating;
       // }
        /*
         public Review(string user,string comments,decimal rating,int restauraintid)
        {
            User=user;
            Comments = comments;
            Rating=rating;
            RestaurantId=restauraintid;
        }
        */

    }
}