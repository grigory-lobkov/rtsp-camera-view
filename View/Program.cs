using System.Windows.Forms;
using Model;
using Model.Rtsp;
using Presenter.Common;
using Presenter.Presenters;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new LightInjectAdapter())
                .RegisterControl<ISourceListView, SourceListControl>()
                .RegisterControl<IModifySettingsView, ModifySettingsControl>()
                .RegisterControl<IModifySourceView, ModifySourceControl>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<INameViewEditView, NameViewEditForm>()
                .RegisterService<ISettingsService, XmlFileSettingsService>()
                .RegisterService<IRtspService, VlcRtspService>()
                .RegisterInstance(Context);

            controller.Run<MainPresenter>();
        }
    }
}
