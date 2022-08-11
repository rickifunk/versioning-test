using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.UpdaterStuff
{
    internal class Updater
    {
        const string UPDATER_EXE_PATH = @"C:\Users\Ricki\source\repos\SelfUpdatingWPF\Updater\bin\Debug\net6.0\Updater.exe";

        public static void Run()
        {
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = UPDATER_EXE_PATH,
                Arguments = $"-p {Process.GetCurrentProcess().ProcessName}"
            };

            Process.Start(psi);
        }
    }
}
