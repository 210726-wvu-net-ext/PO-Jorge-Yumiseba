using System;
using Models;
using BL;
using Serilog;

using System.Collections.Generic;

namespace UI
{
    public class Menu : IMenu       //hello
    {
            
            private Bl _resbl;

            public Menu(Bl resbl)
            {
                _resbl=resbl;
                Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .WriteTo.Console()
                                .WriteTo.File("../logs/Administratorlogs.txt")
                                .CreateLogger();

                Log.Information("We have been initialized");

            }

            
         public void Start()
            {     
           

            bool repeat = true;
            do
            {
                Console.WriteLine("________________________________");
                Console.WriteLine("||Hola. Welcome to the jungle!||");
                Console.WriteLine("[1] List of all the restaurants");
                Console.WriteLine("[2] Search for a restaurant");
                Console.WriteLine("[3] Add a review");            
                Console.WriteLine("[0] Exit");

                switch(Console.ReadLine())
                {
                    case "0":
                        Console.WriteLine("ADIOS!"); 
                        repeat = false;
                    break;

                    case "1":
                    
                      ViewAllRestaurants();
                     
                    break;

                    case "2":
                       Console.WriteLine("Enter the restaurant you want to find: ");
                       SearchRestaurant();
                        Console.WriteLine("Do you want to continue? ");
                        string x = Console.ReadLine();
                        if ( x == "no" || x == "No")
                        {
                            goto case "0";
                        }
                       
                    break;

                    case "3":
                         AddAReview();
                    
                     
                    break;
                    case "4":
                        
                        
                    break;

                    case "99":
                        Console.WriteLine("You have entered the secret Administrator path...Enter password:");
                        string z = Console.ReadLine();
                        if ( z == "*****")
                        {
                            Log.Debug("A new log in has been recorded");
                            

                            Console.WriteLine("You have activated special functionalities");
                            Console.WriteLine();
                            Console.WriteLine("[1] Add a restaurant");
                             Console.WriteLine("[2] Average Rating of each restaurant");
                             Console.WriteLine("[3] View all the reviews");
                             Console.WriteLine("[4] View all the users");
                             int c = Convert.ToInt32(Console.ReadLine());
                             if(c == 1) 
                             {
                                 Console.WriteLine("You are about to add a restaurant");
                                 AddRestaurat();
                                 Console.WriteLine("You are exiting administrator mode now");
                             }
                             else if ( c == 2)
                             {
                                 Console.WriteLine("This is a calculated average of the restaurant selected");
                                GetTotalAverage();
                                Console.WriteLine("You are exiting administrator mode now");

                             }
                             else if ( c == 3)
                             {
                                 Console.WriteLine("These are all the reviews that we have collected!");
                                ViewAllReviews();
                                Console.WriteLine("You are exiting administrator mode now");

                             }
                              else if ( c == 4)
                             {
                                 Console.WriteLine("These are all the users that have signed in so far");
                                ViewAllUsers();
                                Console.WriteLine("You are exiting administrator mode now");

                             }
                             else
                             {
                                 Console.WriteLine("You are exiting administrator mode now.");
                                
                             }
                        
                        }
                        else
                        {
                            Console.WriteLine("You are not that guy pal.");
                        }

                        break;

                    default:
                        Console.WriteLine("We don't understand what you're doing");
                    break;
                }
            } while(repeat);
        }

        
            private void ViewAllRestaurants()
            {       
            Console.WriteLine("These are all the available restaurants");
                List<Restaurant> restaurants = _resbl.ViewAllRestaurants(); // same as here
                
                foreach(Restaurant res in restaurants)
                {
                    Console.WriteLine("Name: " + res.Name + "  |  Address: " + res.Address + "  |  City: "+res.City+"  |  State: "+res.State+"  |  Cuisine: "+res.Cuisine+"  |  Zipcode: "+res.ZipCode+"   |  Rating: "+res.Rating);
                           
                }
            
            }

            private void ViewAllReviews()
        {
            Console.WriteLine("These are all the reviews we have in the database");
                List<Review> reviews = _resbl.ViewAllReviews(); // same as here

                
                
                foreach(Review rev in reviews)
                {
                    Console.WriteLine(rev.UserId + "--   Review: " + rev.Comments);              
                    
                }

        }

          private void ViewAllUsers()
        {
            Console.WriteLine("Select the Restaurant you would like information of or press [0] to go back to the main menu");
                List<Customer> customers = _resbl.ViewAllUsers(); // same as here

                
                
                foreach(Customer cus in customers)
                {
                    Console.WriteLine("Name: "+ cus.Name + "--   Last Name: " + cus.LastName);              
                    
                }

        }
        

            private void SearchRestaurant()
             {    
                 string enter; 
                
                
                enter= Console.ReadLine();      
               Restaurant restaurant= _resbl.SearchRestaurant(enter);
               


               if (restaurant.Name is null)
               {
                  
                   Console.WriteLine("we did not find your restaurant " + enter); // since that name is not found on the data base
                   //Console.WriteLine("You can try with the type of Cuisine or zipcode");
                    // x = Console.ReadLine();
                    SearchCuisine();
                                 
               }                                                                            // it will return nothing so blank
               else                                                                        // that is why you gotota used enter only in this case
               {
                   Console.WriteLine("You have selected: " + restaurant.Name);
                   Console.WriteLine("Here is more information about your restaurant.");
                   Console.WriteLine("Name: " + restaurant.Name +" Address: " + restaurant.Address + " City: " + restaurant.City + " Cuisine: " + restaurant.Cuisine );
               
                }
                }

            private void SearchCuisine()
            {
                Console.WriteLine("You can also search a restaurant by its cuisine. Type the type of food you would want");
                string x = Console.ReadLine();
                Restaurant res = _resbl.SearchCuisine(x);

                if(res.Cuisine is null)
                {
                    Console.WriteLine("We do not have that restaurant. Apologies");
                }
                else
                {
                    Console.WriteLine("We found a restaurant that matched with your search!");
                    Console.WriteLine("Here is more information about it");
                    Console.WriteLine("Name: " + res.Name +" Address: " + res.Address + " City: " + res.City + " Cuisine: " + res.Cuisine);
                }

            }


             private void AddAReview()
             {
                Console.WriteLine("In order to do this you will need to provide additional information. Press 1 if you want to continue");
                var w=  Console.ReadLine();
                if ( w != "1" )
                {
                      Console.WriteLine("You are going back to the main menu");  
                }
                else
                {
                    
                     Console.WriteLine("Enter your name: ");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string b = Console.ReadLine();
            int delta;

            
        
                Console.WriteLine("Enter your phone number");
                 double c = Convert.ToDouble ( Console.ReadLine());  
             



            Console.WriteLine("Enter your email");
            string d = Console.ReadLine();

            Customer customer = new Customer( a,b,c,d);
            customer = _resbl.AddUser(customer);

            Log.Debug("New User has been registered");

            List<Customer> customers = _resbl.ViewAllUsers();

            
            for ( int i =1; i<customers.Count ; i++)
            {
                if( i == customers.Count - 1)
                {
                    Console.WriteLine("New User has been added to the Data Base!");               
                    Console.WriteLine("Please select a Restaurant: ");

                    List<Restaurant> x = _resbl.ViewAllRestaurants();
                    Restaurant selected = SelectRestaurant(x);

                    Console.WriteLine(selected.Id);
                     string comments;                 
                    int rate; 
           
            if (selected is not null)
            {
                Console.WriteLine("You have selected a restaurant. Name: " + selected.Name);
             
                
                do{
                    Console.WriteLine("Enter a review: ");
                comments = Console.ReadLine();

                }while(string.IsNullOrWhiteSpace (comments));
                
                efe:
               try
               {
                   Console.WriteLine("Rate this restaurant out of 5 stars: ");
                rate= Convert.ToInt32(Console.ReadLine());      //  DO TRY CATCH HERE (MEST UP THE INT-DECIMAL)
               }
               catch(Exception e)
               {
                Console.WriteLine("There was an error " );
                Console.WriteLine("Only Integers Available at the moment");
                goto efe;
               }
       
                Review newreview = new Review(customers[i].Id ,comments, rate, selected.Id);
        
                try 
                {                    
                    newreview = _resbl.AddAReview(newreview);
                    Console.WriteLine("You review has been submitted. \nThank you.");
                    
                    
                    //Console.WriteLine(newreview.Comments);                      // only to test that you CAN actually use it
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

                }
             }
            }
        }
            

            
    }
            private Restaurant SelectRestaurant(List<Restaurant> restaurants)
                     {
            
            int selection;

            bool valid = false;       

            do{
                for( int i=0; i<restaurants.Count; i++)
                {
                    Console.WriteLine($"[{i}] {restaurants[i].Name} , City: {restaurants[i].City}");
                    
                }
                 //foreach(Restaurant res in restaurants)                             //either one works
              //  {                                                                   //use if for now
                    //Console.WriteLine(res.Id + " <= "+  res.Name + " efeefefe "+ res.City);
                    
              //  }
            
                valid = int.TryParse(Console.ReadLine(), out selection);
                // parsing to int has been successful and withing range
                if(valid && (selection >= 0 && selection < restaurants.Count))
                {
                    
                        return restaurants[selection];
                }
                Console.WriteLine("Enter something valid");
            }while(true);

        }    

         private void AddUser()
            {
            Console.WriteLine("Enter your name: ");
            string a = Console.ReadLine();
            Console.WriteLine("Enter your last name");
            string b = Console.ReadLine();
            Console.WriteLine("Enter your phone number");
            double c = Convert.ToDouble ( Console.ReadLine());      //try catch if you input a string DO!!
            Console.WriteLine("Enter your email");
            string d = Console.ReadLine();

            Customer customer = new Customer( a,b,c,d);
            customer = _resbl.AddUser(customer);
            Console.WriteLine("New User has been added to the Data Base!");
      

            }

        private void AddRestaurat()
             {
            

            Console.WriteLine("Enter the name of the restaurant you want to add");
            string a = Console.ReadLine();
            Console.WriteLine("Enter its address");
            string b = Console.ReadLine();
            Console.WriteLine("Enter the City");
            string c = Console.ReadLine();
            Console.WriteLine("Enter the State");
            string d = Console.ReadLine();

        
                
                Console.WriteLine("Enter the ZipCode");         // only numbers
            int e = Convert.ToInt32( Console.ReadLine());
                
           
            Console.WriteLine("Enter the Cuisine");
            string f = Console.ReadLine();                 

         
                Console.WriteLine("Enter the Rating");           // all good here

            decimal g = Convert.ToDecimal( Console.ReadLine());
           
         
            
            Restaurant restaurant = new Restaurant( a,b,c,d,e,f,g);
            
            restaurant = _resbl.AddRestaurant(restaurant);
            Console.WriteLine("Restaurant has been added to the Data Base!");
            
        }



        private void GetTotalAverage()
        {
           
            List<Review> reviews = _resbl.ViewAllReviews();

            double operandy = GetRatingReview(reviews);
           
            Console.WriteLine(operandy);

       }

         private double GetRatingReview(List<Review> rating)
        {
            double a =0;
            double b=0;
            double div=0;
            double average=0;;
            List<Restaurant> t = _resbl.ViewAllRestaurants();
            Restaurant operandx = GetRatingRestaurant(t);


            
            for( int i = 0; i<rating.Count; i++)
            {
               

                if(operandx.Id == rating[i].RestaurantId)
                {
                    div++;
                   a = a + Convert.ToDouble( rating[i].Rating);
                                                  
                }
                
                b= Convert.ToDouble(operandx.Rating);               
            }
            a= a/div;
            average = average + ((a+b)/2);
            Console.WriteLine("The average of " + operandx.Name + " is: ");
            return average;

        }


        private Restaurant GetRatingRestaurant(List<Restaurant> restaurantss)
        {
            int selec;

            bool valid = false;
            
            
           Console.WriteLine("Which restaurant you want to get the ratings from?");

            do{
                for( int i=0; i<restaurantss.Count; i++)
                {
                    Console.WriteLine($"[{i}] {restaurantss[i].Name}");
                    
                }             
            
                valid = int.TryParse(Console.ReadLine(), out selec);                
               if(valid && (selec >= 0 && selec < restaurantss.Count))
                {
                    
                        return restaurantss[selec];
                }
                Console.WriteLine("Enter something valid");
            }while(true);

        }


    }
}