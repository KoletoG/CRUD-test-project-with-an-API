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
            string sql = @"
                        INSERT INTO Users (
                        Name, NotUsername, Email, Phone, Website, Note, IsActive, CreatedAt
                        ) VALUES (
                        @Name, @NotUsername, @Email, @Phone, @Website, @Note, @IsActive, @CreatedAt
                        )";
            using (var conn = Connection)
            {
                var userParams = users.Select(u => new
                {
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
