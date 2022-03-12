using JKLMWorder.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JKLMWorder
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            IEnumerable<String> words = File.ReadLines(@"words_alpha.txt");
            var matchedWords = new string[5];

            while(true)
            {
                Console.WriteLine("Insert the syllable:");
                string syllable = Console.ReadLine();

                var result = words.Where(word => word.Contains(syllable));
                int results = result.Count();

                if (results > 0)
                {
                    Random random = new Random();

                    int uniqueResults = 5;
                    if(results < 5)
                    {
                        uniqueResults = results;
                    }
                    else
                    {
                        Console.WriteLine(results);
                        for (int i = 0; i < 5; i++)
                        {
                            matchedWords[i] = result.ElementAt(random.Next(0, results));
                            Console.WriteLine(i+1 + ". " + matchedWords[i]);
                        }
                    }
                    string chosenWord = "";
                    Console.WriteLine("Choose the word to copy to your clipboard!");
                    string inputKey = Console.ReadLine();
                    try
                    {
                        switch (inputKey)
                        {
                            case "1":
                                chosenWord = matchedWords[0];
                                break;
                            case "2":
                                chosenWord = matchedWords[1];
                                break;
                            case "3":
                                chosenWord = matchedWords[2];
                                break;
                            case "4":
                                chosenWord = matchedWords[3];
                                break;
                            case "5":
                                chosenWord = matchedWords[4];
                                break;
                            default:
                                break;
                        }
                        Clipboard.SetText(chosenWord);
                        Console.WriteLine("The word has been copied to your clipboard!");
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("Invalid word selected!");
                    }
                }
                else
                {
                    Console.WriteLine("No words found with the given syllable");
                }
            }
        }
    }
}
