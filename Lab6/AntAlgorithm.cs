using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    class AntAlgorithm
    {

    }
    
    class Ant
    {
        private Path path;
        private int town;
        
        public Ant(Map map, int town)
        {
            path = new Path(map, town);
        }
        public void VisitTown(Map map, int town)
        {
            path.AddTown(map, town);
        }
        public bool IsVisited(int town)
        {
            return path.CheckTown(town);
        }
        public int GetDistance()
        {
            return path.N;
        }
    }
}
