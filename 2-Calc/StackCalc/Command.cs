using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalc
{
    abstract class Command
    {
        public string _name;
        abstract public string GetMsg();
        public void Run()
        {
            Console.WriteLine(GetMsg());
        }
    }

    class PushCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm PUSH";
        }
    }

    class PopCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm POP";
        }
    }

    class DefineCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm DEFINE";
        }
    }

    class PrintCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm PRINT";
        }
    }

    class SqrtCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm SQRT";
        }
    }

    class PlusCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm +";
        }
    }

    class MinusCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm -";
        }
    }

    class DivCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm /";
        }
    }

    class MultCommand : Command
    {
        public override string GetMsg()
        {
            return "I'm *";
        }
    }

    class CommandFactory
    {
        private string _configFile;
        public string ConfigFile
        {
            get
            {
                return _configFile;
            }
            set
            {
                _configFile = value;
                Init();
            }
        }

        private Dictionary<string, string> _commandsClasses;
        private void Init()
        {
            _commandsClasses = new Dictionary<string, string>();
            if (!File.Exists(_configFile))
            {
                return;
            }

            StreamReader sr = new StreamReader(_configFile);
            string line;
            while (null != (line = sr.ReadLine()))
            {
                line = line.Trim();
                if (line.StartsWith("#"))
                {
                    continue;
                }

                string[] lineEntries = line.Split(' ');
                if (lineEntries.Length < 2)
                {
                    continue;
                }

                _commandsClasses[lineEntries[0]] = lineEntries[1];
            }
        }

        public CommandFactory(string configFile)
        {
            _configFile = configFile;
            Init();
        }

        public Command CreateCommand(string cmdName)
        {
            try
            {
                Type cmdType = Type.GetType(_commandsClasses[cmdName]);
                Object newCmd = Activator.CreateInstance(cmdType);
                return (newCmd as Command);
            }
            catch (Exception)
            {
            }
            return null;
        }
    }
}
