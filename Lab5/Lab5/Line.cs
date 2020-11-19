using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Lab5
{
    enum condition { run, empty, finish };
    class Line
    {
        int lineID;
        int timeToSleep;
        Queue<Arguments> myQueue;
        Line next;

        public Line(int lineID, int timeToSleep, Line nextLine)
        {
            this.lineID = lineID;
            this.timeToSleep = timeToSleep;
            next = nextLine;
            myQueue = new Queue<Arguments>();
        }
        public Line(int lineID, int timeToSleep, Line nextLine, List<Arguments> elements)
        {
            this.lineID = lineID;
            this.timeToSleep = timeToSleep;
            next = nextLine;
            myQueue = new Queue<Arguments>(elements);
        }
        public void RunLine()
        {
            condition result = condition.run;
            while (result != condition.finish)
            {
                result = ProcessElem();
                if (result == condition.empty)
                {
                    Thread.Sleep(300);
                }
            }
        }
        private condition ProcessElem()
        {
            Arguments element = null;
            PopElem(ref element);
            if (element != null)
            {
                if (element.IsLast())
                {
                    if (next != null)
                    {
                        next.PushElem(element);
                    }
                    return condition.finish;
                }
                Action(element);
                if (next != null)
                {
                    next.PushElem(element);
                }
            }
            else
            {
                return condition.empty;
            }
            return condition.run;
        }
        private void Action(Arguments arg)
        {
            arg.start[lineID] = DateTime.Now.Second;
            Console.WriteLine((lineID + 1).ToString() + " start " + arg.id.ToString() + " " + arg.start[lineID].ToString());
            Thread.Sleep(timeToSleep);
            arg.end[lineID] = DateTime.Now.Second;
            Console.WriteLine((lineID + 1).ToString() + " end " + arg.id.ToString() + " " + arg.start[lineID].ToString());
        }
        private void PopElem(ref Arguments arg)
        {
            lock (myQueue)
            {
                if (myQueue.Count > 0)
                {
                    arg = myQueue.Dequeue();
                }
            }
        }
        public void PushElem(Arguments arg)
        {
            lock(myQueue)
            {
                myQueue.Enqueue(arg);
            }
        }
    }
}
