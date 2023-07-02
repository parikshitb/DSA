using System;
					
public class Program
{
	public static void Main()
	{
		int[] arr = new int[] {8, 7, 6, 1, 0, 9, 2};
		PrintArray(arr);
		(new QS_H()).Sort(arr, 0, arr.Length - 1);
		PrintArray(arr);
	}
	static void PrintArray(int[] arr)
	{
		for(int i=0; i<arr.Length; i++)
		{
			Console.Write($"{arr[i]} ");
		}
		Console.WriteLine();
	}
}

class QS_H
{
	public void Sort(int[] arr, int start, int end)
	{
		if(start < end)
		{
			int p = Partition(arr, start, end);
			Sort(arr, start, p);
			Sort(arr, p+1, end);
		}
	}
	
	int Partition(int[] arr, int start, int end)
	{
		int temp = (end + start) / 2;
		int pivot = arr[temp];
		//pivot can be chosen differently
		//e.g. int pivot = arr[start]
		int i = start -1;
		int j = end + 1;
		
		while(true){
			do{
				i++;
			} while(arr[i] < pivot);
			
			do{
				j--;
			} while(arr[j] > pivot);

			if(i >= j)
				return j;
			Swap(arr, i, j);
		}
		
	}
	void Swap(int[] arr, int i, int j)
	{
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}
}
