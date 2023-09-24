using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_cp.Models
{
    public class Events
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("ButtonsEvents")]
        public int ButtonEvent_ID { get; set; }

        [ForeignKey("EventsTypes")]
        public int? EventType_ID { get; set; }

        public string? EventDescription { get; set; }

        [Required]
        public DateTime DetectingTime { get; set; }

        public DateTime? FixingTime { get; set; }

        public DateTime? TimeUpdate { get; set; }

        [ForeignKey("Users")]
        public string? User_Login { get; set; }
    }
}
