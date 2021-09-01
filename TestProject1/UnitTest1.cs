using NUnit.Framework;
using _2021._08._21_Exam;

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
        public void AllWordsIn2File()
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
    }


    [TestFixture]
    public class InFile
    {

    }
}