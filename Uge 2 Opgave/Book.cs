public class Book {
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int NumberOfPages { get; private set; }
    public int NumberOfWordsPerPage { get; set; }
    public string Genre { get; private set; }
    public bool IsBorrowed { get; private set; }
    public double Rating { get; private set; }
    private int NumberOfRatings { get; set; }
    private double TotalRating { get; set; }

    public Book(string title, string author, int numberOfPages, int numberOfWordsPerPage, string genre) {
        Title = title;
        Author = author;
        NumberOfPages = numberOfPages;
        NumberOfWordsPerPage = numberOfWordsPerPage;
        Genre = genre;
        IsBorrowed = false;
        Rating = 0;
        NumberOfRatings = 0;
        TotalRating = 0;
    }

    public int CalculateReadingTimeInMinutes => 
        NumberOfPages * NumberOfWordsPerPage / 238; // The average reading speed

    public void BorrowBook() {
        if (!IsBorrowed) {
            IsBorrowed = true;
        }
    }

    public void ReturnBook() {
        if (IsBorrowed) {
            IsBorrowed = false;
        }
    }

    public bool RateBook(double rating) {
        if (rating <= 0 || rating > 5) {
            return false;  // Indicates rating was not successful
        }

        TotalRating += rating;
        NumberOfRatings++;
        Rating = TotalRating / NumberOfRatings;
        return true;  // Indicates rating was successful
    }
}