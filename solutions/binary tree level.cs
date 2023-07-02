using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		BinaryTree tree = new BinaryTree();
		tree.root = new Node(45);
		tree.root.left = new Node(10);
		tree.root.right = new Node(90);
		tree.root.left.left = new Node(7);
		tree.root.left.right = new Node(2);
		tree.root.right.left = new Node(10);
		tree.root.right.right = new Node(12);
		tree.root.left.left.left = new Node(9);
		tree.root.right.left.left = new Node(15);
		tree.root.right.left.right = new Node(4);
		
		tree.BFS();
	}
}


class Node
{
	public int data;
	public Node left;
	public Node right;
	public Node(int i)
	{
		data = i;
		left = right = null;
	}
}

class BinaryTree
{
	public Node root;
	
	public void BFS()
	{
		/*
		* In binary tree traversal, there's no need to keep track of visited
		*/
		Queue<Node> q = new Queue<Node>();
		q.Enqueue(root);
		int level = 0;
		while(true)
		{
			int count = q.Count; //count at this level
			if(count == 0)
				break;
			
			while(count !=0)
			{
				Node n = q.Dequeue();
				Console.Write($"{n.data} ");
				if(n.left != null)
					q.Enqueue(n.left);
				if(n.right != null)
					q.Enqueue(n.right);
				count --;
			}
			Console.WriteLine(System.Environment.NewLine);
			level ++;
		}
	}
}