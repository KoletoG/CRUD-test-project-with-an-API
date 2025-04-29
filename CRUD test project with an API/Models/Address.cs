using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CRUD_test_project_with_an_API.Models
{
    public class Address
    {
        [Key]
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("street")]
        public string Street { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("suite")]
        public string Suite { get; set; }
        [MaxLength(100)]
        [JsonPropertyName("city")]
        public string City { get; set; }
        [MaxLength(10)]
        [JsonPropertyName("zipcode")]
        public string ZipCode {  get; set; }
        [NotMapped]
        [JsonPropertyName("geo")]
        public Geo Geo { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Address()
        {

        }
        public void SetLatLng()
        {
            Lat = double.Parse(Geo.Lat);
            Lng= double.Parse(Geo.Lng);
        }
        public Address(int id, string street, string suite, string city, string zipCode, int userId, User user)
        {
            Id = id;
            Street = street;
            Suite = suite;
            City = city;
            ZipCode = zipCode;
            UserId = userId;
            User = user;
        }
    }
    public class Geo
    {
        [JsonPropertyName("lat")]
        public string Lat { get; set; }
        [JsonPropertyName("lng")]
        public string Lng { get; set; }
    }
}
