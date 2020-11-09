
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab7
{
    class Dictionary
    {
        public string[] dictionary;
        private int n = 999;
        public Dictionary()
        {
            dictionary = new string[n];
        }

        public void LoadData()
        {
            string path = "C:/Users/MrSklif/Desktop/BMSTU/проекты/git/myDataParsers/dictionary/dictionary.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s;
                    int i = 0;
                    while ((s = sr.ReadLine()) != null)
                    {
                        dictionary[i] = s;
                        i++;
                    }
                }
            }
        }

        public void ReadData()
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                Console.WriteLine(dictionary[i]);
            }
        }

        public void SortDictionary()
        {
            Array.Sort(dictionary);
        }

        public string this[int i]
        {
            get { return dictionary[i]; }
            set { dictionary[i] = value; }
        }
        public int N
        {
            get { return n; }
            set { if (value > 0) n = 0; }
        }
    }
}
