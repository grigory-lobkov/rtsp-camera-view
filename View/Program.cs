using System.Windows.Forms;
using Model;
using Presenter.Views;
using View;
using View.Components;

namespace UI
{
    internal static class Program
    {
        public static readonly ApplicationContext Context = new ApplicationContext();
        [System.STAThread]
        private static void Main()
        {
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-CA");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new Presenter.Common.ApplicationController(new LightInjectAdapter())
                .RegisterControl<ISourceListView, SourceListControl>()
                .RegisterControl<IModifySettingsView, ModifySettingsControl>()
                .RegisterControl<IModifySourceView, ModifySourceControl>()
                .RegisterControl<ISourceGridView, SourceGridControl>()
                .RegisterControl<ISourceView, SourceControl>()
                .RegisterControl<IPlayerControlView, PlayerControlControl>()
                .RegisterControl<IPlayerView, ViewVlc215.Player>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<INameViewSetupView, NameViewSetupForm>()
                .RegisterView<IAlertSetupView, AlertSetupForm>()
                .RegisterView<IMatrixSetupView, MatrixSetupForm>()
                .RegisterService<ISettingsService, XmlFileSettingsService>()
                .RegisterService<IEmailAlertService, TextEmailAlertService>()
                .RegisterInstance(Context);

            controller.Run<Presenter.Presenters.MainPresenter>();
        }
    }
}
