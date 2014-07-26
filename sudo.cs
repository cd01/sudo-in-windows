using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sudo
{
    class Program
    {
        static void Main(string[] args)
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = args[0]; 
            startInfo.UseShellExecute = true;
            startInfo.Verb = "runas";
            startInfo.Arguments = new Func<IEnumerable<string>, string>((argsInShell) => {
                                      return string.Join(" ", argsInShell); 
                                  })(args.Skip(1)); 
 
            try 
            { 
                var proc = System.Diagnostics.Process.Start(startInfo);
                proc.WaitForExit();
            } 
            catch(Exception ex) 
            { 
                Console.Error.WriteLine(ex.Message); 
            } 
        }
    }
}
