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
    [Cmdlet(VerbsCommon.Get, "Feedback")]
    [Description("Get-Feedback returns information about saved feedbacks for people")]
    public class GetFeedback : PSCmdletPT
    {
        public GetFeedback()
        {
            Helpers.Init();
            this.AddCommand(new Get(this));
        }

        [Parameter(Position =0)]
        [Description("Initials splited with space")]
        public string Initials { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessCommands();
            base.ProcessRecord();
        }
    }
}
