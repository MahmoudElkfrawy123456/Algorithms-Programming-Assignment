using System;
using System.Collections.Generic;

class KruskalMST
{
    static void Main()
    {
        int vertices = 4;
        List<Edge> edges = new List<Edge>
        {
            new Edge { Source = 0, Destination = 1, Weight = 10 },
            new Edge { Source = 0, Destination = 2, Weight = 6 },
            new Edge { Source = 0, Destination = 3, Weight = 5 },
            new Edge { Source = 1, Destination = 3, Weight = 15 },
            new Edge { Source = 2, Destination = 3, Weight = 4 }
        };

        Kruskal(vertices, edges);
    }
    public class Edge : IComparable<Edge>
    {
        public int Source, Destination, Weight;

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class DisjointSet
    {
        private int[] parent, rank;

        public DisjointSet(int size)
        {
            parent = new int[size];
            rank = new int[size];
            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public int Find(int x)
        {
            if (parent[x] != x)
                parent[x] = Find(parent[x]);
            return parent[x];
        }

        public void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                    parent[rootY] = rootX;
                else if (rank[rootX] < rank[rootY])
                    parent[rootX] = rootY;
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }
    }

    public static void Kruskal(int numberOfVertices, List<Edge> edges)
    {
        edges.Sort();

        DisjointSet ds = new DisjointSet(numberOfVertices);
        List<Edge> mst = new List<Edge>();

        foreach (var edge in edges)
        {
            int sourceParent = ds.Find(edge.Source);
            int destParent = ds.Find(edge.Destination);

            if (sourceParent != destParent)
            {
                mst.Add(edge);
                ds.Union(sourceParent, destParent);
            }
        }

        Console.WriteLine("Edges in the MST:");
        int totalWeight = 0;
        foreach (var edge in mst)
        {
            Console.WriteLine($"({edge.Source}, {edge.Destination}) - Weight: {edge.Weight}");
            totalWeight += edge.Weight;
        }
        Console.WriteLine($"Total weight of MST: {totalWeight}");
    }


}
