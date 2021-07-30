 #! /usr/bin/bash

 #Activity 2
n=1

while (( $n <= 20 ))
do
    
    if (( $((n%3)) == 0 && $((n%5)) == 0 ))
    then
        echo  "$n = fizzbuzz"

    elif (( $((n%3)) == 0 ))
    then    
        echo "$n = Fizz"

    elif (( $((n%5)) == 0 ))
    then    
        echo "$n = Buss"
    else
        echo "$n = Nothing... :v"
    fi
(( n++ ))
done

