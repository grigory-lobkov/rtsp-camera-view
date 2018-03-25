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
    public class AboutPresenterTests
    {
        private IApplicationController _controller;
        private IAboutView _view;
        private User _user;

        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _user = new User { Name = "admin", Password = "password" };
            _view = Substitute.For<IAboutView>();
            var presenter = new AboutPresenter(_controller, _view);
            presenter.Run(_user);
        }
        
        [Test]
        public void InvalidUsername()
        {
            _view.Username.Returns("");
            _view.Save += Raise.Event<Action>();
            Assert.AreEqual(_user.Name, "admin");
            _view.DidNotReceive().Close();
        }

        [Test]
        public void ValidUsername()
        {
            _view.Username.Returns("username");
            _view.Save += Raise.Event<Action>();
            Assert.AreEqual(_user.Name, "username");
            _view.Received().Close();
        }
    }
}