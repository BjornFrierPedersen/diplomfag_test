namespace Uge_2_Tests;

public class BookTest
{
    [Fact]
    public void Assert_Property_Title_Is_Set()
    {
        //Arrange
        //Act
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");

        //Assert
        Assert.Equal("The Subtle Art of Not Giving a F*ck", book.Title);
    }
    
    [Fact]
    public void Assert_Property_Author_Is_Set()
    {
        //Arrange
        //Act
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");

        //Assert
        Assert.Equal("Mark Manson", book.Author);
    }
    
    [Fact]
    public void Assert_Property_Genre_Is_Set()
    {
        //Arrange
        //Act
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");

        //Assert
        Assert.Equal("Self help", book.Genre);
    }
    
    [Fact]
    public void Assert_CalculateReadingTimeInMinutes_Is_NumberOfPages_Times_NumberOfWordsPerMinute_Divided_With_Average_Reading_Speed()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        
        //Act
        var readingTime = book.CalculateReadingTimeInMinutes;

        //Assert
        Assert.Equal(244, readingTime);
    }
    
    
    [Fact]
    public void Assert_BorrowBook_On_An_Available_Book_Sets_Borrowed_Equal_To_True()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        
        //Act
        var isBorrowedBefore = book.IsBorrowed;
        book.BorrowBook();
        var isBorrowedAfter = book.IsBorrowed;

        //Assert
        Assert.False(isBorrowedBefore);
        Assert.True(isBorrowedAfter);
    }
    
    [Fact]
    public void Assert_BorrowBook_On_An_Already_Borrowed_Book_Does_Nothing()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        book.BorrowBook();
        
        //Act
        var isBorrowedBefore = book.IsBorrowed;
        book.BorrowBook();
        var isBorrowedAfter = book.IsBorrowed;

        //Assert
        Assert.True(isBorrowedBefore);
        Assert.True(isBorrowedAfter);
    }
    
    [Fact]
    public void Assert_ReturnBook_On_A_Borrows_Book_Sets_IsBorrowed_To_False()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        book.BorrowBook();
        
        //Act
        var isBorrowedBefore = book.IsBorrowed;
        book.ReturnBook();
        var isBorrowedAfter = book.IsBorrowed;

        //Assert
        Assert.True(isBorrowedBefore);
        Assert.False(isBorrowedAfter);
    }
    
    [Fact]
    public void Assert_ReturnBook_On_An_Already_Returned_Book_Does_Nothing()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        
        //Act
        var isBorrowedBefore = book.IsBorrowed;
        book.ReturnBook();
        var isBorrowedAfter = book.IsBorrowed;

        //Assert
        Assert.False(isBorrowedBefore);
        Assert.False(isBorrowedAfter);
    }

    [Theory]
    [InlineData(-1, false)]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    public void Assert_RateBook_Rating_Out_Of_Bound_Returns_False(int rating, bool expectedRatedSuccessFully)
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        
        //Act
        var isRatedSuccessFully = book.RateBook(rating);

        //Assert
        Assert.Equal(expectedRatedSuccessFully, isRatedSuccessFully);
    }
    
    [Fact]
    public void Assert_RateBook_Rating_Is_An_Average_Of_Total_Ratings()
    {
        //Arrange
        var book = new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help");
        
        //Act
        book.RateBook(1);
        var ratingBefore = book.Rating;
        book.RateBook(5);
        var ratingAfter = book.Rating;

        //Assert
        Assert.Equal(1, ratingBefore);
        Assert.Equal(3, ratingAfter);
    }

    [Fact]
    public void When_creating_a_set_of_books_and_borrowing()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book("The Subtle Art of Not Giving a F*ck", "Mark Manson", 224, 260, "Self help"),
            new Book("Harry Potter and The Sorceres Stone", "J. K. Rowling", 223, 345, "Fantasy"),
            new Book("Harry Potter and The Chamber of Secrets", "J. K. Rowling", 251, 339, "Fantasy"),
            new Book("Harry Potter and The Prisoner of Azkaban", "J. K. Rowling", 317, 338, "Fantasy"),
            new Book("Harry Potter and The Goblet of Fire", "J. K. Rowling", 636, 299, "Fantasy"),
        };
        books.ForEach(book => book.BorrowBook());

    }
    
    [Fact]
    public void TestBookLifecycleIntegration()
    {
        // Arrange
        var title = "Sample Book";
        var author = "John Doe";
        var numberOfPages = 300;
        var numberOfWordsPerPage = 250;
        var genre = "Fiction";

        var book = new Book(title, author, numberOfPages, numberOfWordsPerPage, genre);

        // Act
        book.BorrowBook();
        var borrowStatus = book.IsBorrowed;
        book.ReturnBook();
        var returnStatus = !book.IsBorrowed;

        var ratingStatus = book.RateBook(4.5); // Rate the book with a valid rating

        // Assert
        Assert.Multiple(() =>
        {
            Assert.True(borrowStatus, "Book should be marked as borrowed.");
            Assert.True(returnStatus, "Book should be marked as returned.");
            Assert.True(ratingStatus, "Rating the book should be successful.");

            Assert.Equal(title, book.Title); // Title should match
            Assert.Equal(author, book.Author); // Author should match
            Assert.Equal(numberOfPages, book.NumberOfPages); // Number of pages should match
            Assert.Equal(numberOfWordsPerPage, book.NumberOfWordsPerPage); // Words per page should match
            Assert.Equal(genre, book.Genre); // Genre should match
            Assert.Equal(4.5, book.Rating, 0.001); // Rating should match
        });
    }
}
