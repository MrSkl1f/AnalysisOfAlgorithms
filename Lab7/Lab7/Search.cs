using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab7
{
    static class Search
    {
        public static int BruteForce(string str, Dictionary dict)
        {
            int result = -1;
            for (int i = 0; i < dict.N; i++)
            {
                if (Equals(str, dict[i]))
                {
                    return(i);
                }
            }
            return result + 1;
        }

        public static int BinaryFind(string str, Dictionary dict)
        {
            int result, left = 0, right = dict.N - 1;
            while (true)
            {
                if (left > right)
                {
                    return 0;
                }
                result = left + (right - left) / 2;
                int need = String.Compare(str, dict[result]);
                if (need < 0)
                {
                    right = result + 1;
                }
                if (need > 0)
                {
                    left = result - 1;
                }
                if (need == 0)
                {
                    return result;
                }
            }
        }

        public static Word FindInSegment(string str, SegmentDictionary segDict)
        {
            foreach (Segment curSegment in segDict.segments)
            {
                if (curSegment.segment == str[0])
                {
                    int i = 0;
                    foreach (string word in curSegment.words)
                    {
                        if (word == str)
                        {
                            return new Word(curSegment.segment, i);
                        }
                        i++;
                    }
                }
            }
            return new Word('0', 0);
        }
    }
}
