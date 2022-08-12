using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WPF.UpdaterStuff
{
    internal class Updater
    {
        public static void Run()
        {
            if (IsUpdated()) return;

            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = $"{Path.Combine(Directory.GetCurrentDirectory(), "Updater.exe")}",
                Arguments = $"-p {Process.GetCurrentProcess().ProcessName}"
            };

            Process.Start(psi);
        }


        public static bool IsUpdated()
        {
            HttpClient c = new HttpClient();
            Task<HttpResponseMessage> t = c.GetAsync("http://85.218.136.241:5555/version");

            t.Result.EnsureSuccessStatusCode();

            var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;
            string newVersion = t.Result.Content.ReadAsStringAsync().Result;

            return newVersion.Equals($"{currentVersion.Major}.{currentVersion.Minor}.{currentVersion.Build}");
        }
    }
}
