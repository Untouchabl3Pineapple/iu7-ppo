using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceEvents
    {
        [Fact]
        public void TestEventAdd()
        {
            IEventsRepository eventsRepository = new EventsMock();
            IEventsService eventsService = new EventsService(eventsRepository);

            Events correctEvent = new Events
            {
                ID = 4,
                ButtonEvent_ID = 1,
                EventType_ID = 1,
                EventDescription = "Something terrible happened",
                DetectingTime = new DateTime(2022, 5, 10),
                FixingTime = new DateTime(2023, 5, 10),
                TimeUpdate = new DateTime(2024, 5, 10),
                User_Login = "PoroSad"
            };

            eventsService.Add(correctEvent);

            Events currentEvent = eventsService.GetByID(4);

            Assert.Equal(correctEvent.ButtonEvent_ID, currentEvent.ButtonEvent_ID);
            Assert.Equal(correctEvent.EventType_ID, currentEvent.EventType_ID);
            Assert.Equal(correctEvent.EventDescription, currentEvent.EventDescription);
            Assert.Equal(correctEvent.DetectingTime, currentEvent.DetectingTime);
            Assert.Equal(correctEvent.FixingTime, currentEvent.FixingTime);
            Assert.Equal(correctEvent.TimeUpdate, currentEvent.TimeUpdate);
            Assert.Equal(correctEvent.User_Login, currentEvent.User_Login);
        }

        [Fact]
        public void TestEventUpdate()
        {
            IEventsRepository eventsRepository = new EventsMock();
            IEventsService eventsService = new EventsService(eventsRepository);

            Events temp = new Events
            {
                ID = 5,
                ButtonEvent_ID = 1,
                EventType_ID = 1,
                EventDescription = "Hello",
                DetectingTime = new DateTime(2022, 5, 10),
                FixingTime = new DateTime(2023, 5, 10),
                TimeUpdate = new DateTime(2024, 5, 10),
                User_Login = "PoroSad"
            };

            eventsService.Add(temp);

            Events correctEvent = new Events
            {
                ID = 5,
                ButtonEvent_ID = 1,
                EventType_ID = 1,
                EventDescription = "Bye",
                DetectingTime = new DateTime(2022, 5, 10),
                FixingTime = new DateTime(2023, 5, 10),
                TimeUpdate = new DateTime(2024, 5, 10),
                User_Login = "PoroSad"
            };

            eventsService.Update(correctEvent);

            Events currentEvent = eventsService.GetByID(5);

            Assert.Equal(correctEvent.ButtonEvent_ID, currentEvent.ButtonEvent_ID);
            Assert.Equal(correctEvent.EventType_ID, currentEvent.EventType_ID);
            Assert.Equal(correctEvent.EventDescription, currentEvent.EventDescription);
            Assert.Equal(correctEvent.DetectingTime, currentEvent.DetectingTime);
            Assert.Equal(correctEvent.FixingTime, currentEvent.FixingTime);
            Assert.Equal(correctEvent.TimeUpdate, currentEvent.TimeUpdate);
            Assert.Equal(correctEvent.User_Login, currentEvent.User_Login);
        }

        [Fact]
        public void TestGetEventByID()
        {
            IEventsRepository eventsRepository = new EventsMock();
            IEventsService eventsService = new EventsService(eventsRepository);

            Events correctEvent = new Events
            {
                ID = 1,
                ButtonEvent_ID = 1,
                EventType_ID = 1,
                EventDescription = "Something terrible happened",
                DetectingTime = new DateTime(2022, 5, 10),
                FixingTime = new DateTime(2023, 5, 10),
                TimeUpdate = new DateTime(2024, 5, 10),
                User_Login = "PoroSad"
            };

            Events currentEvent = eventsService.GetByID(1);

            Assert.Equal(correctEvent.ButtonEvent_ID, currentEvent.ButtonEvent_ID);
            Assert.Equal(correctEvent.EventType_ID, currentEvent.EventType_ID);
            Assert.Equal(correctEvent.EventDescription, currentEvent.EventDescription);
            Assert.Equal(correctEvent.DetectingTime, currentEvent.DetectingTime);
            Assert.Equal(correctEvent.FixingTime, currentEvent.FixingTime);
            Assert.Equal(correctEvent.TimeUpdate, currentEvent.TimeUpdate);
            Assert.Equal(correctEvent.User_Login, currentEvent.User_Login);
        }
    }
}
