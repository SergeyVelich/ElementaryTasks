using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4_FileParser.Model
{
    public class Parser
    {
        private string _path;

        public Parser(string path)
        {
            _path = path;
        }

        public int GetCountFinded(string stringToFind)
        {
            int countEntry = 0;

            using (StreamReader reader = new StreamReader(_path, Encoding.Default))
            {                   
                string line;
                int countEntryinLine;

                while ((line = reader.ReadLine()) != null)
                {
                    countEntryinLine = Regex.Matches(line, stringToFind).Count;
                    countEntry += countEntryinLine;
                }
            }

            return countEntry;
        }

        public int GetCountReplaced(string stringToReplace, string stringReplacer)
        {
            int countEntry = 0;            

            string tempFileName = Path.GetDirectoryName(_path) + "\\" + Path.GetRandomFileName() + ".txt";

            using (StreamWriter writer = new StreamWriter(tempFileName))
            {
                using (StreamReader reader = new StreamReader(_path))
                {
                    string line;
                    int countEntryinLine;

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        countEntryinLine = Regex.Matches(line, stringToReplace).Count;
                        countEntry += countEntryinLine;

                        if (countEntryinLine > 0)
                        {
                            Regex.Replace(line, stringToReplace, stringReplacer);
                        }

                        writer.WriteLine(line);
                    }
                }

                if (countEntry > 0)
                {
                    try
                    {
                        writer.Flush();
                        File.Replace(tempFileName, _path, null);
                    }
                    catch
                    {
                        throw new IOException();
                    }
                }
                else
                {
                    try
                    {
                        File.Delete(tempFileName);
                    }
                    catch
                    {
                        throw new IOException();
                    }
                }

                return countEntry;
            }
        }
    }
}
