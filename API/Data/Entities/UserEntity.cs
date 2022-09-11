using System.ComponentModel.DataAnnotations;

namespace AQUI_ESTOY.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
    }
}
