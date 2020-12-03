using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WordsCount
{
    class Program
    {
        private static Dictionary<String, int> WordsCount(string _text)
        {
            Dictionary<String, int> wc = new Dictionary<string, int>();
            _text = _text.Trim();
            string[] split_text = _text.Trim().Split(' ');
            foreach (string item in split_text)
            {
                if (String.IsNullOrWhiteSpace(item) || String.IsNullOrEmpty(item)||int.TryParse()
                    continue;
                if (!wc.ContainsKey(item.Trim()))
                {
                    wc.Add(item.Trim(), 1);
                }
                else
                {
                    wc[item] += 1;
                }
            }
            return wc;
        }

        private static void PrintWordsStat(String _text)
        {
            
            SortedList<int, String> keyValuePairs = new SortedList<int, string>();
            
            Dictionary<String, int> wc = WordsCount(_text);

            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>();

            foreach (var item in wc)
            {
                myList.Add(new KeyValuePair<string, int>(item.Key, item.Value));
            }

            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

            foreach (var item in myList)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        static void Main(string[] args)
        {
            StringBuilder filePath = new StringBuilder();

            foreach (var arg in args)
            {
                filePath.Append(arg);
            }
            string subs = "";
            if (File.Exists(filePath.ToString()))
            {
                subs = File.ReadAllText(filePath.ToString());
            }
            if (!String.IsNullOrWhiteSpace(subs))
            {
                PrintWordsStat(subs
                .Replace(",", "")
                .Replace(".", "")
                .Replace(".", "")
                .Replace(":", "")
                .Replace(">", "")
                .Replace("fw", "")
                .Replace("#", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("fwd", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace('\r', ' ')
                .Replace('\n', ' ')
                .ToLower());
            }            
        }
    }
}
