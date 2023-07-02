using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		int[] arr = new int[]{8, 7, 6, 1, 0, 9, 2};
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
		if(start < end)
		{
			int p = PartitionReverse(arr, start, end);
			Sort(arr, p+1, end);
			Sort(arr, start, p-1);
		}
	}
	private int PartitionReverse(int[] arr, int start, int end)
	{
		int pivot = arr[start];
		int i = end;
		for(int j = end; j > start; j--)
		{
			if(arr[j] < pivot)
			{
				Swap(arr, i, j);
				i--;
			}
		}
		Swap(arr, i, start);
		return i;
	}
	private void Swap(int[] arr, int index1, int index2)
	{
		int temp = arr[index1];
		arr[index1] = arr[index2];
		arr[index2] = temp;
	}
}