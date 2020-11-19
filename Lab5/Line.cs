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
        bool isLast;
        List<Arguments> result;
        public Line(int lineID, int timeToSleep, Line nextLine, bool isLast = false)
        {
            this.lineID = lineID;
            this.timeToSleep = timeToSleep;
            next = nextLine;
            myQueue = new Queue<Arguments>();
            this.isLast = isLast;
            InitResult();
        }
        private void InitResult()
        {
            if (isLast)
            {
                result = new List<Arguments>();
            }
        }
        public Line(int lineID, int timeToSleep, Line nextLine, List<Arguments> elements)
        {
            this.lineID = lineID;
            this.timeToSleep = timeToSleep;
            next = nextLine;
            myQueue = new Queue<Arguments>(elements);
            this.isLast = false;
        }
        public void RunLine()
        {
            condition result = condition.run;
            while (result != condition.finish)
            {
                result = ProcessElem();
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
                    return FinishLine(element);
                }
                Action(element);
                if (next != null)
                {
                    next.PushElem(element);
                }
                else if (isLast)
                {
                    result.Add(element);
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
            Console.WriteLine("On line " + (lineID + 1).ToString() + " element " + arg.id.ToString() + " starts at " + DateTime.Now.Second.ToString());
            Thread.Sleep(timeToSleep);
            Console.WriteLine("On line " + (lineID + 1).ToString() + " element " + arg.id.ToString() + " ends at " + DateTime.Now.Second.ToString());
        }
        private condition FinishLine(Arguments arg)
        {
            if (next != null)
            {
                next.PushElem(arg);
            }
            return condition.finish;
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

        public List<Arguments> GetArguments()
        {
            return result;
        }
    }
}
