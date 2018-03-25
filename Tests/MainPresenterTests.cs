using System;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Presenters;
using Presenter.Views;
using NSubstitute;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class MainPresenterTests
    {
        private IApplicationController _controller;
        private IMainView _view;
        
        [SetUp]
        public void SetUp()
        {
            _controller = Substitute.For<IApplicationController>();
            _view = Substitute.For<IMainView>();
            var service = Substitute.For<IRtspService>();
            service.Login(Arg.Any<User>())
                .Returns(info => info.Arg<User>().Name == "admin" && info.Arg<User>().Password == "password");
            var presenter = new MainPresenter(_controller, _view, service);
            presenter.Run();
        }
        
        [Test]
        public void InvalidUser()
        {
            _view.Username.Returns("Vladimir");
            _view.Password.Returns("VladimirPass");
            _view.Login += Raise.Event<Action>();
            _view.Received().ShowError(Arg.Any<string>());
            _controller.DidNotReceive().Run<NameViewEditPresener, User>(Arg.Any<User>());
        }

        [Test]
        public void ValidUser()
        {
            _view.Username.Returns("admin");
            _view.Password.Returns("password");
            _view.Login += Raise.Event<Action>();
            _view.DidNotReceive().ShowError(Arg.Any<string>());
            _controller.Received().Run<NameViewEditPresener, User>(Arg.Is<User>(user => user.Name == "admin" && user.Password == "password"));
        }
    }
}