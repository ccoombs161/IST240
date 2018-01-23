using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQDistinctWords
{
    public class LINQDistinctWords
    {
        public static void Main(string[] args)
        {
            // Prompt the user for input
            Console.WriteLine("Please enter a sentence:");
            string sentence = Console.ReadLine();
            string[] words = sentence.Split();

            // use LINQ to sort the words and convert to lowercase
            var sortedWords =
                from word in words
                let lowerCaseWord = word.ToLower()
                orderby lowerCaseWord
                select lowerCaseWord;

            Console.WriteLine("\nYou entered:");
            Console.WriteLine(sentence);
            Console.Write("\nDistinct words:");

            // display only the distinct words
            foreach (var word in sortedWords.Distinct())
                Console.Write("{0}", word);
            Console.WriteLine();
        } // end Main
    } // end class LINQDistinctWords
} // end namespace