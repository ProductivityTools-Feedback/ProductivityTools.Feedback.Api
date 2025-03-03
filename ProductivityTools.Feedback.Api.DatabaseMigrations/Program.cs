using DbUp;
using System;
using System.Reflection;

namespace ProductivityTools.Feedback.DatabaseMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverName = ".\\SQL2022";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["ServerName"];
            string dbName = "PTFeedback";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["DatabaseName"];
            DBUp dBUp = new DBUp("tm");
            Assembly assembly = Assembly.GetExecutingAssembly();
            dBUp.PerformUpdate(serverName, dbName, assembly, false, true);
        }
    }
}
