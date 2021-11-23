using Erp.Prototype;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dash.DemoApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Debug()
                      .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
                      .Enrich.FromLogContext()
                      .WriteTo.File(@".\\log\\log.txt", rollingInterval: RollingInterval.Day)
                      .WriteTo.Console()
                      //.WriteTo.Debug()
                      .CreateLogger();

            Log.Information("Starting: {0}", Application.ProductName);
            Log.Information(".NET Version: {0}", Environment.Version.ToString());

            try
            {
                var configuration = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json")
                   .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
                   .Build();


                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.Run(new PrototypeForm(configuration));
                Log.Information("End of: {0}", Application.ProductName);
                Log.Information("***************************************************  -- END --  ****************************************************************");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "There was a problem!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
