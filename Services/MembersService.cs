using System;
using System.Collections.Generic;
using System.Linq;
using Eder.Models;

namespace Eder.Services
{
    public class MembersService : IMembersService
    {
        readonly Dictionary<int, Member> _members;
        int _lastId = 0;

        public MembersService()
        {
            _members = new Dictionary<int, Member>();

            _members.Add(_lastId, new Member()
            {
                Id = _lastId,
                FirstName = "Daniel",
                LastName = "Hughes"
            });
            _lastId++;
            _members.Add(_lastId, new Member()
            {
                Id = _lastId,
                FirstName = "Esther",
                LastName = "Hughes"
            });
            _lastId++;
            _members.Add(_lastId, new Member()
            {
                Id = _lastId,
                FirstName = "Haydn",
                LastName = "Clark"
            });
        }

        public IEnumerable<Member> GetMembers()
        {
            return _members.Values.ToList();
        }

        public void Add(Member member)
        {
            _lastId++;
            member.Id = _lastId;
            _members.Add(member.Id, member);
        }

        public void Update(Member member)
        {
            _members[member.Id] = member;
        }

        public Member GetMember(int memberId)
        {
            return _members[memberId];
        }
    }
}