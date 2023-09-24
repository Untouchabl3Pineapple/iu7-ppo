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
    public class UnitTestButtonsEvents
    {
        [Fact]
        public void TestButtonEventAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                ButtonsEventsRepository buttonEventRepository = new ButtonsEventsRepository(context);

                ButtonsEvents correctButtonEvent = new ButtonsEvents
                {
                    ID = 1,
                    ButtonColor = "Red",
                    Number = 1
                };

                buttonEventRepository.Add(correctButtonEvent);
                ButtonsEvents currentButtonEvent = context.ButtonsEvents.Find(1);

                Assert.Equal(correctButtonEvent.ButtonColor, currentButtonEvent.ButtonColor);
                Assert.Equal(correctButtonEvent.Number, currentButtonEvent.Number);
            }
        }

        [Fact]
        public void TestButtonEventUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.ButtonsEvents.Add(new ButtonsEvents
                {
                    ID = 1,
                    ButtonColor = "Red",
                    Number = 1
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ButtonsEventsRepository buttonEventRepository = new ButtonsEventsRepository(context);

                ButtonsEvents correctButtonEvent = new ButtonsEvents
                {
                    ID = 1,
                    ButtonColor = "Yellow",
                    Number = 1
                };

                buttonEventRepository.Update(correctButtonEvent);
                ButtonsEvents currentButtonEvent = context.ButtonsEvents.Find(1);

                Assert.Equal(correctButtonEvent.ButtonColor, currentButtonEvent.ButtonColor);
                Assert.Equal(correctButtonEvent.Number, currentButtonEvent.Number);
            }
        }

        [Fact]
        public void TestGetButtonEventById()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.ButtonsEvents.Add(new ButtonsEvents
                {
                    ID = 1,
                    ButtonColor = "Yellow",
                    Number = 1
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                ButtonsEventsRepository buttonEventRepository = new ButtonsEventsRepository(context);
                var bevent = buttonEventRepository.GetByID(1);

                Assert.Equal("Yellow", bevent.ButtonColor);
                Assert.Equal(1, bevent.Number);
            }
        }
    }
}
