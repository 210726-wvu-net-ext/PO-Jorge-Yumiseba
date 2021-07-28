#! /usr/bin/bash

echo "Enter your 3 favorite movies: "
read -a movies
echo "Your 3 favorite movies are: ${movies[0]} ${movies[1]} ${movies[2]}"
echo
echo "The ratings of your 3 favorite movies are: "
echo "${movies[0]}:  9.5, Excelent choice"
echo "${movies[1]}:  10, Great movie"
echo "${movies[2]}:  9, Same as mine <3"