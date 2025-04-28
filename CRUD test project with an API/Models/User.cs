using System.ComponentModel.DataAnnotations;

namespace CRUD_test_project_with_an_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string NotUsername { get; set; }
        [MaxLength(200)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(30)]
        [Phone]
        public string Phone {  get; set; }
        public string Website { get; set; }
        public string Note { get; set; }
        public byte IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Address> Addresses { get; set; }
        public User()
        {
            Addresses = new List<Address>();
        }
        public User(int id, string name, string notUsername, string email, string phone, string website, string note, byte isActive, DateTime createdAt, List<Address> addresses)
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
            Addresses = addresses;
        }
    }
}
