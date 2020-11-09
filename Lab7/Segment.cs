using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    class Segment
    {
        public char segment;
        public string[] words;
        public Segment(char curSegment, string[] curWords)
        {
            segment = curSegment;
            words = curWords;
        }
    }
}
