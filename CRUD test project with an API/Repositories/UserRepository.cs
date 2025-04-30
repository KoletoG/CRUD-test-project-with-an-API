using CRUD_test_project_with_an_API.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CRUD_test_project_with_an_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);

        public async Task AddUsers(List<User> users)
        {
            string checkSql = "SELECT COUNT(1) FROM Users WHERE Id = @Id";

            bool exists = Connection.ExecuteScalar<int>(checkSql, new { Id = users[0].Id }) > 0;

            if (exists)
            {
                string delsql = "DELETE FROM Users";
                Connection.Execute(delsql);
            }
            string sql = @"
                        SET IDENTITY_INSERT Users ON;
                        INSERT INTO Users (Id, Name, NotUsername, Email, Phone, Website, Note, IsActive, CreatedAt
                        ) VALUES (
                        @Id, @Name, @NotUsername, @Email, @Phone, @Website, @Note, @IsActive, @CreatedAt
                        );
                        SET IDENTITY_INSERT Users OFF;";
            using (var conn = Connection)
            {
                var userParams = users.Select(u => new
                {
                    u.Id,
                    u.Name,
                    u.NotUsername,
                    u.Email,
                    u.Phone,
                    u.Website,
                    u.Note,
                    u.IsActive,
                    u.CreatedAt
                });
                await conn.ExecuteAsync(sql, userParams);
            }
        }
    }
}
