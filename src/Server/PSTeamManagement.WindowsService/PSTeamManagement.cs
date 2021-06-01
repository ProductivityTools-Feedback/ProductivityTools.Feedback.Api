using ProductivityTools.MasterConfiguration;
using PSTeamFeedback.Contract.Internal;
using PSTeamFeedback.Contract.WorkTime;
using PSTeamManagement.Contract;
using PSTeamManagement.Contract.Feedback;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.WindowsService
{
    public partial class PSTeamManagement : ServiceBase
    {
        ServiceHost host;
        public PSTeamManagement()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            StartServer();
        }

        protected override void OnStop()
        {
            StopServer();
        }

        public void OnDebug()
        {
            this.OnStart(null);
        }

        private void UpdateDatabase()
        {
            DBScripts.Scripts s = new DBScripts.Scripts();
            s.PerformDatabaseUpdate();
        }

        private void StartServer()
        {
            MConfiguration.SetConfigurationName("Configuration.config");
            UpdateDatabase();

            var binding = new NetTcpBinding();
            var address = MConfiguration.Configuration["Address"];

            host = new ServiceHost(typeof(WCFService.TeamManagement));
            host.AddServiceEndpoint(typeof(IWorkTime), binding, address);
            host.AddServiceEndpoint(typeof(IFeedback), binding, address);
            host.AddServiceEndpoint(typeof(IInternal), binding, address);

            host.Open();
        }

        private void StopServer()
        {
            host.Close();
        }
    }
}
