using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Process_TaskManager_App
{
    internal class StartAnyTask
    {
        public static Process? _Process = null;
        public static void StartAnyProcess()
        {
            try
            {
     
                Console.WriteLine("Enter file name to open");
                string output = Console.ReadLine() ?? string.Empty;
                ProcessStartInfo processStart = new ProcessStartInfo($@"{output.Trim()}");
                processStart.UseShellExecute = true;
                //processStart.RedirectStandardOutput = true;
                processStart.WindowStyle = ProcessWindowStyle.Hidden;
                processStart.RedirectStandardError = true;
                _Process = Process.Start(processStart);

            } catch (Exception )
            {
                StartAnyProcess();
            }
        }
    }
}
