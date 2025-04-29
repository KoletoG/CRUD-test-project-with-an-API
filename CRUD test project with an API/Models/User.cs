using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CRUD_test_project_with_an_API.Models
{
    public class User
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("username")]
        public string NotUsername { get; set; }
        [MaxLength(200)]
        [EmailAddress]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [MaxLength(30)]
        [Phone]
        [JsonPropertyName("phone")]
        public string Phone {  get; set; }
        [JsonPropertyName("website")]
        public string Website { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("address")]
        public Address Address { get; set; }
        public User()
        {
            Address = new Address();
        }
        public User(int id, string name, string notUsername, string email, string phone, string website, string note, bool isActive, DateTime createdAt, Address address)
        {
            Id = id;
            Name = name;
            NotUsername = notUsername;
            Email = email;
            Phone = phone;
            Website = website;
            Note = note;
            IsActive = isActive;
            CreatedAt = createdAt;
            Address = address;
        }
    }
}
