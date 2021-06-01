using ProductivityTools.PSCmdlet;
using PSTeamManagement.Cmdlet;
using PSTeamManagment.Cmdlet.Feedback.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagment.Cmdlet.Feedback
{
    [Cmdlet(VerbsCommon.Set, "Feedback")]
    [Description("Set-Feedback saves feedback for chosen people")]
    public class SetFeedback : PSCmdletPT
    {
        public SetFeedback()
        {
            Helpers.Init();
            this.AddCommand(new Set(this));
        }

        [Parameter(Position =0)]
        [Description("Initials splited with space")]
        public string Initials { get; set; }

        [Parameter(Position =1)]
        [Description("Information about the action of the person")]
        public string Value { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
