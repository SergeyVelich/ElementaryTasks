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

                while ((line = reader.ReadLine()) != null)
                {
                    int startIndex = 0;
                    do
                    {
                        startIndex = line.IndexOf(pattern, startIndex);
                        if (startIndex > -1)
                        {
                            countEntry ++;
                            startIndex = Math.Min(++ startIndex, line.Length);
                        }
                    } while (startIndex > -1);
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

                    while ((line = reader.ReadLine()) != null)
                    {
                        int startIndex = 0;
                        do
                        {
                            startIndex = line.IndexOf(pattern, startIndex);
                            if (startIndex > -1)
                            {
                                countEntry++;
                                startIndex = Math.Min(++startIndex, line.Length);
                            }
                        } while (startIndex > -1);

                        line = line.Replace(pattern, replacement);
                        writer.WriteLine(line);
                    }
                }
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
