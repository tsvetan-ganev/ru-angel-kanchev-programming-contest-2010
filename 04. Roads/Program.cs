using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roads
{
	class Program
	{
		/// <summary>
		/// Depth First Search implemented with a stack.
		/// The function finds the number of separated sub-graphs.
		/// </summary>
		/// <param name="roadsMap">A graph representing the roads between cities.</param>
		/// <returns>The minimal number of roads that are needed to connect all the cities.</returns>
		static int FindRoadsNeeded(Dictionary<int, HashSet<int>> roadsMap)
		{
			HashSet<int> visited = new HashSet<int>();
			HashSet<int> citiesToVisit = new HashSet<int>();
			Stack<int> s = new Stack<int>();

			// populating the cities to be visited
			foreach (var road in roadsMap)
			{
				citiesToVisit.Add(road.Key);
			}

			// depth first search
			int roadsNeeded = -1;
			while (citiesToVisit.Count > 0)
			{
				roadsNeeded++;
				int start = citiesToVisit.First();
				s.Push(start);
				while (s.Count > 0 && citiesToVisit.Count > 0)
				{
					int current = s.Pop();
					visited.Add(current);
					citiesToVisit.Remove(current);

					foreach (var node in roadsMap[current])
					{
						if (!visited.Contains(node))
						{
							s.Push(node);
						}
					}
				}
			}
			return roadsNeeded;
		}

		/// <summary>
		/// Inputs a two-way connected graph with N nodes and E edges from the console.
		/// </summary>
		/// <param name="nodesCount">Number of nodes in the graph.</param>
		/// <param name="edgesCount">Number of edges in the graph.</param>
		/// <returns>
		/// A dictionary with an integer key (Node ID) 
		/// and hashset containing all neighbours of the node
		/// </returns>
		static Dictionary<int, HashSet<int>> InputGraph(int nodesCount, int edgesCount)
		{
			Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();

			// initialize the dictionary
			for (int i = 1; i <= nodesCount; i++)
			{
				graph.Add(i, new HashSet<int>());
			}

			// input edges from the console
			for (int i = 0; i < edgesCount; i++)
			{
				string line = Console.ReadLine();
				string[] values = line.Split(' ');

				int from = Int32.Parse(values[0]);
				int to = Int32.Parse(values[1]);
				graph[from].Add(to);
				graph[to].Add(from);
			}

			return graph;
		}

		/// <summary>
		/// Displays a graph on the console window.
		/// </summary>
		static void PrintGraph(Dictionary<int, HashSet<int>> graph)
		{
			foreach (var item in graph)
			{
				Console.Write("{0} -> ", item.Key);
				foreach (var node in item.Value)
				{
					Console.Write("{0} ", node.ToString());
				}
				Console.WriteLine();
			}
		}

		static void Main(string[] args)
		{
			string line = Console.ReadLine();
			string[] values = line.Split(' ');

			int n = Int32.Parse(values[0]);
			int m = Int32.Parse(values[1]);

			var roads = InputGraph(n, m);
			//PrintGraph(roads);

			int roadsNeeded = FindRoadsNeeded(roads);
			Console.WriteLine("{0}", roadsNeeded);
		}
	}
}
