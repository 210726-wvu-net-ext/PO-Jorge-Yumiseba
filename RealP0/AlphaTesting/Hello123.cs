using System;
using Xunit;
using BL ;

namespace AlphaTesting
{
    public class Hello123
    {
        [Fact]
        public void PhoneTest()       
         {
            //Arrange
            double expectedPhone = 3477054868;
            double currentPhone = 3477054868;
         //Act
            var actualPhone = Testing.PhoneDigits(currentPhone);
            //Assert
           Assert.Equal(expectedPhone,actualPhone);
        }


        [Fact]
        public void PhoneThrow()
        {
        //Given       
        double currentPhone = -3477054863;       
        //When
        //Then

            Assert.Throws<ArgumentException>(()=> Testing.PhoneDigits(currentPhone));
        }

        [Fact]
        public void PhoneDigits()
        {
            var expectedDigits = PhoneValidation.Valid;
            var actualPhone = Testing.Digits(3477045849);
            Assert.Equal(expectedDigits,actualPhone);


        }
        [Fact]          
        public void RatingTest()                //Doesnt pass simply because expectedrating != actualrating
        {
        //Given
            double expectedRating = 4.5;
            double rating1= 4.3 ;
            double rating2 = 2.9; 
        //When
        var actualRating = Testing.GetAverage(rating1,rating2);
        
        //Then
        Assert.Equal(expectedRating,actualRating);
        }

        [Fact]
        public void RatingThrow()     
        {                               
            double rating1 = -4.5;
            double rating2 = -4.3;

            

            Assert.Throws<ArgumentException>(() => Testing.GetAverage(rating1,rating2));


        }
        [Fact]
        public void RatingThrow2()      
        {
            double rating1 = -4.5;
            double rating2 = 4.3;

            

            Assert.Throws<ArgumentException>(() => Testing.GetAverage(rating1,rating2));


        }
        [Fact]
        public void RatingThrow3()      //This one failed because you are checking for exceptions, since you dont have one 
                                        // you failt the tests
        {
            double rating1 = -4.5;
            double rating2 = -4.3;

            

            Assert.Throws<ArgumentException>(() => Testing.GetAverage(rating1,rating2));


        }
    [Fact]
        public void TotalAverage()                  
        {
       
         var expectedAverage = RatingOptions.High;
         var actualAverage = Testing.TotalAverage(4.5);

         Assert.Equal(expectedAverage,actualAverage);
       

        }
        [Fact]
        public void TotalAverage2()                  //This one doesnt pass because 3.5 avrg = RatingOptions.Normal
        {
       
         var expectedAverage = RatingOptions.Normal;
         var actualAverage = Testing.TotalAverage(3.5);

         Assert.Equal(expectedAverage,actualAverage);
       

        }

       
    }
    
}
