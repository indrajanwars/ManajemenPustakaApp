namespace ManajemenPustakaApp.LoanMenu
{
    class LoanManagement
    {
        private LoanService loanService;

        public LoanManagement()
        {
            loanService = new LoanService();
        }

        public void Run()
        {
            bool isLoanManagementRunning = true;

            while (isLoanManagementRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Manajemen Peminjaman Buku ===");
                Console.WriteLine("1. Pinjam Buku");
                Console.WriteLine("2. Kembalikan Buku");
                Console.WriteLine("3. Daftar Peminjaman Buku");
                Console.WriteLine("4. Kembali ke Menu Utama");
                Console.Write("Pilih menu: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BorrowBook();
                        break;
                    case "2":
                        ReturnBook();
                        break;
                    case "3":
                        ListLoans();
                        break;
                    case "4":
                        isLoanManagementRunning = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                        break;
                }
            }
        }

        private void BorrowBook()
        {
            Console.Clear();
            Console.WriteLine("=== Pinjam Buku ===");

            Console.Write("Masukkan nomor anggota: ");
            int memberNumber = int.Parse(Console.ReadLine());

            Console.Write("Masukkan ISBN buku: ");
            int bookISBN = int.Parse(Console.ReadLine());

            Console.Write("Masukkan tanggal jatuh tempo (yyyy-MM-dd): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime dueDate))
            {
                loanService.BorrowBook(memberNumber, bookISBN, dueDate);
                Console.WriteLine("Buku berhasil dipinjam. Tekan Enter untuk kembali.");
            }
            else
            {
                Console.WriteLine("Format tanggal tidak valid. Peminjaman dibatalkan. Tekan Enter untuk kembali.");
            }

            Console.ReadLine();
        }


        private void ReturnBook()
        {
            Console.Clear();
            Console.WriteLine("=== Kembalikan Buku ===");

            Console.Write("Masukkan nomor peminjaman: ");
            int loanId = int.Parse(Console.ReadLine());

            loanService.ReturnBook(loanId);

            Console.WriteLine("Buku berhasil dikembalikan. Tekan Enter untuk kembali.");
            Console.ReadLine();
        }


        private void ListLoans()
        {
            Console.Clear();
            Console.WriteLine("=== Daftar Peminjaman Buku ===");

            List<Loan> loans = loanService.GetAllLoans();

            if (loans.Count == 0)
            {
                Console.WriteLine("Tidak ada peminjaman buku saat ini.");
            }
            else
            {
                foreach (var loan in loans)
                {
                    Console.WriteLine($"ID Peminjaman: {loan.LoanId}");
                    Console.WriteLine($"Nomor Anggota: {loan.MemberNumber}");
                    Console.WriteLine($"ISBN Buku: {loan.BookISBN}");
                    Console.WriteLine($"Tanggal Jatuh Tempo: {loan.DueDate}");
                    Console.WriteLine($"Status Peminjaman: {(loan.IsReturned ? "Sudah Dikembalikan" : "Belum Dikembalikan")}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Tekan Enter untuk kembali.");
            Console.ReadLine();
        }

    }
}