﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Process_TaskManager_App
{
    internal class ProcessApp
    {
        public static void RunProgram()
        {
            do
            {

                try
                {

                Started:
                       
                    Console.WriteLine("-------------Welcome------------- ");
                    Console.WriteLine("1 ------List all Processes--------");
                    Console.WriteLine("2 ---------Kill Process-----------");
                    Console.WriteLine("3 --------Start any Task----------");
                    Console.WriteLine("4 -----Creat Custom process-------");
                    Console.WriteLine("5 ------------Exit----------------");
                    Console.Write("Enter Your Choice : ");
                    int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                            Console.Clear();
                                ListProcesses();
                                break;
                            case 2:
                           
                        KillChoice:
                                    Console.Write("Enter Process ID :  ");
                                    int ID = int.Parse(Console.ReadLine());
                                    //check if Kill is done or not 
                                    if (KillProcess(ID))
                                    {
                                        Console.WriteLine("Done");
                                        RunProgram();
                                    }
                                    // if kill not done
                                    else
                                    {

                                        Console.WriteLine("this Process Not Found ");
                                    ProcessNotFound:
                                        Console.WriteLine("1- Enter diffrent ID");
                                        Console.WriteLine("2- back");
                                        Console.Write("Enter Your Chance :");
                                        choice = int.Parse(Console.ReadLine());
                                        switch (choice)
                                        {
                                            case 1:
                                                // back to enter id again
                                                goto KillChoice;

                                            case 2: goto Started;
                                            // back to start again 
                                            default:
                                                Console.WriteLine("please Enter Correct Choice 1 or 2 ");
                                                goto ProcessNotFound;
                                        }
                                    }
                                    break;
                            case 3:
                            Console.Clear();
                            StartAnyTask.StartAnyProcess();
                                break;
                            case 4:
                            Console.Clear();
                            StartAnyTask.StartAnyProcess();
                                break;
                            case 5:
                            
                            Environment.Exit(0);
                                break;

                            default:
                             RunProgram();
                                break;

                        }

                }

                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            } while (true);

        }

        public static void ListProcesses()
        { 
            try {
                //Console.WriteLine(" Process Name\t\tID\t\tCPU Usage");


                var runningProcesses = from proc in Process.GetProcesses()
                                   orderby proc.Id
                                   select proc;
            foreach (var proc in runningProcesses)
            {
                    //string info = $"-> PID: {proc.Id}\tName: {proc.ProcessName}";
                Console.WriteLine($"-> pID:{proc.Id}\tpNAME: {proc.ProcessName}");
                    Console.WriteLine();
            }
            } 
            catch(Exception)
            {
                ListProcesses();
            }
        }

        public static bool KillProcess(int id)
        {

            try
            {
                Process ProcessKilled = Process.GetProcessById(id);

                ProcessKilled.Kill();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
    }
}
