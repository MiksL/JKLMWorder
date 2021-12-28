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

            while(true)
            {
                Console.WriteLine("Insert the syllable:");
                string syllable = Console.ReadLine();

                var result = words.Where(word => word.Contains(syllable));

                Random random = new Random();
                int results = result.Count();
                if (results > 0)
                {
                    var test = result.ElementAt(random.Next(0, results));

                    Console.WriteLine(test);
                    Clipboard.SetText(test);
                    Console.WriteLine("The word has been copied to your clipboard!");
                }
                else
                {
                    Console.WriteLine("No words found with the given syllable");
                }
            }
        }
    }
}
