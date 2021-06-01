using ProductivityTools.PSCmdlet;
using PSTeamFeedback.Contract.Internal;
using PSTeamManagement.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.InternalInformation.Commands
{
    public abstract class InternalBaseCommand<Type> : PSBaseCommandPT<Type>
    {
        protected IInternal Client
        {
            get
            {
                string address = ProductivityTools.MasterConfiguration.MConfiguration.Configuration["Address"];
                NetTcpBinding netTcpBinding = new NetTcpBinding();
                netTcpBinding.CloseTimeout = TimeSpan.FromMinutes(20);
                ChannelFactory<IInternal> factory = new ChannelFactory<IInternal>(netTcpBinding, new EndpointAddress(address));

                IInternal proxy = factory.CreateChannel();

                return proxy;
            }
        }

        protected void CloseClient()
        {
            (this.Client as ICommunicationObject).Close();
        }

        public InternalBaseCommand(Type cmdlet) : base(cmdlet) { }
    }
}
