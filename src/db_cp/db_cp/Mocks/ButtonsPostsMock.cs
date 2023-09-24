using System;
using db_cp.Models;
using db_cp.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace db_cp.Mocks
{
    public class ButtonsPostsMock : DataMock, IButtonsPostsRepository
    {
        public void Add(ButtonsPosts model)
        {
            _buttonsPosts.Add(model);
        }

        public void Delete(int post)
        {
            ButtonsPosts buttonPost = _buttonsPosts[post - 1];
            _buttonsPosts.Remove(buttonPost);
        }

        public void Update(ButtonsPosts model)
        {
            ButtonsPosts buttonPost = _buttonsPosts[model.Post - 1];

            buttonPost.LeftSide = model.LeftSide;
            buttonPost.RightSide = model.RightSide;
            buttonPost.LeftColor = model.LeftColor;
            buttonPost.RightColor = model.RightColor;

            _buttonsPosts[buttonPost.Post - 1] = buttonPost;
        }

        public IEnumerable<ButtonsPosts> GetAll()
        {
            return _buttonsPosts;
        }

        public ButtonsPosts GetByPost(int post)
        {
            return _buttonsPosts[post - 1];
        }
    }
}
