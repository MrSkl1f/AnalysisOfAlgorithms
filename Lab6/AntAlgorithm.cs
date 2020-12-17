using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    static class AntAlgorithm
    {
        public static Path GetRoute(Map map, int maxTime, double alpha, double beta, double Q, double pho)
        {
            Random r = new Random();

            Path shortest = new Path(null, map, int.MaxValue);
            
            int count = map.N;
            double[,] pher = InitPheromone(0.1, count);

            List<Ant> ants = null;

            for (int time = 0; time < maxTime; time++)
            {
                ants = InitAnts(map);
                for (int i = 0; i < count - 1; i++)
                {
                    double[,] deltaPher = InitPheromone(0, count);
                    foreach (Ant ant in ants)
                    {
                        int curTown = ant.LastVisited();

                        double sum = 0;
                        for (int town = 0; town < count; town++)
                        {
                            if (!ant.IsVisited(town))
                            {
                                double tau = pher[curTown, town];
                                double eta = 1 / map[curTown, town];
                                sum += Math.Pow(tau, alpha) * Math.Pow(eta, beta);
                            }
                        }

                        double check = r.NextDouble();
                        int newTown = 0;
                        for (; check > 0; newTown++)
                        {
                            if (!ant.IsVisited(newTown))
                            {
                                double tau = pher[curTown, newTown];
                                double eta = 1 / map[curTown, newTown];
                                double chance = Math.Pow(tau, alpha) * Math.Pow(eta, beta) / sum;
                                check -= chance;
                            }
                        }
                        newTown--;
                        ant.VisitTown(newTown);
                        deltaPher[curTown, newTown] += Q / map[curTown, newTown];
                    }
                    for (int k = 0; k < count; k++)
                        for (int t = 0; t < count; t++)
                            pher[k, t] = (1 - pho) * pher[k, t] + deltaPher[k, t];
                }
                foreach (Ant ant in ants)
                {
                    ant.VisitTown(ant.Start);

                    if (ant.GetDistance() < shortest.N)
                        shortest = ant.GetPath();
                }
            }
            return shortest;
        }

        private static List<Ant> InitAnts(Map map)
        {
            List<Ant> ants = new List<Ant>();
            for (int i = 0; i < map.N; i++)
                ants.Add(new Ant(map, i));
            return ants;
        }

        private static double[,] InitPheromone(double num, int size)
        {
            double[,] phen = new double[size, size];
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    phen[i, j] = size;
            return phen;
        }

    }
    
    class Ant
    {
        private Path path;
        private int town;
        private Map map;

        public Ant(Map map, int town)
        {
            path = new Path(map, town);
            this.town = town;
            this.map = map;
        }
        public void VisitTown(int town)
        {
            path.AddTown(town);
        }
        public int LastVisited()
        {
            return path.LastTown();
        }
        public bool IsVisited(int town)
        {
            return path.CheckTown(town);
        }
        public int GetDistance()
        {
            return path.N;
        }
        public Path GetPath()
        {
            return path;
        }
        public int Start
        {
            get { return town; }
        }
        public void Print()
        {
            path.Print();
        }
    }
}
