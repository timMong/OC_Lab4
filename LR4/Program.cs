using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
namespace LR4
{
    class Program
    {
        //static int SIZE;    \\  КАК СДЕЛАТЬ ЭТО ДИНАМИЧЕСКИ???
        static string PATH = "C:\\Windows\\system32\\mspaint.exe";
        //static List<Process> ARR_OF_PROCESS = new List<Process>();
        public const int SIZE = 2;
        static Process[] ARR_OF_PROCESS = new Process[SIZE];
        //  static Dictionary<Process, Thread> x = new Dictionary<Process, Thread>(); //КАК СДЕЛАТЬ МАССИВ ПРОЦЕССОВ С ПОТОКАМИ

        static public void SetPriority()
        {
            int choice;
            for (int i = 0; i < SIZE; i++)
            {
                ARR_OF_PROCESS[i] = new Process();
                ARR_OF_PROCESS[i].StartInfo.FileName = PATH;
                ARR_OF_PROCESS[i].Start();
                do
                {
                    Console.WriteLine($"Какой уровань приоритета выставить {i + 1} процессу ?");
                    Console.WriteLine("1    |   2   |   3   |   4");
                    choice = Convert.ToInt32(Console.ReadLine());
                } while (choice != 1 && choice != 2 && choice != 3 && choice != 4);
                switch (choice)
                {
                    case 1:
                        ARR_OF_PROCESS[i].PriorityClass = ProcessPriorityClass.Idle;
                        break;
                    case 2:
                        ARR_OF_PROCESS[i].PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 3:
                        ARR_OF_PROCESS[i].PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 4:
                        ARR_OF_PROCESS[i].PriorityClass = ProcessPriorityClass.RealTime;
                        break;
                    default:
                        Console.WriteLine("! ОШИБКА ВВОДА !");
                        break;
                }
            }
            for (int i = 0; i < SIZE; i++)
                Console.WriteLine($"Приоритет {i + 1} процесса: " + ARR_OF_PROCESS[i].PriorityClass);
        }
        static public void ChangePriority()
        {
            int choice2, choice3;
            bool check = false;
            do
            {
                Console.WriteLine("Приоритет какого процесса Вы хотите изменить?");
                choice2 = Convert.ToInt32(Console.ReadLine());
                if (choice2 > SIZE || choice2 <= 0)
                    Console.WriteLine("! ОШИБКА ВВОДА - OUT OF RANGE !");
                else check = true;
            } while (check != true);
            do
            {
                Console.WriteLine($"Какой уровань приоритета выставить {choice2} процессу ?");
                Console.WriteLine("1    |   2   |   3   |   4");
                choice3 = Convert.ToInt32(Console.ReadLine());
            } while (choice3 != 1 && choice3 != 2 && choice3 != 3 && choice3 != 4);
            switch (choice3)
                {
                    case 1:
                        ARR_OF_PROCESS[choice2 - 1].PriorityClass =ProcessPriorityClass.Idle;
                        break;
                    case 2:
                        ARR_OF_PROCESS[choice2 - 1].PriorityClass = ProcessPriorityClass.Normal;
                        break;
                    case 3:
                        ARR_OF_PROCESS[choice2 - 1].PriorityClass = ProcessPriorityClass.High;
                        break;
                    case 4:
                        ARR_OF_PROCESS[choice2 - 1].PriorityClass = ProcessPriorityClass.RealTime;
                        break;
                    default:
                        Console.WriteLine("! ОШИБКА ВВОДА !");
                        break;
                }
            for (int i = 0; i < SIZE; i++)
                Console.WriteLine($"Приоритет {i + 1} процесса: " + ARR_OF_PROCESS[i].PriorityClass);
        }
        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("В НАЛИЧИИ ДВА ПРОЦЕССА\n");
            do
            {
                Console.WriteLine("==МЕНЮ КОМАНД============================");
                Console.WriteLine("=Вызов задачу и даем ей приоритет -  1  =");
                Console.WriteLine("=Изменить приоритет -                2  =");
                Console.WriteLine("=Закончить -                         0  =");
                Console.WriteLine("=========================================");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        SetPriority();
                        break;
                    case 2:
                        ChangePriority();
                        break;
                    default:
                        Console.WriteLine("! ОШИБКА ВВОДА !");
                        break;
                }
            } while (choice != 0);
            return;
        }
    }
}
