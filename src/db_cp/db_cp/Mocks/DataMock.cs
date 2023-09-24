using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Numerics;

namespace db_cp.Mocks
{
    public class DataMock
    {
        static public List<ButtonsEvents> _buttonsEvents = new List<ButtonsEvents>()
        {
            new ButtonsEvents {
                ID = 1,
                ButtonColor = "Red",
                Number = 1
            },
            new ButtonsEvents {
                ID = 2,
                ButtonColor = "Red",
                Number = 2
            },
            new ButtonsEvents {
                ID = 3,
                ButtonColor = "Red",
                Number = 3
            }
        };

        static public List<ButtonsPosts> _buttonsPosts = new List<ButtonsPosts>()
        {
            new ButtonsPosts {
                Post = 1,
                LeftSide = 1,
                RightSide = 1,
                LeftColor = "Red",
                RightColor = "Yellow"
            },
            new ButtonsPosts {
                Post = 2,
                LeftSide = 2,
                RightSide = 2,
                LeftColor = "Yellow",
                RightColor = "Yellow"
            },
            new ButtonsPosts {
                Post = 3,
                LeftSide = 3,
                RightSide = 3,
                LeftColor = "Yellow",
                RightColor = "Yellow"
            }
        };

        static public List<Events> _events = new List<Events>()
        {
            new Events {
                ID = 1,
                ButtonEvent_ID = 1,
                EventType_ID = 1,
                EventDescription = "Something terrible happened",
                DetectingTime = new DateTime(2022, 5, 10),
                FixingTime = new DateTime(2023, 5, 10),
                TimeUpdate = new DateTime(2024, 5, 10),
                User_Login = "PoroSad"
            },
            new Events {
                ID = 2,
                ButtonEvent_ID = 2,
                EventType_ID = 2,
                EventDescription = "Something terrible happened",
                DetectingTime = new DateTime(2022, 5, 11),
                FixingTime = new DateTime(2023, 5, 11),
                TimeUpdate = new DateTime(2024, 5, 11),
                User_Login = "Keke322"
            },
            new Events {
                ID = 3,
                ButtonEvent_ID = 3,
                EventType_ID = 3,
                EventDescription = "Something terrible happened",
                DetectingTime = new DateTime(2022, 5, 12),
                FixingTime = new DateTime(2023, 5, 12),
                TimeUpdate = new DateTime(2024, 5, 12),
                User_Login = "HelloWorld"
            }
        };

        static public List<EventsTypes> _eventsTypes = new List<EventsTypes>()
        {
            new EventsTypes {
                ID = 1,
                EventType = "Not enough details"
            },
            new EventsTypes {
                ID = 2,
                EventType = "An employee has died :)"
            },
            new EventsTypes {
                ID = 3,
                EventType = "Detail exploded :("
            }
        };

        static public List<Users> _users = new List<Users>()
        {
            new Users {
                Login = "PoroSad",
                Password = "228",
                Permission = "user",
                Name = "Ilya",
                Surname = "Artemev",
                MiddleName = "Olegovich"
            },
            new Users {
                Login = "Keke322",
                Password = "322",
                Permission = "user",
                Name = "Kirill",
                Surname = "Riadinskii",
                MiddleName = ""
            },
            new Users {
                Login = "HelloWorld",
                Password = "12345",
                Permission = "user",
                Name = "Ivan",
                Surname = "Vasiliev",
                MiddleName = "Vladimirovich"
            }
        };
    }
}
