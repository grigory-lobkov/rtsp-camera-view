using System;
using Model;
using Presenter.Common;
using Presenter.Presenters;
using Presenter.Views;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class NameViewEditPresenterTests
    {
        private IApplicationController _controller;
        private NameViewEditPresener _presenter;
        private INameViewEditView _view;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _user = new User { Name = "admin", Password = "password" };
            _view = Substitute.For<INameViewEditView>();
            _presenter = new NameViewEditPresener(_controller, _view);
            _presenter.Run(_user);
        }
        
        [Test]
        public void ViewInit()
        {
            _view.Received().SetUserInfo("admin", "********");
        }
        
        [Test]
        public void ChangeUsername()
        {
            _view.ChangeUsername += Raise.Event<Action>();
            _controller.Received().Run<AboutPresenter, User>(_user);
        }
    }
}