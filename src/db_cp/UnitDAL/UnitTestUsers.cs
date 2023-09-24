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
    public class UnitTestUsers
    {
        [Fact]
        public void TestUserAdd()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {

                UsersRepository userRepository = new UsersRepository(context);

                Users correctUser = new Users
                {
                    Login = "Keke",
                    Password = "228",
                    Permission = "user",
                    Name = "Ilya",
                    Surname = "Artemev",
                    MiddleName = "Olegovich"
                };

                userRepository.Add(correctUser);
                Users currentUser = context.Users.Find("Keke");

                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
                Assert.Equal(correctUser.Name, currentUser.Name);
                Assert.Equal(correctUser.Surname, currentUser.Surname);
                Assert.Equal(correctUser.MiddleName, currentUser.MiddleName);
            }
        }

        [Fact]
        public void TestUserUpdate()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Users.Add(new Users
                {
                    Login = "Keke",
                    Password = "228",
                    Permission = "user",
                    Name = "Ilya",
                    Surname = "Artemev",
                    MiddleName = "Olegovich"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {
                UsersRepository userRepository = new UsersRepository(context);

                Users correctUser = new Users
                {
                    Login = "Keke",
                    Password = "228",
                    Permission = "user",
                    Name = "Olesha",
                    Surname = "Artemev",
                    MiddleName = "Olegovich"
                };

                userRepository.Update(correctUser);
                Users currentUser = context.Users.Find("Keke");

                Assert.Equal(correctUser.Login, currentUser.Login);
                Assert.Equal(correctUser.Password, currentUser.Password);
                Assert.Equal(correctUser.Permission, currentUser.Permission);
                Assert.Equal(correctUser.Name, currentUser.Name);
                Assert.Equal(correctUser.Surname, currentUser.Surname);
                Assert.Equal(correctUser.MiddleName, currentUser.MiddleName);
            }
        }

        [Fact]
        public void TestGetUserByLogin()
        {
            var myDatabaseName = "mydatabase_" + DateTime.Now.ToFileTimeUtc();

            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: myDatabaseName)
                .Options;

            using (var context = new AppDBContext(options))
            {
                context.Users.Add(new Users
                {
                    Login = "Keke",
                    Password = "228",
                    Permission = "user",
                    Name = "Ilya",
                    Surname = "Artemev",
                    MiddleName = "Olegovich"
                });

                context.SaveChanges();
            }

            using (var context = new AppDBContext(options))
            {

                UsersRepository userRepository = new UsersRepository(context);
                var user = userRepository.GetByLogin("Keke");

                Assert.Equal("Keke", user.Login);
                Assert.Equal("228", user.Password);
                Assert.Equal("user", user.Permission);
                Assert.Equal("Ilya", user.Name);
                Assert.Equal("Artemev", user.Surname);
                Assert.Equal("Olegovich", user.MiddleName);
            }
        }
    }
}
