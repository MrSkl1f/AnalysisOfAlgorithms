using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Arguments
    {
        public int id;
        private bool last;

        public Arguments(int id, bool lastArgument = false)
        {
            this.id = id + 1;
            last = lastArgument;
        }

        public bool IsLast()
        {
            return last;
        }
    }
}
