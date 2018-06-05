namespace MovieModelAssignment
{
    public class Movie
    {
        public string Title { get; set; }
        public long Earnings { get; set; }
        public decimal Rating { get; set; }
        public Actors Actors { get; set; }
        public Reviews Reviews { get; set; }
 
    }
}
