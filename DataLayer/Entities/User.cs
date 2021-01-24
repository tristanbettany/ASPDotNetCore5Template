using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class User
    {
        public string Id { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
