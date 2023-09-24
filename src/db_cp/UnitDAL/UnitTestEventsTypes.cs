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
    public class UnitTestEventsTypes
    {
        [Fact]
        public void TestEventTypeAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                EventsTypesRepository eventTypeRepository = new EventsTypesRepository(context);

                EventsTypes correctEventType = new EventsTypes
                {
                    ID = 1,
                    EventType = "Not enough details"
                };

                eventTypeRepository.Add(correctEventType);
                EventsTypes currentEventType = context.EventsTypes.Find(1);

                Assert.Equal(correctEventType.EventType, currentEventType.EventType);
            }
        }

        [Fact]
        public void TestEventTypeUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.EventsTypes.Add(new EventsTypes
                {
                    ID = 1,
                    EventType = "Not enough details"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                EventsTypesRepository eventTypeRepository = new EventsTypesRepository(context);

                EventsTypes correctEventType = new EventsTypes
                {
                    ID = 1,
                    EventType = "Not enough money"
                };

                eventTypeRepository.Update(correctEventType);
                EventsTypes currentEventType = context.EventsTypes.Find(1);

                Assert.Equal(correctEventType.EventType, currentEventType.EventType);
            }
        }

        [Fact]
        public void TestGetEventTypeById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.EventsTypes.Add(new EventsTypes
                {
                    ID = 1,
                    EventType = "Not enough details"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                EventsTypesRepository eventTypeRepository = new EventsTypesRepository(context);
                var eventtype = eventTypeRepository.GetByID(1);

                Assert.Equal("Not enough details", eventtype.EventType);
            }
        }
    }
}
