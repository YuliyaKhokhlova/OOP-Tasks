using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

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
            WriteCSV();
        }

        private void ReadWords()
        {
            StreamReader sr = new StreamReader(inputFile);
            StringBuilder sb = new StringBuilder();

            string line;
            while (null != (line = sr.ReadLine()))
            {
                line = line.ToLower();
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

                    AddWord(sb.ToString());
                    sb.Clear();
                    word = false;
                }

                if (word)
                {
                    AddWord(sb.ToString());
                    sb.Clear();
                }
            }
        }

        private void WriteCSV()
        {
            StringBuilder sb = new StringBuilder();
            StreamWriter sw = new StreamWriter(outputFile);

            int totalWordsCount = (from wd in words.Keys select words[wd]).Sum();
            foreach (KeyValuePair<string, int> kvp in words.OrderByDescending(pair => pair.Value))
            {
                string currentWord = kvp.Key;
                int currentFreq = kvp.Value;

                sb.Append(currentWord);
                sb.Append(',');
                sb.Append(currentFreq);
                sb.Append(',');
                sb.Append((100 * (double)currentFreq / totalWordsCount).ToString("F2"));
                sw.WriteLine(sb.ToString());
                sb.Clear();
            }

            sw.Flush();
            sw.Close();
        }

        private void AddWord(string newWord)
        {
            if (!words.ContainsKey(newWord))
            {
                words[newWord] = 0;
            }
            words[newWord]++;
        }
    }
}
