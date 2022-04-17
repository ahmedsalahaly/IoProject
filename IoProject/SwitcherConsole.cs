using IoProject.ConsoleService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoProject
{
    public static class SwitcherConsole
    {
        public static void FileManager()
        {
            for (; ; )
            {
                Console.WriteLine("what you want to manage\n" +
                      "1.Folders\n" +
                      "2.Close cmd\n");

                int MainAction = Convert.ToInt32(Console.ReadLine());
                if (MainAction == 1)
                {
                    for (; ; )
                    {
                        Console.WriteLine("1.Report folder\n" +
                            "2.Close\n\n");
                        int Action = Convert.ToInt32(Console.ReadLine());
                        switch (Action)
                        {
                             case 1:
                                FolderConsole.FolderStaticsConsole();
                                break;
                        }
                        if (Action == 2)
                        {
                            break;
                        }
                    }
                }
            }

        }
    }
}
