using System.Collections.Generic;
using Eder.Models;

namespace Eder.Services
{
    public interface IMembersService
    {
        IEnumerable<Member> GetMembers();
        void Add(Member member);
        Member GetMember(int memberId);
        void Update(Member member);
    }
}