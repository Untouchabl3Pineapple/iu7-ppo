using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_cp.Models
{
    public class News
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime Time { get; set; }
    }
}