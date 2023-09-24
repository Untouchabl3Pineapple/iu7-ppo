using System.ComponentModel.DataAnnotations;

namespace db_cp.Models
{
    public class Users
    {
        [Key]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Permission { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string MiddleName { get; set; }
    }
}