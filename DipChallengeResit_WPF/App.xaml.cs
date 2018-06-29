using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DipChallengeResit_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => UnhandledExceptionEventHandler(sender, args);
            base.OnStartup(e);
        }

        private void UnhandledExceptionEventHandler(object sender,  UnhandledExceptionEventArgs args)
        {
            Exception e = args.ExceptionObject as Exception;
            logger.Fatal($"Unhandled Exception thrown: {e.Message}");
        }
    }
}
