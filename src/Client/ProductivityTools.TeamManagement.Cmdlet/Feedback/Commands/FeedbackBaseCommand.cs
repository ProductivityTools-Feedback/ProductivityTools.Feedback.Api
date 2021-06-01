using ProductivityTools.PSCmdlet;
using PSTeamFeedback.Contract.Internal;
using PSTeamManagement.Cmdlet;
using PSTeamManagement.Contract;
using PSTeamManagement.Contract.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.Feedback.Commands
{
    public abstract class FeedbackBaseCommand<Type> : PSBaseCommandPT<Type>
    {
        protected IFeedback Client
        {
            get
            {
                string address = ProductivityTools.MasterConfiguration.MConfiguration.Configuration["Address"];
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
