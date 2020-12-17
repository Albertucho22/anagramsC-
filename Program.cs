using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagramsC_
{
    class Program
    {
        public string path = @"C:\Users\Joshua\Desktop\anagramsC-\data\text.txt";
        public string outPath = @"C:\Users\Joshua\Desktop\anagramsC-\data\output.txt";
        public string writeInFile(string outPath, string g)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(outPath, true))
            {
                file.WriteLine(g);             
            }
            return g;
        }

        public Boolean findAllAnagramsInFile(string path, string outPath)
        {
            Boolean executedCorrectly = true;
            Program p = new Program();

            try
            {

            p.overWriteInFile(outPath); //create an empty txt file

            //WE CAN SELECT ONE OR THE TWO OPTIONS
            
            //1
            p.findAllAnagramsInFile(path, outPath); //find 20683 sets of anagrams and write them in a file "Output.txt"
            
            //2
            Console.WriteLine("\n" + p.findAnSpecificAnagramsInFile(path, "crepitus")); //Find anagrams of an specific word

            File.ReadAllLines(path)
            .GroupBy(w => new string(w.OrderBy(c => c).ToArray()))
            //.GroupBy(new string(w.OrderBy(c => c).ToArray()))
            .Where(g => g.Count() > 1)
            //.ToList().ForEach(g => Console.WriteLine(String.Join(" ", g)));
            .ToList().ForEach(g => p.writeInFile(outPath, (String.Join(" ", g))));

            return executedCorrectly;
            }
            catch (System.Exception e)
            {
                return executedCorrectly = false;
            }

        }

        public bool findAnSpecificAnagramsInFile(string path, string g)
        {
            Program p = new Program();
            bool isAnagramAux = true;
            var klk = File.ReadAllLines(path);
            klk.GroupBy(w => String.Concat(w.OrderBy(c => c)));
            klk.Where(g => g.Count() > 1);
            klk.ToList();
            foreach (string x in klk)
            {
                if (g.Length == x.Length && g != x)
                {
                    if (p.isAnagram(g, x))
                    {
                        if (isAnagramAux) Console.Write(g);
                        Console.Write(" " + x);
                        isAnagramAux = false;
                    }
                }
            }
            return !(isAnagramAux);
        }

        public bool isAnagram(string s1, string s2)
        {
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();
            Array.Sort(c1);
            Array.Sort(c2);
            if (c1.SequenceEqual(c2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void overWriteInFile(string outPath)
        {
            System.IO.File.WriteAllText(outPath, "");
        }
    }
}
