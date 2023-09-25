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
}