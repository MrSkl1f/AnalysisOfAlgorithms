using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class SegmentDictionary
    {
        public Segment[] segments;
        public SegmentDictionary(Dictionary dict)
        {
            char[] letters = new char[] { 'e', 'a', 'o', 'i', 'd', 'h', 'n', 'r', 's', 't', 'u', 'y', 'c', 'f', 'g', 'l', 'm', 'w', 'b', 'k', 'p', 'q', 'j', 'v' };
            segments = new Segment[letters.Length];
            for (int i = 0; i < letters.Length; i++)
            {
                char curLetter = letters[i];
                int count = 0;   
                for (int j = 0; j < dict.N; j++)
                {
                    if (dict[j][0] == curLetter)
                    {
                        count++;
                    }
                }
                string[] wordsInSegment = new string[count];
                int k = 0;
                for (int j = 0; j < dict.N; j++)
                {
                    if (dict[j][0] == curLetter)
                    {
                        wordsInSegment[k] = dict[j];
                        k++;
                    }
                }
                segments[i] = new Segment(curLetter, wordsInSegment);
            }
        }

        public void ReadSegments()
        {
            foreach (Segment curSeg in segments)
            {
                Console.WriteLine();
                Console.WriteLine(curSeg.segment);
                foreach (string curWord in curSeg.words)
                {
                    Console.WriteLine(curWord);
                }
            }
        }

        public string FindWord(Word word)
        {
            foreach (Segment curSeg in segments)
            {
                if (curSeg.segment == word.segment)
                {
                    return curSeg.words[word.index];
                }
            }
            return null;
        }
    }
}
