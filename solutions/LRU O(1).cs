using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		var obj = new LRUCache(3);
		obj.Insert(4, 78);
		obj.Print();
		obj.Insert(4, 8);
		obj.Print();
		obj.Insert(3, 45);
		obj.Print();
		obj.Insert(5, 90);
		obj.Print();
		obj.Insert(4, 18);
		obj.Print();
		obj.Insert(5, 25);
		obj.Print();
		obj.GetValue(4);
		obj.Print();
		obj.GetValue(12);
		obj.Print();
		obj.Insert(12, 144);
		obj.Print();
		obj.GetValue(12);
		obj.Print();
		obj.Insert(4, 16);
		obj.Print();
		obj.GetValue(5);
		obj.Print();
		obj.GetValue(4);
		obj.Print();
	}
	
}
class LRUCache
{
	int capacity;
	public DllNode head = new DllNode();
	public DllNode tail = new DllNode();
	public Dictionary<int, DllNode> map;
	public LRUCache(int capacity)
	{
		this.capacity = capacity;
		map = new Dictionary<int, DllNode>(capacity);
		head.right = tail;
		tail.left = head;
	}
	
	public void Print()
	{
		Console.Write("[");
		foreach(var kvp in map)
		{
			Console.Write($"({kvp.Key},{(kvp.Value).v})");
		}
		Console.Write("[");
		
		Console.Write("            ");
		PrintLL();
	}
	void PrintLL()
	{
		DllNode node = head.right;
		Console.Write("[");
		while(node.right != null)
		{
			Console.Write($"({node.k},{node.v})");
			node = node.right;
		}
		Console.Write("]");
		Console.WriteLine();
	}
	
	public int GetValue(int k)
	{
		int v = -1;
		if(map.ContainsKey(k))
		{
			DllNode selected_node = map[k];
			v = selected_node.v;
			
			if(!(head.right.k == k))
			{
				Remove(selected_node);
				AddFirst(k, v);
			}
			return (map[k]).v;
		}
		return v;
	}
	
	public void Insert(int k, int v)
	{
		if(map.ContainsKey(k))
		{
			//Console.WriteLine($"Cache contains key '{k}' we will update value from {(map[k]).v} to {v}");
			//Since existing node is updated, as per LRU algorithm, bring it to the top, if not already.
			if(!(head.right.k == k))
			{
				//Console.WriteLine($"since {k} is not first node, move it to the first position");
				DllNode stale_node = (map[k]);
				Remove(stale_node);
				DllNode node = AddFirst(k, v);
				map[k] = node;
			}
			else
			{
				//Console.WriteLine($"{k} is at the first position. Change value in-place");
				head.right.v = v;
				(map[k]).v = v;
			}
		}
		else
		{
			if(map.Count >= capacity)
			{
				int key = RemoveLast();
				map.Remove(key);
			}
			//Console.WriteLine($"No problem whatsoever adding [{k}]=>[{v}]");
			DllNode node = AddFirst(k, v);
			map.Add(k, node);
		}
	}
	
	
	void AddFirst(DllNode node)
	{
			
	}
	
	//add a node after head
	DllNode AddFirst(int k, int v)
	{
		DllNode new_node = new DllNode(k, v);
		DllNode first = head.right;
		first.left = new_node;
		new_node.right = first;
		head.right = new_node;
		new_node.left = head;
		return new_node;
	}
	
	void Remove(DllNode node)
	{
		Console.WriteLine($"Removing stale node ({node.k},{node.v})");
		DllNode left_node = node.left;
		DllNode right_node = node.right;
		left_node.right = right_node;
		right_node.left = left_node;
		PrintLL();
		Console.WriteLine();
		Console.WriteLine();
	}
	
	//remove the node before tail
	int RemoveLast()
	{
		DllNode expired_node = tail.left;
		DllNode last_node = expired_node.left;
		last_node.right = tail;
		tail.left = last_node;

		return expired_node.k;
		//Console.WriteLine($"Removed last node i.e. [{expired_node.k}]=>[{expired_node.v}]");
	}
}
public class DllNode
{
	public int k; 
	public int v;
	public DllNode left;
	public DllNode right;
	public DllNode()
	{
		
	}
	public DllNode(int k, int v)
	{
		this.k = k; this.v = v;
	}
}