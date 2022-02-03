using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductivityTools.TeamManagement.Api.Controllers;
using ProductivityTools.TeamManagement.Database;
using ProductivityTools.TeamManagement.WebApi.Controllers;
using System;

namespace ProductivityTools.TeamManagement.Api.Test
{
    [TestClass]
    public class UnitTest1
    {
        private IConfiguration _config;
        public IConfiguration Configuration
        {
            get
            {
                if (_config == null)
                {
                    var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
                    _config = builder.Build();
                }

                return _config;
            }
        }

        public ServiceProvider ServiceProvider
        {
            get
            {
                var serviceCollection = new ServiceCollection();
                serviceCollection.AddTransient<TeamManagmentContext>();
                serviceCollection.AddSingleton<IConfiguration>(Configuration);
                var x = serviceCollection.BuildServiceProvider();
                return x;
            }
        }

        [TestMethod]
        public void GetFeedback()
        {
            
            using (var context = ServiceProvider.GetService<TeamManagmentContext>())
            {
                FeedbackController controller = new FeedbackController(context);
                var result = controller.GetFeedback(new System.Collections.Generic.List<string>() { "pw" });
            }

        }

        [TestMethod]
        public void AddPerson()
        {

            using (var context = ServiceProvider.GetService<TeamManagmentContext>())
            {
                PersonController controller = new PersonController(context);
                var result = controller.Add("Pawel", "Wujczyk", "pw1","empty");
                Console.WriteLine(result);
            }
        }
    }
}