using System;

namespace HashTableCsharp
{
    class Program
    {
        public static void CountWordFrequency(string sentence)
        {
            MyMapNode<string, int> frequencyDictionary = new MyMapNode<string, int>(10);
            string[] words = sentence.Split(' ');
            foreach (string word in words)
            {
                if (frequencyDictionary.Exists(word))
                {
                    frequencyDictionary.Add(word, frequencyDictionary.Get(word) + 1);
                }
                else
                {
                    frequencyDictionary.Add(word, 1);
                }
            }
            frequencyDictionary.PrintDictionary();
            Console.WriteLine("---------------------------------");

        }
        static void Main(string[] args)
        {

            CountWordFrequency("To be or not to be");
            
        }
    }
}
