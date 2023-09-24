using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using db_cp.Models;
using db_cp.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace UnitDAL
{
    public class UnitTestEvents
    {
        [Fact]
        public void TestEventAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                EventsRepository eventRepository = new EventsRepository(context);

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

                eventRepository.Add(correctEvent);
                Events currentEvent = context.Events.Find(1);

                Assert.Equal(correctEvent.ButtonEvent_ID, currentEvent.ButtonEvent_ID);
                Assert.Equal(correctEvent.EventType_ID, currentEvent.EventType_ID);
                Assert.Equal(correctEvent.EventDescription, currentEvent.EventDescription);
                Assert.Equal(correctEvent.DetectingTime, currentEvent.DetectingTime);
                Assert.Equal(correctEvent.FixingTime, currentEvent.FixingTime);
                Assert.Equal(correctEvent.TimeUpdate, currentEvent.TimeUpdate);
                Assert.Equal(correctEvent.User_Login, currentEvent.User_Login);
            }
        }

        [Fact]
        public void TestEventUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Events.Add(new Events
                {
                    ID = 1,
                    ButtonEvent_ID = 1,
                    EventType_ID = 1,
                    EventDescription = "Something terrible happened",
                    DetectingTime = new DateTime(2022, 5, 10),
                    FixingTime = new DateTime(2023, 5, 10),
                    TimeUpdate = new DateTime(2024, 5, 10),
                    User_Login = "PoroSad"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                EventsRepository eventRepository = new EventsRepository(context);

                Events correctEvent = new Events
                {
                    ID = 1,
                    ButtonEvent_ID = 1,
                    EventType_ID = 1,
                    EventDescription = "kkk",
                    DetectingTime = new DateTime(2022, 5, 10),
                    FixingTime = new DateTime(2023, 5, 10),
                    TimeUpdate = new DateTime(2024, 5, 10),
                    User_Login = "PoroSad"
                };

                eventRepository.Update(correctEvent);
                Events currentEvent = context.Events.Find(1);

                Assert.Equal(correctEvent.ButtonEvent_ID, currentEvent.ButtonEvent_ID);
                Assert.Equal(correctEvent.EventType_ID, currentEvent.EventType_ID);
                Assert.Equal(correctEvent.EventDescription, currentEvent.EventDescription);
                Assert.Equal(correctEvent.DetectingTime, currentEvent.DetectingTime);
                Assert.Equal(correctEvent.FixingTime, currentEvent.FixingTime);
                Assert.Equal(correctEvent.TimeUpdate, currentEvent.TimeUpdate);
                Assert.Equal(correctEvent.User_Login, currentEvent.User_Login);
            }
        }

        [Fact]
        public void TestGetEventById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Events.Add(new Events
                {
                    ID = 1,
                    ButtonEvent_ID = 1,
                    EventType_ID = 1,
                    EventDescription = "Something terrible happened",
                    DetectingTime = new DateTime(2022, 5, 10),
                    FixingTime = new DateTime(2023, 5, 10),
                    TimeUpdate = new DateTime(2024, 5, 10),
                    User_Login = "PoroSad"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                EventsRepository eventRepository = new EventsRepository(context);
                var eevent = eventRepository.GetByID(1);

                Assert.Equal(1, eevent.ButtonEvent_ID);
                Assert.Equal(1, eevent.EventType_ID);
                Assert.Equal("Something terrible happened", eevent.EventDescription);
                Assert.Equal(new DateTime(2022, 5, 10), eevent.DetectingTime);
                Assert.Equal(new DateTime(2023, 5, 10), eevent.FixingTime);
                Assert.Equal(new DateTime(2024, 5, 10), eevent.TimeUpdate);
                Assert.Equal("PoroSad", eevent.User_Login);
            }
        }
    }
}
