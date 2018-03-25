using System.Windows.Forms;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Presenters;
using Presenter.Views;
using View;

namespace UI
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();

        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterView<IMainView, MainForm>()
                .RegisterView<INameViewEditView, NameViewEditForm>()
                .RegisterView<IAboutView, AboutForm>()
                .RegisterService<IRtspService, VlcRtspService>()
                .RegisterInstance(new ApplicationContext());

            controller.Run<MainPresenter>();
        }
    }
}
