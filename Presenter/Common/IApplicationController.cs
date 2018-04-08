namespace Presenter.Common
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        IApplicationController RegisterControl<TViewControl, TImplementation>()
            where TImplementation : class, TViewControl
            where TViewControl : IViewControl;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;

        TPresenter Get<TPresenter>()
            where TPresenter : class, IPresenterControl;
        TPresenter Get<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenterControl<TArgumnent>;
    }
}