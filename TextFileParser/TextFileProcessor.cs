using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace TextFileParser
{
    public class TextFileProcessor
    {
        private List<string> _contents;
        
        public string FilePath { get; private set; }

        public TextFileProcessor(string filepath)
        {
            FilePath = filepath;
            var sr = new StreamReader(filepath);
            if (sr == null) throw new Exception("File path not found!");
            _contents = sr.ReadToEnd().Split(' ').ToList();
        }

        private bool isValidWord(string str)
        {
            Regex rx = new Regex("^[a-zA-Z]");
            return rx.IsMatch(str);
        }

        public int GetWordCount()
        {

            return _contents.Where(word => isValidWord(word) == true).ToList().Count;
        }

        public int GetCapitalCount()
        {
            return _contents.Where(word => word.Length != 0 && Char.IsUpper(word[0]) == true).ToList().Count;
        }

        public int GetLowerCaseCount()
        {
            return _contents.Where(word => word.Length != 0 && Char.IsLower(word[0]) == true).ToList().Count;
        }

        public string GetSummary()
        {
            return "Word Count : " + GetWordCount().ToString() + 
                "\nCapital Words : " + GetCapitalCount().ToString() + 
                "\nLower Case Words : " + GetLowerCaseCount().ToString();
        }
    }
}