using CommandLine;
using System.Diagnostics;

const string OUTPUT_PATH = @"C:\Users\Ricki\source\repos\versioning-test\Application\bin\Debug\net6.0-windows";

Parser.Default.ParseArguments<Options>(args)
    .WithParsed<Options>(o =>
    {
        Process target = Process.GetProcessesByName(o.Parent).FirstOrDefault();
        target.Kill();

        string hash = Guid.NewGuid().ToString();
        File.WriteAllText("version.txt", hash);

        bool updated = false;
        while(!updated)
        {
            try
            {
                File.Copy("version.txt", Path.Combine(OUTPUT_PATH, "version.txt"), true);
            }
            catch (global::System.Exception)
            {
                global::System.Console.WriteLine("Failed to copy, retrying");
                Thread.Sleep(2000);
            }

            updated = true;
        }
        

        ProcessStartInfo psi = new()
        {
            FileName = $"{Path.Combine(OUTPUT_PATH, "WPF.exe")}"
        };
        Process.Start(psi);
    });

public class Options
{
    [Option('p', "parent", Required = true, HelpText = "Name of the parent process that started this process")]
    public string Parent { get; set; }
}