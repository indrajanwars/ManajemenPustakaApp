namespace ManajemenPustakaApp.MemberMenu;
public class MemberManagement
{
    private MemberService memberService = new MemberService();

    public void Run()
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Manajemen Anggota ===");
            Console.WriteLine("1. Tambah Anggota");
            Console.WriteLine("2. Edit Anggota");
            Console.WriteLine("3. Hapus Anggota");
            Console.WriteLine("4. Daftar Anggota");
            Console.WriteLine("5. Kembali ke Menu Utama");
            Console.Write("Pilih menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddMember();
                    break;
                case "2":
                    EditMember();
                    break;
                case "3":
                    DeleteMember();
                    break;
                case "4":
                    ListMembers();
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan coba lagi.");
                    break;
            }
        }
    }

    private void AddMember()
    {
        Console.Clear();
        Console.WriteLine("=== Tambah Anggota ===");

        Console.Write("Nama Anggota: ");
        string name = Console.ReadLine();
        Console.Write("Email Anggota: ");
        string email = Console.ReadLine();

        Member newMember = new Member
        {
            Name = name,
            Email = email
        };

        memberService.AddMember(newMember);

        Console.WriteLine("Anggota berhasil ditambahkan. Tekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }

    private void ListMembers()
    {
        Console.Clear();
        Console.WriteLine("=== Daftar Anggota ===");

        var members = memberService.GetAllMembers();

        if (members.Count == 0)
        {
            Console.WriteLine("\nDaftar anggota masih kosong.");
        }
        else
        {
            foreach (var member in members)
            {
                Console.WriteLine($"Nomor Anggota: {member.MemberNumber}\nNama: {member.Name}\nEmail: {member.Email}");
            }
        }

        Console.WriteLine("\nTekan Enter untuk kembali ke menu.");
        Console.ReadLine();
    }

    private void EditMember()
    {
        Console.Clear();
        Console.WriteLine("=== Edit Anggota ===");

        int memberNumberToEdit = GetValidMemberNumber("Masukkan nomor anggota yang akan diedit: ");
        Member memberToEdit = memberService.FindMemberByMemberNumber(memberNumberToEdit);

        if (memberToEdit != null)
        {
            Console.Write("Nama baru: ");
            string newName = Console.ReadLine();
            Console.Write("Email baru: ");
            string newEmail = Console.ReadLine();

            Member updatedMember = new Member
            {
                Name = newName,
                Email = newEmail
            };

            memberService.EditMember(memberNumberToEdit, updatedMember);
            Console.WriteLine("Anggota berhasil diedit. Tekan Enter untuk kembali ke menu.");
        }
        else
        {
            Console.WriteLine("Anggota dengan nomor anggota tersebut tidak ditemukan.");
        }

        Console.ReadLine();
    }

    private void DeleteMember()
    {
        Console.Clear();
        Console.WriteLine("=== Hapus Anggota ===");

        int memberNumberToDelete = GetValidMemberNumber("Masukkan nomor anggota yang akan dihapus: ");
        Member memberToDelete = memberService.FindMemberByMemberNumber(memberNumberToDelete);

        if (memberToDelete != null)
        {
            memberService.DeleteMember(memberNumberToDelete);
            Console.WriteLine("Anggota berhasil dihapus. Tekan Enter untuk kembali ke menu.");
        }
        else
        {
            Console.WriteLine("Anggota dengan nomor anggota tersebut tidak ditemukan.");
        }

        Console.ReadLine();
    }

    private int GetValidMemberNumber(string message)
    {
        int memberNumber;
        bool isValidMemberNumber = false;

        do
        {
            Console.Write(message);
            string inputMemberNumber = Console.ReadLine();

            if (int.TryParse(inputMemberNumber, out memberNumber))
            {
                isValidMemberNumber = true;
            }
            else
            {
                Console.WriteLine("Nomor Anggota harus berupa angka. Silakan coba lagi.");
            }
        } while (!isValidMemberNumber);

        return memberNumber;
    }
}

