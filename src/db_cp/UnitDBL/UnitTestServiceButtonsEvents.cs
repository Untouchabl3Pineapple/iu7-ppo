using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceButtonsEvents
    {
        [Fact]
        public void TestButtonEventAdd()
        {
            IButtonsEventsRepository buttonsEventsRepository = new ButtonsEventsMock();
            IButtonsEventsService buttonsEventsService = new ButtonsEventsService(buttonsEventsRepository);

            ButtonsEvents correctButtonEvent = new ButtonsEvents
            {
                ID = 5,
                ButtonColor = "Red",
                Number = 1
            };

            buttonsEventsService.Add(correctButtonEvent);

            ButtonsEvents currentButtonEvent = buttonsEventsService.GetByID(5);


            Assert.Equal(correctButtonEvent.ButtonColor, currentButtonEvent.ButtonColor);
            Assert.Equal(correctButtonEvent.Number, currentButtonEvent.Number);
        }

        [Fact]
        public void TestButtonEventUpdate()
        {
            IButtonsEventsRepository buttonsEventsRepository = new ButtonsEventsMock();
            IButtonsEventsService buttonsEventsService = new ButtonsEventsService(buttonsEventsRepository);

            ButtonsEvents temp = new ButtonsEvents
            {
                ID = 4,
                ButtonColor = "Yellow",
                Number = 1
            };

            buttonsEventsService.Add(temp);

            ButtonsEvents correctButtonEvent = new ButtonsEvents
            {
                ID = 4,
                ButtonColor = "Red",
                Number = 1
            };

            buttonsEventsService.Update(correctButtonEvent);

            ButtonsEvents currentButtonEvent = buttonsEventsService.GetByID(4);


            Assert.Equal(correctButtonEvent.ButtonColor, currentButtonEvent.ButtonColor);
            Assert.Equal(correctButtonEvent.Number, currentButtonEvent.Number);
        }

        [Fact]
        public void TestGetButtonEventByID()
        {
            IButtonsEventsRepository buttonsEventsRepository = new ButtonsEventsMock();
            IButtonsEventsService buttonsEventsService = new ButtonsEventsService(buttonsEventsRepository);

            ButtonsEvents correctButtonEvent = new ButtonsEvents
            {
                ID = 1,
                ButtonColor = "Red",
                Number = 1
            };

            ButtonsEvents currentButtonEvent = buttonsEventsService.GetByID(1);

            Assert.Equal(correctButtonEvent.ButtonColor, currentButtonEvent.ButtonColor);
            Assert.Equal(correctButtonEvent.Number, currentButtonEvent.Number);
        }
    }
}
