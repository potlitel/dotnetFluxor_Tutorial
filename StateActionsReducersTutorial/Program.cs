﻿//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

namespace StateActionsReducersTutorial
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<App>();
            services.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly));

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetRequiredService<App>();
            app.Run();
        }
    }
}