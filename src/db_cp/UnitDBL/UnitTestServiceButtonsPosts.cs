using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceButtonsPosts
    {
        [Fact]
        public void TestButtonPostAdd()
        {
            IButtonsPostsRepository buttonsPostsRepository = new ButtonsPostsMock();
            IButtonsPostsService buttonsPostsService = new ButtonsPostsService(buttonsPostsRepository);

            ButtonsPosts correctButtonPost = new ButtonsPosts
            {
                Post = 5,
                LeftSide = 1,
                RightSide = 1,
                LeftColor = "Red",
                RightColor = "Yellow"
            };

            buttonsPostsService.Add(correctButtonPost);

            ButtonsPosts currentButtonPost = buttonsPostsService.GetByPost(5);


            Assert.Equal(correctButtonPost.LeftSide, currentButtonPost.LeftSide);
            Assert.Equal(correctButtonPost.RightSide, currentButtonPost.RightSide);
            Assert.Equal(correctButtonPost.LeftColor, currentButtonPost.LeftColor);
            Assert.Equal(correctButtonPost.RightColor, currentButtonPost.RightColor);
        }

        [Fact]
        public void TestButtonPostUpdate()
        {
            IButtonsPostsRepository buttonsPostsRepository = new ButtonsPostsMock();
            IButtonsPostsService buttonsPostsService = new ButtonsPostsService(buttonsPostsRepository);

            ButtonsPosts temp = new ButtonsPosts
            {
                Post = 4,
                LeftSide = 1,
                RightSide = 1,
                LeftColor = "Red",
                RightColor = "Red"
            };

            buttonsPostsService.Add(temp);

            ButtonsPosts correctButtonPost = new ButtonsPosts
            {
                Post = 4,
                LeftSide = 1,
                RightSide = 1,
                LeftColor = "Red",
                RightColor = "Red"
            };

            buttonsPostsService.Update(correctButtonPost);

            ButtonsPosts currentButtonPost = buttonsPostsService.GetByPost(4);

            Assert.Equal(correctButtonPost.LeftSide, currentButtonPost.LeftSide);
            Assert.Equal(correctButtonPost.RightSide, currentButtonPost.RightSide);
            Assert.Equal(correctButtonPost.LeftColor, currentButtonPost.LeftColor);
            Assert.Equal(correctButtonPost.RightColor, currentButtonPost.RightColor);
        }

        [Fact]
        public void TestGetButtonPostByID()
        {
            IButtonsPostsRepository buttonsPostsRepository = new ButtonsPostsMock();
            IButtonsPostsService buttonsPostsService = new ButtonsPostsService(buttonsPostsRepository);

            ButtonsPosts correctButtonPost = new ButtonsPosts
            {
                Post = 1,
                LeftSide = 1,
                RightSide = 1,
                LeftColor = "Red",
                RightColor = "Yellow"
            };

            ButtonsPosts currentButtonPost = buttonsPostsService.GetByPost(1);

            Assert.Equal(correctButtonPost.LeftSide, currentButtonPost.LeftSide);
            Assert.Equal(correctButtonPost.RightSide, currentButtonPost.RightSide);
            Assert.Equal(correctButtonPost.LeftColor, currentButtonPost.LeftColor);
            Assert.Equal(correctButtonPost.RightColor, currentButtonPost.RightColor);
        }
    }
}