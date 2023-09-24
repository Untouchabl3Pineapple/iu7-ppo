using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using db_cp.Models;

namespace db_cp.ViewModels
{
    public class EventsViewModel
    {
        [Required(ErrorMessage = "EventType not specified")]
        public string EventType { get; set; }

        [Required(ErrorMessage = "EventDescription not specified")]
        public string EventDescription { get; set; }

        public IEnumerable<EventsTypes> allEventsTypes { get; set; }
    }
}
