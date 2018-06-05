using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieModelAssignment 
{
    public class Movies : IWrite
    {
        public List<Movie> Movie = new List<Movie>();

        public void SortByRating(Movies movies)
        {
            movies.Movie.Sort(delegate (Movie a, Movie b)
            {
                return b.Rating.CompareTo(a.Rating);
            });
        }

        public void IWriteToScreen(Movies movies, int howMany)
        {
            try
            {
                foreach (Movie mv in movies.Movie.Take(howMany))
                {
                    Console.WriteLine("| " + mv.Title );
                    Console.WriteLine("| " + mv.Earnings);
                    for (var i = 0; i < mv.Actors.Actor.Count; i++)
                    {
                        Console.WriteLine("| "+mv.Actors.Actor[i]);
                    }
                    for (var i = 0; i < mv.Reviews.Review.Count; i++)
                    {
                        Console.WriteLine("| User\'s rating:  " + mv.Reviews.Review[i].ReviewRating);
                        Console.WriteLine("| " + mv.Reviews.Review[i].ReviewText);

                    }
                    Console.WriteLine("| Total Rating: " + mv.Rating);
                    Console.WriteLine();
                }
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
