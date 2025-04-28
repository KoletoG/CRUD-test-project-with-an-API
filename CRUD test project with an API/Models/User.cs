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
        public User()
        {

        }
    }
}
