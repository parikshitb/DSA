using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		int[] arr = new int[]{3, 2, 3, 1, 2, 4, 5, 5, 6};
		printArray(arr);
		Console.WriteLine();
		(new QS()).Sort(arr, 0, arr.Length-1);
		printArray(arr);
	}
	static void printArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
            Console.Write(arr[i] + " ");
  
        Console.WriteLine();
    }
}
class QS 
{
	
	public void Sort(int[] arr, int start, int end)
	{
		if(start >= end) 
			return;
		
		int p = Partition(arr, start, end);
		Console.WriteLine($"partition at {p}");
		Sort(arr, start, p-1);
		Sort(arr, p+1, end);
	}
	string PrintArray(int[] Arr)
	{
		return string.Join(' ', Arr);
	}
	public int Partition(int[] arr, int start, int end)
	{
		int pivot = arr[end];
		Console.WriteLine($"For {start} to {end}");
		int i = start;
		Console.WriteLine($"[{PrintArray(arr)}]");
		for(int j = start; j <= end-1; j ++)
		{
			if(arr[j] < pivot)
			{
				Swap(arr, i, j);
				i ++;
				Console.WriteLine($"[{PrintArray(arr)}]");
			}
		}
		Swap(arr, i, end);
		Console.WriteLine($"[{PrintArray(arr)}]");
		return i;
	}
	private void Swap(int[] arr, int index1, int index2)
	{
		int temp = arr[index1];
		arr[index1] = arr[index2];
		arr[index2] = temp;
	}
}