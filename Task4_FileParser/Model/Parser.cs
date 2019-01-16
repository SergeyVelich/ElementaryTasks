using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Task4_FileParser.Resources;

namespace Task4_FileParser.Model
{
    public class Parser
    {
        public string Path { get; set; }

        public Parser(string path)
        {
            Path = path;
        }

        public int GetCountFinded(string pattern)
        {
            int countEntry = 0;

            using (StreamReader reader = new StreamReader(Path, Encoding.Default))
            {                   
                string line;
                int countEntryinLine;

                while ((line = reader.ReadLine()) != null)
                {
                    countEntryinLine = Regex.Matches(line, pattern).Count;
                    countEntry += countEntryinLine;
                }
            }

            return countEntry;
        }

        public int GetCountReplaced(string pattern, string replacement)
        {
            int countEntry = 0;            

            string tempFileName = System.IO.Path.GetDirectoryName(Path) + "\\" + System.IO.Path.GetRandomFileName() + ".txt";

            using (StreamWriter writer = new StreamWriter(tempFileName))
            {
                using (StreamReader reader = new StreamReader(Path))
                {
                    string line;
                    int countEntryinLine;

                    while (!reader.EndOfStream)
                    {
                        line = reader.ReadLine();
                        countEntryinLine = Regex.Matches(line, pattern).Count;
                        countEntry += countEntryinLine;

                        if (countEntryinLine > 0)
                        {
                            line = Regex.Replace(line, pattern, replacement);
                        }

                        writer.WriteLine(line);
                    }
                }
                writer.Flush();
            }

            
            try
            {
                if (countEntry > 0)
                {
                    File.Replace(tempFileName, Path, null);
                }
            }
            catch
            {
                throw new IOException(String.Format(MessagesResources.ErrorSaveFile, Path));
            }
            finally
            {
                try
                {
                    File.Delete(tempFileName);
                }
                catch
                {
                    throw new IOException(String.Format(MessagesResources.ErrorDeleteTemporaryFile, Path));
                }
            }

            return countEntry;
        }
    }
}
