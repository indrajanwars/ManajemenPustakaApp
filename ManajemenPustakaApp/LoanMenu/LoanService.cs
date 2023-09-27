namespace ManajemenPustakaApp.LoanMenu;

public class LoanService
{
    private List<Loan> loans = new List<Loan>();
    private int nextLoanId = 1;

    public void BorrowBook(int memberNumber, int bookISBN, DateTime dueDate)
    {
        var newLoan = new Loan
        {
            LoanId = nextLoanId++,
            MemberNumber = memberNumber,
            BookISBN = bookISBN,
            DueDate = dueDate,
            IsReturned = false
        };
        loans.Add(newLoan);
    }

    public void ReturnBook(int loanId)
    {
        var loan = loans.FirstOrDefault(l => l.LoanId == loanId);
        if (loan != null)
        {
            loan.IsReturned = true;
        }
    }

    public List<Loan> GetLoansByMember(int memberNumber)
    {
        return loans.Where(loan => loan.MemberNumber == memberNumber).ToList();
    }

    public Loan GetLoanById(int loanId)
    {
        return loans.FirstOrDefault(loan => loan.LoanId == loanId);
    }

    public List<Loan> GetAllLoans()
    {
        return loans;
    }

}