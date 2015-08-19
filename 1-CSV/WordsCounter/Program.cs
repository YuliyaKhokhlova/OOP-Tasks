using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WordsCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                (new Program(args)).Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured:" + e.Message);
            }
        }

        public Program(string[] args)
        {
            if (args.Length < 1)
            {
                return;
            }

            inputFile = args[0];
            outputFile = inputFile.Replace(Path.GetExtension(inputFile), ".csv");
        }

        private string inputFile = string.Empty;
        private string outputFile = string.Empty;
        private Dictionary<string, int> words = new Dictionary<string, int>();

        public void Run()
        {
            if (string.IsNullOrEmpty(inputFile))
            {
                Console.WriteLine("Please, specify file name");
                return;
            }

            ReadWords();
        }

        private void ReadWords()
        {
            StreamReader sr = new StreamReader(inputFile);
            StringBuilder sb = new StringBuilder();

            string line;
            while (null != (line = sr.ReadLine()))
            {
                bool word = false;
                sb.Clear();
                foreach (char sym in line)
                {
                    if (char.IsLetterOrDigit(sym))
                    {
                        word = true;
                        sb.Append(sym);
                        continue;
                    }

                    if (!word)
                    {
                        continue;
                    }

                    string currentWord = sb.ToString();
                    sb.Clear();
                    word = false;
                    if (!words.ContainsKey(currentWord))
                    {
                        words[currentWord] = 0;
                    }
                    words[currentWord]++;
                }

                if (word)
                {
                    string currentWord = sb.ToString();
                    sb.Clear();
                    if (!words.ContainsKey(currentWord))
                    {
                        words[currentWord] = 0;
                    }
                    words[currentWord]++;
                }
            }
        }

        private void WriteCSV()
        {
            StringBuilder sb = new StringBuilder();
            
        }
    }
}
