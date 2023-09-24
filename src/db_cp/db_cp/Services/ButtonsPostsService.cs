using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Services
{
    public interface IButtonsPostsService
    {
        void Add(ButtonsPosts bpost);
        void Delete(ButtonsPosts bpost);
        void Update(ButtonsPosts bpost);

        IEnumerable<ButtonsPosts> GetAll();
        ButtonsPosts GetByPost(int post);
    }

    public class ButtonsPostsService : IButtonsPostsService
    {
        private readonly IButtonsPostsRepository _buttonsPostsRepository;

        public ButtonsPostsService(IButtonsPostsRepository buttonsPostsRepository)
        {
            _buttonsPostsRepository = buttonsPostsRepository;
        }

        private bool IsExist(ButtonsPosts bpost)
        {
            return _buttonsPostsRepository.GetAll().FirstOrDefault(elem =>
                    elem.Post == bpost.Post) != null;
        }

        private bool IsNotExist(int post)
        {
            return _buttonsPostsRepository.GetByPost(post) == null;
        }

        public void Add(ButtonsPosts bpost)
        {
            if (IsExist(bpost))
                throw new Exception("Post with this number already exists");

            _buttonsPostsRepository.Add(bpost);
        }

        public void Delete(ButtonsPosts bpost)
        {
            if (IsNotExist(bpost.Post))
                throw new Exception("Post with this number does not exist.");

            _buttonsPostsRepository.Delete(bpost.Post);
        }

        public IEnumerable<ButtonsPosts> GetAll()
        {
            return _buttonsPostsRepository.GetAll();
        }

        public void Update(ButtonsPosts bpost)
        {
            if (IsNotExist(bpost.Post))
                throw new Exception("Post with this number does not exist.");

            _buttonsPostsRepository.Update(bpost);
        }

        public ButtonsPosts GetByPost(int post)
        {
            return _buttonsPostsRepository.GetByPost(post);
        }
    }
}
