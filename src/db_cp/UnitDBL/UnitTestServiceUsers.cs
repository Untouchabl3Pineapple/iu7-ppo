using System;
using Xunit;
using db_cp.Interfaces;
using db_cp.Mocks;
using db_cp.Services;
using db_cp.Models;
using System.Collections.Generic;

namespace UnitDBL
{
    public class UnitTestServiceUsers
    {
        [Fact]
        public void TestUserAdd()
        {
            IUsersRepository usersRepository = new UsersMock();
            IUsersService usersService = new UsersService(usersRepository);

            Users correctUser = new Users
            {
                Login = "Keke",
                Password = "228",
                Permission = "user",
                Name = "Ilya",
                Surname = "Artemev",
                MiddleName = "Olegovich"
            };

            usersService.Add(correctUser);

            Users currentUser = usersService.GetByLogin("Keke");

            Assert.Equal(correctUser.Login, currentUser.Login);
            Assert.Equal(correctUser.Password, currentUser.Password);
            Assert.Equal(correctUser.Permission, currentUser.Permission);
            Assert.Equal(correctUser.Name, currentUser.Name);
            Assert.Equal(correctUser.Surname, currentUser.Surname);
            Assert.Equal(correctUser.MiddleName, currentUser.MiddleName);
        }

        [Fact]
        public void TestUserUpdate()
        {
            IUsersRepository usersRepository = new UsersMock();
            IUsersService usersService = new UsersService(usersRepository);

            Users correctUser = new Users
            {
                Login = "PoroSad",
                Password = "555",
                Permission = "user",
                Name = "Ilya",
                Surname = "Artemev",
                MiddleName = "Olegovich"
            };

            usersService.Update(correctUser);

            Users currentUser = usersService.GetByLogin("PoroSad");

            Assert.Equal(correctUser.Login, currentUser.Login);
            Assert.Equal(correctUser.Password, currentUser.Password);
            Assert.Equal(correctUser.Permission, currentUser.Permission);
            Assert.Equal(correctUser.Name, currentUser.Name);
            Assert.Equal(correctUser.Surname, currentUser.Surname);
            Assert.Equal(correctUser.MiddleName, currentUser.MiddleName);
        }

        [Fact]
        public void TestGetUserByLogin()
        {
            IUsersRepository usersRepository = new UsersMock();
            IUsersService usersService = new UsersService(usersRepository);

            Users correctUser = new Users
            {
                Login = "PoroSad",
                Password = "228",
                Permission = "user",
                Name = "Ilya",
                Surname = "Artemev",
                MiddleName = "Olegovich"
            };

            Users currentUser = usersService.GetByLogin("PoroSad");

            Assert.Equal(correctUser.Login, currentUser.Login);
            Assert.Equal(correctUser.Password, currentUser.Password);
            Assert.Equal(correctUser.Permission, currentUser.Permission);
            Assert.Equal(correctUser.Name, currentUser.Name);
            Assert.Equal(correctUser.Surname, currentUser.Surname);
            Assert.Equal(correctUser.MiddleName, currentUser.MiddleName);
        }
    }
}
