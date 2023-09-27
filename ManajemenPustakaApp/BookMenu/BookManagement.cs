namespace ManajemenPustakaApp.BookMenu;
public class BookManagement
{
    private LibraryService libraryService;

    public BookManagement(LibraryService service)
    {
        libraryService = service;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== Manajemen Buku ===");
            Console.WriteLine("1. Tambahkan Buku");
            Console.WriteLine("2. Edit Buku");
            Console.WriteLine("3. Hapus Buku");
            Console.WriteLine("4. Daftar Buku");
            Console.WriteLine("5. Kembali ke Menu Utama");
            Console.Write("Pilih menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    EditBook();
                    break;
                case "3":
                    DeleteBook();
                    break;
                case "4":
                    ListBooks();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }

    private void AddBook()
    {
        Console.Clear();
        Console.WriteLine("=== Tambahkan Buku ===");

        int isbn;
        bool isValidISBN = false;

        do
        {
            Console.Write("No. ISBN: ");
            string inputISBN = Console.ReadLine();

            if (int.TryParse(inputISBN, out isbn))
            {
                isValidISBN = true;
            }
            else
            {
                Console.WriteLine("ISBN harus berupa angka. Silakan coba lagi.");
            }
        } while (!isValidISBN);

        Console.Write("Judul: ");
        string title = Console.ReadLine();
        Console.Write("Pengarang: ");
        string author = Console.ReadLine();

        Book newBook = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author
        };

        libraryService.AddBookToLibrary(newBook);
        Console.WriteLine("Buku berhasil ditambahkan. Tekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }

    private void EditBook()
    {
        Console.Clear();
        Console.WriteLine("=== Edit Buku ===");
        Console.Write("ISBN buku yang akan diedit: ");
        int isbn = int.Parse(Console.ReadLine());

        Console.Write("Judul baru: ");
        string title = Console.ReadLine();
        Console.Write("Pengarang baru: ");
        string author = Console.ReadLine();

        Book updatedBook = new Book
        {
            ISBN = isbn,
            Title = title,
            Author = author
        };

        libraryService.EditBookInLibrary(isbn, updatedBook);
        Console.WriteLine("Buku berhasil diedit. Tekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }

    private void DeleteBook()
    {
        Console.Clear();
        Console.WriteLine("=== Hapus Buku ===");
        Console.Write("ISBN buku yang akan dihapus: ");
        int isbn = int.Parse(Console.ReadLine());

        libraryService.DeleteBookFromLibrary(isbn);
        Console.WriteLine("Buku berhasil dihapus. Tekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }

    private void ListBooks()
    {
        Console.Clear();
        Console.WriteLine("=== Daftar Buku dalam Pustaka ===");
        var booksInLibrary = libraryService.GetAllBooksInLibrary();

        if (booksInLibrary.Count == 0)
        {
            Console.WriteLine("\nDaftar Buku masih kosong.");
        }
        else
        {
            foreach (var book in booksInLibrary)
            {
                Console.WriteLine($"ISBN: {book.ISBN}\nJudul: {book.Title}\nPengarang: {book.Author}");
            }
        }

        Console.WriteLine("\nTekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }
}