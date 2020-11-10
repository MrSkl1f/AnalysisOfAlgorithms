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
            return result;
        }

        public static int BinaryFind(string str, Dictionary dict)
        {
            int left = 0;
            int right = dict.N;
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + (right - left) / 2;
                int need = String.Compare(str, dict[mid]);
                if (need == 0)
                    return mid;

                if (need < 0)
                    right = mid;
                else
                    left = mid + 1;
            }

            return -(1 + left);
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
                    return new Word('0', -1);
                }
            }
            return new Word('0', -1);
        }
    }
}
