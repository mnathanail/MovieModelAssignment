namespace MovieModelAssignment
{
    public static class RatingUtil
    {
        public static decimal RatingFromReviews(Reviews reviews)
        {
            decimal sum=0m;
            int length = reviews.Review.Count;
            foreach (Review review in reviews.Review)
            {
                if (review.ReviewRating < 1 || review.ReviewRating > 10)
                {
                    continue;
                }
                sum = sum + review.ReviewRating;
            }
            return (length != 0 ? sum / length : 0);
        }
    }
}
