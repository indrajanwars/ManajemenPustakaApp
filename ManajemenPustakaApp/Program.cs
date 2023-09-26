using ManajemenPustakaApp.BookMenu;
using ManajemenPustakaApp.MemberMenu;

public class LibraryApp
{
    private LibraryService libraryService;

    public LibraryApp()
    {
        libraryService = new LibraryService();
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
            Console.WriteLine("3. Keluar");
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

