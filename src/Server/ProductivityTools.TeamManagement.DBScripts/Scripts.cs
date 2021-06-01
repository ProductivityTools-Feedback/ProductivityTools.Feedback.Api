using DBUpPT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.DBScripts
{
    public class Scripts
    {
        public void PerformDatabaseUpdate()
        {
            string serverName = "PTTeamManagement";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["ServerName"];
            string dbName = "./SQL2019";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["DatabaseName"];
            DBUp dBUp = new DBUp("tm");
            Assembly assembly = Assembly.GetExecutingAssembly();
            dBUp.PerformUpdate(serverName, dbName, assembly, false);
        }
    }
}
