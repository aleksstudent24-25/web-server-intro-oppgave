class Library
{
  List<Book> books;

  public Library()
  {
    books = new List<Book>();
  }

  public void AddNewBook(Book newBook)
  {
    books.Add(newBook);
  }

  public List<Book> ListAvailableBooks()
  {
    // Filtrer ut alle utlånte bøker
    List<Book> availableBooks = books.FindAll((book) => !book.IsBorrowed);

    return availableBooks;
  }

  public List<Book> ListLoanedBooks() {
    List<Book> loanedBooks = books.FindAll((book) => book.IsBorrowed);

    return loanedBooks;
  }

  public Book? BorrowBook(string title)
  {
    // Finn tilgjengelige bøker
    List<Book> availbleBooks = ListAvailableBooks();
    // Finn ut om vi har den spesifikke boke tilgjengelig
    Book? book = availbleBooks.Find((book) => book.Title == title);
    book?.Borrow();
    // Return resultatet
    return book;
  }

  public Book? ReturnBook(string title)
  {
    // Finn tilgjengelige bøker
    List<Book> availbleBooks = ListLoanedBooks();
    // Finn ut om vi har den spesifikke boke tilgjengelig
    Book? book = availbleBooks.Find((book) => book.Title == title);
    book?.Return();
    // Return resultatet
    return book;
  }
}