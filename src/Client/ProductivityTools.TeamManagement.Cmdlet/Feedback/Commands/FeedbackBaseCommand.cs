using ProductivityTools.PSCmdlet;
using ProductivityTools.TeamManagement.Contract.Feedback;
using PSTeamFeedback.Contract.Internal;
using PSTeamManagement.Cmdlet;
using ProductivityTools.TeamManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.Feedback.Commands
{
    public abstract class FeedbackBaseCommand<Type> : PSCommandPT<Type> where Type : PSCmdletPT
    {
        protected IFeedback Client
        {
            get
            {
                string address = "";// ProductivityTools.MasterConfiguration.MConfiguration.Configuration["Address"];
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                netTcpBinding.CloseTimeout = TimeSpan.FromMinutes(20);
                ChannelFactory<IFeedback> factory = new ChannelFactory<IFeedback>(netTcpBinding, new EndpointAddress(address));

                IFeedback proxy = factory.CreateChannel();

                return proxy;
            }
        }

        protected void CloseClient()
        {
            (this.Client as ICommunicationObject).Close();
        }


        public FeedbackBaseCommand(Type cmdlet) : base(cmdlet) { }
    }
}
