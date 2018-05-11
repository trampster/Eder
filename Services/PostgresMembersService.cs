using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Eder.Models;
using Npgsql;

namespace Eder.Services
{
    public class PostgresMembersService : IMembersService
    {
        readonly IDbConnection _connection;

        public PostgresMembersService()
        {
            _connection = OpenConnection("Host=localhost;Username=postgres;password=yourpassword;");
        }

        public static IDbConnection OpenConnection(string connStr)  
        {  
            var conn = new NpgsqlConnection(connStr);  
            conn.Open();  
            return conn;  
        }

        public IEnumerable<Member> GetMembers()
        {
            return _connection.Query<Member>("Select * From Member").ToList();
        }

        public void Add(Member member)
        {
            _connection.Execute(
                "Insert Into Member (FirstName, LastName, Email) Values(@FirstName, @LastName, @Email)", 
                member);
        }

        public void Update(Member member)
        {
            _connection.Execute(
                "Update Member " +
                "Set FirstName = @FirstName, LastName = @LastName, Email = @Email " +
                "Where Id=@Id", 
                member);
        }

        public Member GetMember(int memberId)
        {
            return _connection.Query<Member>("Select * From Member Where Id=@Id", new {Id=memberId}).Single();
        }
    }
}