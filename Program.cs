using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorithm
{
    class Program
    {

        public static Dictionary<object, List<object>> synsets = new Dictionary<object, List<object>>(); //Dictionary for synsets
        public static Dictionary<object, List<int>> synsetsIdList = new Dictionary<object, List<int>>();
        public static Dictionary<object, List<object>> hyhypernyms = new Dictionary<object, List<object>>(); //Dictionary for parent_1 and his children
        public static Dictionary<int, string> BFS_Color_1 = new Dictionary<int, string>(); //Dictionery to Mark Nodes of point_1
        public static Dictionary<int, string> BFS_Color_2 = new Dictionary<int, string>();//Dictionery to Mark Nodes of point_2
        public static Dictionary<int, int> BFS_Distance_1 = new Dictionary<int, int>();  //Dictionery to Calculate Distance of Nodes from point_1
        public static Dictionary<int, int> BFS_Distance_2 = new Dictionary<int, int>(); //Dictionery to Calculate Distance of Nodes from point_2
        public static Dictionary<int, int> parent_1 = new Dictionary<int, int>(); //Dictionery to Mark parents of point_1
        public static Dictionary<int, int> parent_2 = new Dictionary<int, int>(); //Dictionery to Mark parents of point_2


        //Reset Dictionaries for  Dijkstra Algorithm (Modified BFS)
        public static void Reset_Dictionaries() // O(A+B)
        {
            //  A = BFS_Distance_1.Count
            for (int i = 0; i < BFS_Distance_1.Count; i++) // O(A)
            {
                BFS_Color_1[i] = "WHITE";  // O(1)
                BFS_Distance_1[i] = 0;  // O(1)
            }
            //  B = BFS_Distance_2.Count
            for (int i = 0; i < BFS_Distance_2.Count; i++)  // O(B)
            {
                BFS_Color_2[i] = "WHITE"; // O(1)                   
                BFS_Distance_2[i] = 0;  // O(1)
            }
        }
        //take noun and return List of ID's
        static List<int> NountoSynsetID(string noun)  // O(1)
        {
            List<int> ides = synsetsIdList[noun];  // O(1)
            return ides;  // O(1)
        }
        //take id and return list of nouns on it
        static List<object> SynsetIdToNoun(int id) // O(1)
        {
            List<object> Nouns = synsets[id];  // O(1)
            return Nouns;  // O(1)
        }

        //BfS
        static void Breadth_Fisrt_S(Dictionary<object, List<object>> Adj, List<int> rootID, bool wOne)
        {
            if (wOne)
            {
                Queue<int> Q = new Queue<int>();
                foreach (var x in rootID)
                {
                    BFS_Color_1[x] = "BLACK";
                    BFS_Distance_1[x] = 0;
                    Q.Enqueue(x);
                }

                while (Q.Count != 0)
                {
                    int num = Q.Dequeue();
                    foreach (int i in Adj[num])
                    {
                        if (BFS_Color_1[i] == "WHITE")
                        {
                            BFS_Color_1[i] = "BLACK";
                            BFS_Distance_1[i] = BFS_Distance_1[num] + 1;
                            parent_1[i] = num;
                            Q.Enqueue(i);
                        }
                        else if (BFS_Color_1[i] == "BLACK" && BFS_Distance_1[num] + 1 < BFS_Distance_1[i])
                        {
                            BFS_Distance_1[i] = BFS_Distance_1[num] + 1;
                            parent_2[i] = num;
                        }
                    }
                    BFS_Color_1[num] = "BLACK";
                }
            }
            if (!wOne)
            {
                Queue<int> Q = new Queue<int>();
                foreach (var x in rootID)
                {
                    BFS_Color_2[x] = "BLACK";
                    BFS_Distance_2[x] = 0;
                    Q.Enqueue(x);
                }
                while (Q.Count != 0)
                {
                    int num = Q.Dequeue();
                    foreach (int i in Adj[num])
                    {
                        if (BFS_Color_2[i] == "WHITE")
                        {
                            BFS_Color_2[i] = "BLACK";
                            BFS_Distance_2[i] = BFS_Distance_2[num] + 1;
                            Q.Enqueue(i);
                        }
                    }
                    BFS_Color_2[num] = "BLACK";
                }
            }

        }

        //Shoretest Path 
        public static int[] GetShortPath(string noun, string noun2)
        {

            int[] Result = new int[2];
            Breadth_Fisrt_S(hyhypernyms, NountoSynsetID(noun), true);
            Breadth_Fisrt_S(hyhypernyms, NountoSynsetID(noun2), false);
            Queue<int> Q = new Queue<int>();

            for (int i = 0; i < synsets.Count; i++)
            {
                if (BFS_Color_2[i] == "BLACK" && BFS_Color_1[i] == "BLACK")
                {
                    Q.Enqueue(i);
                }
            }
            int min = int.MaxValue;
            int id = 0;
            while (Q.Count != 0)
            {
                int u = Q.Dequeue();
                if (BFS_Distance_1[u] + BFS_Distance_2[u] < min)
                {
                    min = (BFS_Distance_2[u] + BFS_Distance_1[u]);
                    id = u;
                }
            }
            Result[0] = min;
            Result[1] = id;
            return Result;
        }

        static void Main(string[] args)
        {
            
           
        }
    }
}











