using System.ComponentModel.DataAnnotations;

namespace db_cp.Models
{
    public class EventsTypes
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string EventType { get; set; }
    }
}
