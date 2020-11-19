using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Arguments
    {
        public int id;
        public int[] start;
        public int[] end;
        private bool last;

        public Arguments(int countOfLines, int id, bool lastArgument = false)
        {
            this.id = id + 1;
            start = new int[countOfLines];
            end = new int[countOfLines];
            last = lastArgument;
        }

        public bool IsLast()
        {
            return last;
        }
    }
}
