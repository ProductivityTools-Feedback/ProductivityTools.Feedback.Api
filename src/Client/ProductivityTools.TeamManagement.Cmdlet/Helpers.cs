using ProductivityTools.MasterConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSTeamManagement.Cmdlet
{
    public static class Helpers
    {
        public static List<string> SplitToList(this string input)
        {
            if (string.IsNullOrEmpty(input)) return new List<string>();
            var x = input.Split(' ').ToList();
            return x;
        }

        public static bool AnyPersonInitial(this string input)
        {
            var x = input.SplitToList().Any();
            return x;
        }

        public static void Init()
        {
            MConfiguration.SetConfigurationName("Configuration.config");
        }
    }
}
