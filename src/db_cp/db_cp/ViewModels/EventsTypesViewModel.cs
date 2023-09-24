using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using db_cp.Models;

namespace db_cp.ViewModels
{
    public class EventTypeViewModel
    {
        [Required(ErrorMessage = "EventType not specified")]
        public string EventType { get; set; }

        public IEnumerable<EventsTypes> allEventsTypes { get; set; }
    }
}
