using NUnit.Framework;
using _2021._08._21_Exam;
using System.IO;
using System;

namespace TestProject1
{
    [TestFixture]
    public class NotInFile
    {

        [Test]
        public void AllWords()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();

            if (dictionary.dictionary.Keys.Count == 4)
            {
                foreach (var item in new string[] { "слова", "которые", "не", "прилаг" })
                {
                    if (!dictionary.dictionary.ContainsKey(item))
                        Assert.Fail();
                }
            }
            else
                Assert.Fail();
        }

        [Test]
        public void AllWordsIn2Files()
        {
            Dictionary dictionary = new Dictionary("testingTexts2");
            dictionary.CreateDictionary();

            if (dictionary.dictionary.Keys.Count == 4)
            {
                foreach (var item in new string[] { "слова", "которые", "не", "прилаг" })
                {
                    if (!dictionary.dictionary.ContainsKey(item))
                        Assert.Fail();
                }
            }
            else
                Assert.Fail();
        }

        [Test]
        public void Counted()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();
            int c;

            if (dictionary.dictionary.Keys.Count == 4)
            {
                foreach (var item in new string[] { "слова", "которые", "не", "прилаг" })
                {
                    if (!dictionary.dictionary.ContainsKey(item))
                        Assert.Fail();
                    if (item == "слова")
                    {
                        dictionary.dictionary.TryGetValue(item, out c);
                        if (c != 2)
                            Assert.Fail();
                    }
                }
            }
            else
                Assert.Fail();
        }

        [Test]
        public void IfEmty()
        {
            Dictionary dictionary = new Dictionary("testingTexts3");
            dictionary.CreateDictionary();

            if (!(dictionary.dictionary.Count == 0))
                Assert.Fail();
        }

        [Test]
        public void Sort()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();
            dictionary.Sort();

            if (dictionary.dictionary.Keys.Count != 4)
                Assert.Fail();

            int prev = int.MaxValue;

            foreach (var item in dictionary.dictionary)
            {
                if (item.Value > prev)
                    Assert.Fail();
                prev = item.Value;
            }
        }
    }


    [TestFixture]
    public class InFile
    {
        [Test]
        public void AllWords()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");

            StreamReader reader = new StreamReader("test.txt");
            while (!reader.EndOfStream)
            {
                if (!dictionary.dictionary.ContainsKey(reader.ReadLine().Split(' ')[0]))
                    Assert.Fail();
            }
            reader.Close();
        }

        [Test]
        public void AllWordsIn2Files()
        {
            Dictionary dictionary = new Dictionary("testingTexts2");
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");

            StreamReader reader = new StreamReader("test.txt"); 
            while (!reader.EndOfStream)
            {
                if (!dictionary.dictionary.ContainsKey(reader.ReadLine().Split(' ')[0]))
                    Assert.Fail();
            }
            reader.Close();
        }

        [Test]
        public void Counted()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");
            int value, value2;
            string key;
            string[] tokens;

            StreamReader reader = new StreamReader("test.txt"); 
            while (!reader.EndOfStream)
            {
                tokens = reader.ReadLine().Split(' ');
                key = tokens[0];
                value = Convert.ToInt32(tokens[2]);
                dictionary.dictionary.TryGetValue(key, out value2);
                if (!dictionary.dictionary.ContainsKey(key) || value != value2)
                    Assert.Fail();
            }
            reader.Close();
        }

        [Test]
        public void IfEmty()
        {
            Dictionary dictionary = new Dictionary("testingTexts3");
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");
            FileInfo file = new FileInfo("test.txt");

            if (!file.Exists || file.Length != 0)
                Assert.Fail();
        }

        [Test]
        public void Sort()
        {
            Dictionary dictionary = new Dictionary("testingTexts");
            dictionary.CreateDictionary();
            dictionary.Sort();
            dictionary.Save("test.txt");

            int prev = int.MaxValue;
            int value;
            StreamReader reader = new StreamReader("test.txt");
            while (!reader.EndOfStream)
            {
                value = Convert.ToInt32(reader.ReadLine().Split(' ')[2]);
                if (value > prev)
                    Assert.Fail();
                prev = value;
            }
            reader.Close();
        }
    }

    
}