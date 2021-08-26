using System;
using System.Collections.Generic;
using Models;
using DL;

namespace BL
{
    public enum PhoneValidation

    {
        Valid,Invalid
    }
    public enum RatingOptions
    {
        Bad,Normal,High
    }
    
        public class Testing
    {
        public  static double PhoneDigits(double Phone)
        {
            if( Phone > 0  )
            {
                Console.WriteLine("Your phone number is going to get validated");

                var x = Phone ; 
                Console.WriteLine("Your phone number: -"+x+ "- can be subjected for testing");

                return x;
            }
            else
            {
                throw new ArgumentException("Phone must contain have 9 digits");
            }
        }


        public static  PhoneValidation Digits(double PhoneDigits)
        {
            PhoneValidation validity = PhoneValidation.Invalid;

            if ( PhoneDigits > 99999999)
            {
                    validity = PhoneValidation.Valid;
            }
            else
            {
                validity = PhoneValidation.Invalid;
            }

            return validity;

        }
        public  static double GetAverage(double rating1,double rating2)
        {
            if( rating1 > 0 && rating2 >0  )
            {
                Console.WriteLine("Your ratings have been updated");

                var x = (rating1 + rating2) /2;

                Console.WriteLine("Your average of ratings is: "+ x);

                return x;
            }
            else
            {
                throw new ArgumentException("Ratings must be greater than 0");
            }
        }
        public static  RatingOptions TotalAverage(double Avrg)
        {
            RatingOptions rating = RatingOptions.Bad;

            if ( Avrg <= 2)
            {
                    rating = RatingOptions.Bad;
            }
            else if ( Avrg >2 && Avrg <=4 )
            {
                rating = RatingOptions.Normal;
            }
            else if ( Avrg >4)
            {
                rating = RatingOptions.High;
            }
            return rating;

        }
    }
}