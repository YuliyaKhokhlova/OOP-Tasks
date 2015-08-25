using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFile = @"C:\work\OOP-Tasks\2-Calc\factory.config";

            CommandFactory cmdFactory = new CommandFactory(configFile);
            string[] cmds = { "PUSH", "+", "PRINT", "DEFINE", "/", "POP", "SQRT", "*", "-" };
            foreach(string cmdName in cmds)
            {
                Command cmd = cmdFactory.CreateCommand(cmdName);
                cmd.Run();
            }

        }
    }
}
