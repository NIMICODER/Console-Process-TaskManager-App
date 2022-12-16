using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Process_TaskManager_App
{
    internal class TaskManager
    {
       
        public static void StartAnyTask()
        {
              Process? _Process = null;
            StartAnyTask:
            try
            {
     
                Console.WriteLine("Enter file name to open");
                var output = Console.ReadLine();
                _Process = Process.Start($@"{output}");

            } catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                goto StartAnyTask;
            }

        }

        public static void KillAnyTask()
        {
            Console.WriteLine("Enter Task Name");
            var input = Console.ReadLine();

            foreach (var proc in Process.GetProcessesByName(input))
            {
                proc.Kill(true);
            }
        }
    }
}
