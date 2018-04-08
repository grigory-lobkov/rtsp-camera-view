namespace Presenter.Common
{
    public abstract class BasePresenterControl<TView> : IPresenterControl
        where TView : IViewControl
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresenterControl(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public IViewControl Control { get { return View; } }

        public void Get() { }
    }

    public abstract class BasePresenterControl<TView, TArg> : IPresenterControl<TArg>
        where TView : IViewControl
    {
        protected TView View { get; private set; }
        protected IApplicationController Controller { get; private set; }

        protected BasePresenterControl(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public IViewControl Control { get { return View; } }

        public abstract void Get(TArg argument);
    }
}