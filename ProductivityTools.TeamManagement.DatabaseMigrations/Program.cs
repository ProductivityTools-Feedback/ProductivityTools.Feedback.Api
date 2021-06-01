using DbUp;
using System;
using System.Reflection;

namespace ProductivityTools.TeamManagement.DatabaseMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string serverName = ".\\SQL2019";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["ServerName"];
            string dbName = "PTTeamManagement";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["DatabaseName"];
            DBUp dBUp = new DBUp("tm");
            Assembly assembly = Assembly.GetExecutingAssembly();
            dBUp.PerformUpdate(serverName, dbName, assembly, false);
        }
    }
}
