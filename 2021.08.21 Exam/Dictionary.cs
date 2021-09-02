using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _2021._08._21_Exam
{
    public class Dictionary
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

        public void Save(string path)
        {
            FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(file, Encoding.Default);
            

            foreach (var item in dictionary)
            {
                writer.WriteLine(item.Key + " = " + item.Value);
            }
            writer.Flush();
            file.Close();
        }

        public void Sort()
        {
            int b;
            Dictionary<string, int> ndictionary = new Dictionary<string, int>();

            while (dictionary.Count > 0)
            {
                b = 0;
                foreach (var item in dictionary)
                {
                    if (b < item.Value)
                        b = item.Value;
                }

                while (dictionary.ContainsValue(b))
                {
                    foreach (var item in dictionary)
                    {
                        if (item.Value == b)
                        {
                            ndictionary.Add(item.Key, b);
                            dictionary.Remove(item.Key);
                            break;
                        }
                    }
                }

                
            }
            dictionary = ndictionary;
        }
    }
}
