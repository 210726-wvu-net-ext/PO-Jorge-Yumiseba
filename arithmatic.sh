#! /usr/bin/bash

#1 Even - Odd numbers

read -p "Enter your number: " num

test=`expr $num % 2`
   if [ $test -eq 0 ]
   then
      echo "$num is even"
   else
   echo "$num is odd"
   fi
   


# Problem2 

read -p "Enter your grade: " grade

if (( $grade <= 40 ))
then
    echo " You got an F"
elif (( $grade > 40 && $grade <= 50 ))
then
    echo "You got a D"
elif (( $grade > 50 && $grade <= 60 ))
then
    echo "You got a C"
elif (( $grade > 60 && $grade <= 70 ))
then
    echo "You got a B"
    elif (( $grade > 70 && $grade <= 100 ))
then
    echo "You got an A"
elif (( $grade > 100 ))
then
    echo "Values cannot be grater than 100"
fi