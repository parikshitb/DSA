using System;
using System.Collections.Generic;
using System.Text;
public class Program
{
	public static void Main()
	{
		var bWord = "hit";
		var eWord = "cog";
		var wList = new List<string>{"hot","dot","dog","lot","log","cog"};
		var graph = new Dictionary<string, HashSet<string>>();
		Dictionary<string, HashSet<string>> g = new Dictionary<string, HashSet<string>>();
		foreach(var word in wList)
            AddWordToGraph(word, g);
		foreach(var word in wList)
		{
			//add generic word as a key, actual word as value
			for(var i = 0; i < word.Length; i++)
			{
				var key = word.Remove(i, 1).Insert(i,"*");
				if(graph.ContainsKey(key))
				{
					(graph[key]).Add(word);
				}
				else
				{
					graph.Add(key, new HashSet<string>{word});
				}
			}
		}
		
		//check 
		foreach(var kvp in graph)
		{
			Console.Write(kvp.Key + "=>{");
			foreach(var str in kvp.Value)
			{
				Console.Write(str + " ");
			}
			Console.Write("}");
			Console.Write(System.Environment.NewLine);
		}
		Console.WriteLine("---------------");
		foreach(var kvp in g)
		{
			//Console.Write(kvp.Key + "=>{");
			foreach(var str in kvp.Value)
			{
				//Console.Write(str + " ");
			}
			//Console.Write("}");
			//Console.Write(System.Environment.NewLine);
		}
		var q = new Queue<string>();
		var path = new Dictionary<string, IList<IList<string>>>();
		var visited = new HashSet<string>();
		
		q.Enqueue(bWord);
		var v = new List<IList<string>>();
		v.Add(new List<string>(){bWord});
		path.Add(bWord, v);
		visited.Add(bWord);
		
		while(q.Count > 0)
		{
			var curWord = q.Dequeue();
			//Console.Write(curWord);
			for(var i = 0; i< curWord.Length; i++)
			{
				//Console.WriteLine("------ " + i + " ------");
				var search = curWord.Remove(i, 1).Insert(i, "*");
				if(graph.ContainsKey(search))
				{
					foreach(var entry in graph[search])
					{
						if(! visited.Contains(entry))
						{
							if(path.ContainsKey(entry))
							{
								
							}
							else
							{
								//for all paths till now, add curWord at the end
							}
							visited.Add(entry);
							q.Enqueue(entry);
						}
					}
				}
			}
		}
		foreach(var kvp in path)
			{
				Console.Write(kvp.Key + "=>");
				foreach(var entry in kvp.Value)
				{
					Console.Write(entry + " ");
				}
				Console.Write(System.Environment.NewLine);
			}
	}
	
	private static void AddWordToGraph(string word, Dictionary<string, HashSet<string>> graph){
        
        for(int i=0;i<word.Length;i++){
            
            StringBuilder sb = new StringBuilder(word);
            sb[i] = '*';
            
            if(graph.ContainsKey(sb.ToString()))
                graph[sb.ToString()].Add(word);
            else{
                var set = new HashSet<string>();
                set.Add(word);
                graph[sb.ToString()] = set;
            }

        }
	}
}

