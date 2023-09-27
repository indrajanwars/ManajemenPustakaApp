namespace ManajemenPustakaApp.BookMenu;

public class BookService
{
    private List<Book> books;

    public BookService()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
    }

    public void EditBook(int isbn, Book updatedBook)
    {
        var bookToEdit = books.FirstOrDefault(b => b.ISBN == isbn);
        if (bookToEdit != null)
        {
            bookToEdit.Title = updatedBook.Title;
            bookToEdit.Author = updatedBook.Author;
        }
    }

    public void DeleteBook(int isbn)
    {
        var bookToDelete = books.FirstOrDefault(b => b.ISBN == isbn);
        if (bookToDelete != null)
        {
            books.Remove(bookToDelete);
        }
    }

    public List<Book> GetAllBooks()
    {
        return books;
    }
}