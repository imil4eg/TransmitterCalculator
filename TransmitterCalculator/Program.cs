using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace TransmitterCalculator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection.ResolveDependeciesAndBuild();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mainForm = serviceProvider.GetService<MainForm>();
            Application.Run(mainForm);
        }
    }
}
