using System.ComponentModel.DataAnnotations;

namespace db_cp.Models
{
    public class ButtonsEvents
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string ButtonColor { get; set; }

        [Required]
        public short Number { get; set; }
    }
}
