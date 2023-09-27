using ManajemenPustakaApp.BookMenu;
using ManajemenPustakaApp.LoanMenu;
using ManajemenPustakaApp.MemberMenu;

public class LibraryApp
{
    private LibraryService libraryService;
    private LoanManagement loanManagement;

    public LibraryApp()
    {
        libraryService = new LibraryService();
        loanManagement = new LoanManagement();
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== Aplikasi Manajemen Pustaka ===");
            Console.WriteLine("1. Manajemen Buku");
            Console.WriteLine("2. Manajemen Anggota");
            Console.WriteLine("3. Manajemen Peminjaman Buku");
            Console.WriteLine("4. Keluar");
            Console.Write("Pilih menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BookManagement bookManagement = new BookManagement(libraryService);
                    bookManagement.Run();
                    break;
                case "2":
                    MemberManagement memberManagement = new MemberManagement();
                    memberManagement.Run();
                    break;
                case "3":
                    loanManagement.Run();
                    break;                    
                case "4":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }

    static void Main()
    {
        LibraryApp app = new LibraryApp();
        app.Run();
    }
}