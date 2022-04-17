using IoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoProject.ConsoleService
{
    public static class FolderConsole
    {
        public static void FolderStaticsConsole()
        {
            Console.WriteLine("Insert folder path");
            string FolderPath = Console.ReadLine();
            string Massage;
            List<string> statics = FolderService.FolderReport(FolderPath, out Massage);
            if (string.IsNullOrEmpty(Massage))
                for (int i = 0; i < statics.Count; i++)
                {
                    Console.WriteLine(@"{0} {1}", (i + 1), statics[i]);
                }
            else
            {
                Console.WriteLine(Massage);
            }
        }
    }   
}
