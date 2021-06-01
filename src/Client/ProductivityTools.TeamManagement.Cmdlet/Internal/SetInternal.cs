using ProductivityTools.PSCmdlet;
using PSTeamManagement.Cmdlet;
using PSTeamManagment.Cmdlet.InternalInformation.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.InternalInformation
{
    [Cmdlet(VerbsCommon.Set, "Internal")]
    [Description("Get-Internal saves internal (which shouldn't be shared) information about chosen people")]
    public class SetInternal : PSCmdletPT
    {
        public SetInternal()
        {
            Helpers.Init();
            this.AddCommand(new Set(this));
        }

        [Parameter(Position =0)]
        [Description("Initials splited with space")]
        public string Initials { get; set; }

        [Parameter(Position =1)]
        [Description("Value of the internal information about the person")]
        public string Value { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
