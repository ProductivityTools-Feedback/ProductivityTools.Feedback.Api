using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSTeamManagement.WindowsService;

namespace PSTeamManagement.WindowsServiceRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            PSTeamManagement.WindowsService.PSTeamManagement f = new PSTeamManagement.WindowsService.PSTeamManagement();
            f.OnDebug();
            Console.WriteLine("Host opened");
            Console.ReadKey();
        }
    }
}
