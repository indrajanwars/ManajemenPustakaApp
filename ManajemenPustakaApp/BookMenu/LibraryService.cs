namespace ManajemenPustakaApp.BookMenu;

public class LibraryService
{
    private BookService bookService;

    public LibraryService()
    {
        bookService = new BookService();
    }

    public void AddBookToLibrary(Book book)
    {
        bookService.AddBook(book);
    }

    public void EditBookInLibrary(int isbn, Book updatedBook)
    {
        bookService.EditBook(isbn, updatedBook);
    }

    public void DeleteBookFromLibrary(int isbn)
    {
        bookService.DeleteBook(isbn);
    }

    public List<Book> GetAllBooksInLibrary()
    {
        return bookService.GetAllBooks();
    }
}