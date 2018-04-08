namespace Presenter.Common
{
    public interface IPresenterControl
    {
        void Get();
        IViewControl Control { get; }
    }

    public interface IPresenterControl<in TArg>
    {
        void Get(TArg argument);
        IViewControl Control { get; }
    }
}