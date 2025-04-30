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
                        Id, Name, NotUsername, Email, Phone, Website, Note, IsActive, CreatedAt,
                        Address_Street, Address_Suite, Address_City, Address_ZipCode, Address_Lat, Address_Lng
                        ) VALUES (
                        @Id, @Name, @NotUsername, @Email, @Phone, @Website, @Note, @IsActive, @CreatedAt,
                        @Street, @Suite, @City, @ZipCode, @Lat, @Lng
                        )";
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
                    u.CreatedAt,
                    Street = u.Address.Street,
                    Suite = u.Address.Suite,
                    City = u.Address.City,
                    ZipCode = u.Address.ZipCode,
                    Lat = u.Address.Lat,
                    Lng = u.Address.Lng
                });
                await conn.ExecuteAsync(sql, userParams);
            }
        }
    }
}
