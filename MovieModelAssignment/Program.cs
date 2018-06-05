using System;
using System.Xml;

namespace MovieModelAssignment
{
    class Program
    {
        
        static void Main(string[] args)
        {
            const int AMOUNT = 10;
            
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(@"Data.xml");
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Movies/Movie");
                Movies movies = new Movies();
                foreach (XmlNode node in nodes)
                {
                    Movie movieObj = new Movie();
                    movieObj.Title = node.SelectSingleNode("Title").InnerText;
                    movieObj.Earnings = ValidationUtils.IsLong(node.SelectSingleNode("Earnings").InnerText);
                    Actors actors = new Actors();
                    for(int i=0; i < node["Actors"].ChildNodes.Count; i++)
                    {
                        actors.Actor.Add(node["Actors"].ChildNodes.Item(i).InnerText); 
                    }
                    movieObj.Actors = actors;

                    Reviews reviews = new Reviews();
                    for(int i = 0; i < node["Reviews"].SelectNodes("Review").Count; i++)
                    {
                        Review review = new Review();
                        review.ReviewRating = ValidationUtils.IsDecimal(node["Reviews"].SelectNodes("Review").Item(i).SelectSingleNode("ReviewRating").InnerText);
                        review.ReviewText=(node["Reviews"].SelectNodes("Review").Item(i).SelectSingleNode("ReviewText").InnerText);
                        reviews.Review.Add(review);
                    }
                    movieObj.Reviews = reviews;
                    movieObj.Rating = RatingUtil.RatingFromReviews(movieObj.Reviews); 

                    movies.Movie.Add(movieObj);
                }

                movies.SortByRating(movies);       
                movies.IWriteToScreen(movies, AMOUNT);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
