namespace ManajemenPustakaApp.LoanMenu;

public class Loan
{
    public int LoanId { get; set; }
    public int MemberNumber { get; set; }
    public int BookISBN { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsReturned { get; set; }
}