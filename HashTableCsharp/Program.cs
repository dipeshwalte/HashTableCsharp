using System;

namespace HashTableCsharp
{
    class Program
    {
        public static void CountWordFrequency(string sentence, MyMapNode<string, int> frequencyDictionary)
        {
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
            MyMapNode<string, int> frequencyDictionary = new MyMapNode<string, int>(10);
            MyMapNode<string, int> frequencyDictionaryParanoid = new MyMapNode<string, int>(10);
            CountWordFrequency("To be or not to be",frequencyDictionary);
            CountWordFrequency("Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations",frequencyDictionaryParanoid);
            frequencyDictionaryParanoid.Remove("avoidable");
            frequencyDictionaryParanoid.PrintDictionary();
        }
    }
}
