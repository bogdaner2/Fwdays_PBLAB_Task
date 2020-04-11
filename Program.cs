using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Fwdays_PMLAB_Task
{
    class Program
    {
        private const int SupposedLimit = 10;
        
        static void Main(string[] args)
        {
            var fileText = ReadFile("mess.txt");
            var charsDictionary = CountUniqueChars(fileText);
            var neededLetters = charsDictionary.Where(x => x.Value < SupposedLimit).Select(x => x.Key).ToList();
            var neededLettersSet = new HashSet<char>(neededLetters);
            
            Console.WriteLine("Phrase:");

            fileText.Where(neededLettersSet.Contains).ToList().ForEach(Console.Write);

            Console.ReadLine();
        }

        private static Dictionary<char, int> CountUniqueChars(string incomingString)
        {
            var characterCount = new Dictionary<char, int>();

            foreach (var character in incomingString)
            {
                if (!characterCount.ContainsKey(character))
                    characterCount.Add(character, 1);
                else
                    characterCount[character]++;
            }
            return characterCount;
        }  
        
        private static string ReadFile(string fileName)
        {
            var filePath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}/{fileName}";
            return File.ReadAllText(filePath);
        }
    }
}
