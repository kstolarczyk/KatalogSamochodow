using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Stolarczyk.Katalog.UI
{
    using System.IO;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Stolarczyk.Katalog.INTERFACES;
    using Stolarczyk.Katalog.UI.DataAccess;
    using Stolarczyk.Katalog.UI.Services;
    using Stolarczyk.Katalog.UI.ViewModel;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; private set; }
        public IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
 
            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
 
            ServiceProvider = serviceCollection.BuildServiceProvider();
 
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(ServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<MainWindow>();
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));
            serviceCollection.AddScoped<IDataLoader, DataLoader>();
            serviceCollection.AddScoped<IFormWindowService, FormWindowService>();
        }
    }
}
