using System;
using System.Collections.Generic;
using db_cp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace db_cp.ViewModels
{

    public class HomeViewModel
    {
        public IEnumerable<ButtonsPosts> allButtonsPosts { get; set; }
        public IEnumerable<ButtonsEvents> allButtonsEvents { get; set; }
        public IEnumerable<EventsTypes> allEventsTypes { get; set; }
        public IEnumerable<Events> allEvents { get; set; }
    }
}
