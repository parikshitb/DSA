using System;
using System.Linq;
using System.Collections.Generic;


//Basically a Graph data structure are key-value pairs
//Joined vertices can be stored as key-value pair

class Graph
{
	int _v;
	LinkedList<int>[] _llArr;
	Dictionary<int, HashSet<int>> _d;
	
	public Graph(int vertices)
	{
		_v = vertices;
		var arr = new int[_v]; // array of ints
		_llArr = new LinkedList<int>[_v]; //array of linked list
		_d = new Dictionary<int, HashSet<int>>();
		
		for(int i = 0; i < _llArr.Length; i++)
		{
			_llArr[i] = new LinkedList<int>();
		}
	}
	
	public void AddEdgeD(int i, int j)
	{
		if(_d.ContainsKey(i))
			(_d[i]).Add(j);
		else
			_d[i] = new HashSet<int>{j};
	}
	
	public void AddEdge(int start, int end)
	{
		_llArr[start].AddLast(end);
	}
	
	
	//Time Complexity = O(V+E) 
	//where
	//V = number of vertices
	//E = number of edges
	public void BFS(int start)
	{
		Queue<int> q = new Queue<int>();
		HashSet<int> visited = new HashSet<int>();
		/*
		* We need to keep track of visited nodes while BFS for graph
		* enqueue the starting node.
		* keep adding connected nodes to queue
		* dequeue when you read it
		* do this till queue is not empty
		*/
		//Using LL
		q.Enqueue(start);
		visited.Add(start);
		
		while(q.Any())
		{
			int i = q.Dequeue();
			Console.WriteLine(i);
			LinkedList<int> connections = _llArr[i];
			foreach(int point in connections)
			{
				if(! visited.Contains(point))
				{
					q.Enqueue(point);
					visited.Add(point);
				}
			}
		}
		
		//Using Dictionary
		start = 24;
		visited = new HashSet<int>();
		q.Enqueue(start);
		visited.Add(start);
		while(q.Any())
		{
			int i = q.Dequeue();
			
			HashSet<int> connections = _d[i];
			foreach(int point in connections)
			{
				Console.WriteLine($"({i})-------->({point})");
				//Console.WriteLine($"{i} is a {point} String");
				if(! visited.Contains(point))
				{
					q.Enqueue(point);
					visited.Add(point);
				}
			}
		}
	}
}
public class Program
{
	public static void Main()
	{
		//Create a graph
		Graph g = new Graph(4);
		//Using LL
		g.AddEdge(0, 1);
		g.AddEdge(0, 2);
		g.AddEdge(1, 2);
		g.AddEdge(2, 0);
		g.AddEdge(2, 3);
		g.AddEdge(3, 3);
		//Using Dictionary
		g.AddEdgeD(20, 11);
		g.AddEdgeD(20, 24);
		g.AddEdgeD(11, 24);
		g.AddEdgeD(24, 20);
		g.AddEdgeD(24, 3);
		g.AddEdgeD(3, 3);
		
		//Call BFS
		g.BFS(2);
	}
}