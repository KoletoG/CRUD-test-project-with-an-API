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
            await Connection.ExecuteAsync(sql, userParams);
        }
        public async Task UpdateUsers(List<User> users)
        {
            
            string sql = @"
        UPDATE Users
        SET Note = @Note,
            IsActive = @IsActive
        WHERE Id = @Id";

            await Connection.ExecuteAsync(sql, users.Select(u => new
            {
                u.Note,
                u.IsActive,
                u.Id
            }));
        }
        public async Task AddAddress(List<Address> addresses)
        {
            string checkSql = "SELECT COUNT(1) FROM Addresses WHERE Id = @Id";
            bool exists = Connection.ExecuteScalar<int>(checkSql, new { Id = addresses[0].Id }) > 0;
            if (exists)
            {
                string delsql = "DELETE FROM Addresses";
                Connection.Execute(delsql);
            }
            string sql = @"
                        INSERT INTO Addresses (Street, Suite, City, ZipCode, Lat, Lng, UserId
                        ) VALUES (
                         @Street, @Suite, @City, @ZipCode, @Lat, @Lng, @UserId
                        );";
            var addressParams = addresses.Select(a => new
            {
                a.Street,
                a.Suite,
                a.City,
                a.ZipCode,
                a.Lat,
                a.Lng,
                a.UserId
            });
            await Connection.ExecuteAsync(sql, addressParams);
        }
        public async Task<List<User>> FetchUsers()
        {
            string sql = @"SELECT * FROM Users";
            var result = await Connection.QueryAsync<User>(sql);
            return result.ToList();
        }
        public async Task<User?> FetchUser(int id)
        {
            string sql = @"SELECT * FROM Users WHERE Id = @Id";
            var result = await Connection.QueryAsync<User>(sql, new { Id = id });
            return result.FirstOrDefault();
        }
    }
}
