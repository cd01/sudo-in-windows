using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

[assembly: AssemblyVersion("0.0.1.*")]
[assembly: AssemblyCopyright("Copyright cd01 2014")]
[assembly: AssemblyDescription("Elevate UAC")]
class sudo
{
    static void Main(string[] args)
    {
        if (args.Count() == 0)
        {
            Console.WriteLine("Usage:");
            Console.WriteLine("    sudo [command] ...");
            Environment.Exit(0);
        }

        var startInfo = new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = args[0],
                            UseShellExecute = true,
                            Verb = "runas",
                            Arguments = new Func<IEnumerable<string>, string>((argsInShell) =>
                                        {
                                            return string.Join(" ", argsInShell);
                                        })(args.Skip(1))
                        };

        var proc = System.Diagnostics.Process.Start(startInfo);
        proc.WaitForExit();
    }
}

