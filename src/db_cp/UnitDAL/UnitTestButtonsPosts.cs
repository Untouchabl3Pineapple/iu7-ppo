using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using db_cp.Models;
using db_cp.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using db_cp.Interfaces;

namespace UnitDAL
{
    public class UnitTestButtonsPosts
    {
        [Fact]
        public void TestButtonPostAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                ButtonsPostsRepository buttonPostRepository = new ButtonsPostsRepository(context);

                ButtonsPosts correctButtonPost = new ButtonsPosts
                {
                    Post = 1,
                    LeftSide = 1,
                    RightSide = 1,
                    LeftColor = "Red",
                    RightColor = "Yellow"
                };

                buttonPostRepository.Add(correctButtonPost);
                ButtonsPosts currentButtonPost = context.ButtonsPosts.Find(1);

                Assert.Equal(correctButtonPost.LeftSide, currentButtonPost.LeftSide);
                Assert.Equal(correctButtonPost.RightSide, currentButtonPost.RightSide);
                Assert.Equal(correctButtonPost.LeftColor, currentButtonPost.LeftColor);
                Assert.Equal(correctButtonPost.RightColor, currentButtonPost.RightColor);
            }
        }

        [Fact]
        public void TestButtonPostUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.ButtonsPosts.Add(new ButtonsPosts
                {
                    Post = 1,
                    LeftSide = 1,
                    RightSide = 1,
                    LeftColor = "Red",
                    RightColor = "Yellow"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                ButtonsPostsRepository buttonPostRepository = new ButtonsPostsRepository(context);

                ButtonsPosts correctButtonPost = new ButtonsPosts
                {
                    Post = 1,
                    LeftSide = 1,
                    RightSide = 1,
                    LeftColor = "Yellow",
                    RightColor = "Yellow"
                };

                buttonPostRepository.Update(correctButtonPost);
                ButtonsPosts currentButtonPost = context.ButtonsPosts.Find(1);

                Assert.Equal(correctButtonPost.LeftSide, currentButtonPost.LeftSide);
                Assert.Equal(correctButtonPost.RightSide, currentButtonPost.RightSide);
                Assert.Equal(correctButtonPost.LeftColor, currentButtonPost.LeftColor);
                Assert.Equal(correctButtonPost.RightColor, currentButtonPost.RightColor);
            }
        }

        [Fact]
        public void TestGetButtonPostByPost()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.ButtonsPosts.Add(new ButtonsPosts
                {
                    Post = 1,
                    LeftSide = 1,
                    RightSide = 1,
                    LeftColor = "Yellow",
                    RightColor = "Yellow"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                ButtonsPostsRepository buttonPostRepository = new ButtonsPostsRepository(context);
                var bpost = buttonPostRepository.GetByPost(1);

                Assert.Equal(1, bpost.LeftSide);
                Assert.Equal(1, bpost.RightSide);
                Assert.Equal("Yellow", bpost.LeftColor);
                Assert.Equal("Yellow", bpost.RightColor);
            }
        }
    }
}
