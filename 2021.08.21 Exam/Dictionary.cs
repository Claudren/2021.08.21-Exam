using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _2021._08._21_Exam
{
    class Dictionary
    {
        public string path;
        public Dictionary<string, int> dictionary;

        public Dictionary(string path)
        {
            this.path = path;
        }

        public void CreateDictionary()
        {
            dictionary = new Dictionary<string, int>();

            DirectoryInfo directory = new DirectoryInfo(path);
            StreamReader reader;
            string[] words; 

            foreach (FileInfo file in directory.GetFiles())
            {
                reader = new StreamReader(file.FullName, Encoding.Default);
                
                foreach (Match word in Regex.Matches(reader.ReadToEnd(), @"\w+"))
                {
                    if (dictionary.ContainsKey(word.Value))
                    {
                        dictionary[word.Value]++;
                    }
                    else
                        dictionary.Add(word.Value, 1);
                }
            }
        }
    }
}
