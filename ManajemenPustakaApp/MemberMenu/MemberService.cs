namespace ManajemenPustakaApp.MemberMenu;

public class MemberService
{
    private List<Member> members = new List<Member>();
    private int nextMemberNumber = 1;

    public void AddMember(Member member)
    {
        member.MemberNumber = nextMemberNumber++;
        members.Add(member);
    }

    public void EditMember(int memberNumber, Member updatedMember)
    {
        Member memberToEdit = FindMemberByMemberNumber(memberNumber);
        if (memberToEdit != null)
        {
            memberToEdit.Name = updatedMember.Name;
            memberToEdit.Email = updatedMember.Email;
        }
    }

    public void DeleteMember(int memberNumber)
    {
        Member memberToDelete = FindMemberByMemberNumber(memberNumber);
        if (memberToDelete != null)
        {
            members.Remove(memberToDelete);
        }
    }

    public List<Member> GetAllMembers()
    {
        return members;
    }

    public Member FindMemberByMemberNumber(int memberNumber)
    {
        return members.Find(member => member.MemberNumber == memberNumber);
    }
}