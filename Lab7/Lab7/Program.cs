using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch clock = new Stopwatch();
            clock.Restart();
            Dictionary dict = new Dictionary();
            dict.LoadData();
            clock.Stop();

            clock.Restart();
            int res = Search.BruteForce("as", dict);
            clock.Stop();
            Console.WriteLine(clock.ElapsedTicks);

            dict.SortDictionary();
            clock.Restart();
            res = Search.BinaryFind("as", dict);
            clock.Stop();
            Console.WriteLine(clock.ElapsedTicks);

            SegmentDictionary segDict = new SegmentDictionary(dict);
            clock.Restart();
            Word result = Search.FindInSegment("as", segDict);
            clock.Stop();
            Console.WriteLine(clock.ElapsedTicks);
            Console.WriteLine(segDict.FindWord(result));
        }
    }
}
