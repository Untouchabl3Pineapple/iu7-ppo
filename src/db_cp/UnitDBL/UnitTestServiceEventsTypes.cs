using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceEventsTypes
    {
        [Fact]
        public void TestEventTypeAdd()
        {
            IEventsTypesRepository eventsTypesRepository = new EventsTypesMock();
            IEventsTypesService eventsTypesService = new EventsTypesService(eventsTypesRepository);

            EventsTypes correctEventType = new EventsTypes
            {
                ID = 4,
                EventType = "Not enough details"
            };

            eventsTypesService.Add(correctEventType);

            EventsTypes currentEventType = eventsTypesService.GetByID(4);

            Assert.Equal(correctEventType.EventType, currentEventType.EventType);
        }

        [Fact]
        public void TestButtonEventUpdate()
        {
            IEventsTypesRepository eventsTypesRepository = new EventsTypesMock();
            IEventsTypesService eventsTypesService = new EventsTypesService(eventsTypesRepository);

            EventsTypes temp = new EventsTypes
            {
                ID = 5,
                EventType = "1 2 3 Start!!!"
            };

            eventsTypesService.Add(temp);

            EventsTypes correctEventType = new EventsTypes
            {
                ID = 5,
                EventType = "3 2 1 AAAA"
            };

            eventsTypesService.Update(correctEventType);

            EventsTypes currentEventType = eventsTypesService.GetByID(5);


            Assert.Equal(correctEventType.EventType, currentEventType.EventType);
        }

        [Fact]
        public void TestGetEventTypeByID()
        {
            IEventsTypesRepository eventsTypesRepository = new EventsTypesMock();
            IEventsTypesService eventsTypesService = new EventsTypesService(eventsTypesRepository);

            EventsTypes correctEventType = new EventsTypes
            {
                ID = 1,
                EventType = "Not enough details"
            };

            EventsTypes currentEventType = eventsTypesService.GetByID(1);

            Assert.Equal(correctEventType.EventType, currentEventType.EventType);
        }
    }
}