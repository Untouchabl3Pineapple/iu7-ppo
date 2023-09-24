using System.ComponentModel.DataAnnotations;

namespace db_cp.Models
{
    public class ButtonsPosts
    {
        [Key]
        public int Post { get; set; }

        [Required]
        public short LeftSide { get; set; }

        [Required]
        public short RightSide { get; set; }

        [Required]
        public string LeftColor { get; set; }

        [Required]
        public string RightColor { get; set; }
    }
}
