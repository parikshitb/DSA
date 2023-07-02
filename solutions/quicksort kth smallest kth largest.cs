using System;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine("Hello World");
		int[] arr = new int[]{8, 7, 6, 1, 0, 9, 2};
		printArray(arr);
		int k = 7;
		Console.WriteLine($"{k}th smallest element is {(new QS()).KthSmallest(arr, 0, arr.Length-1, k)}");
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
	public int KthSmallest(int[] arr, int start, int end, int k)
	{
		//1. condition
		int arrLength = end - start + 1;
		if(k > 0 && k <= arrLength) // why no condition start<end ?
		{
			/*
			* We need to find subarray where pivot element is at Kth position
			*/
			
			//Call partition to get next pivot index. 
			// Elements on the LHS of this pivot are less than pivot. Elements on the RHS are greater than pivot
			int p = Partition(arr, start, end);
			
			//kth smallest element will be at k-1 position. e.g. smallest element is at 0th position not 1st
			//p here is relative to 'start'.
			if(p-start == k-1)
				return arr[p];
			
			//if position is greater than K this means LHS of position contain more elements than K.
			//Let's bring position further to the left side by passing left subarray recursively.
			if(p-start > k-1)
				return KthSmallest(arr, start, p-1, k);
			
			return KthSmallest(arr, p+1, end, k-p+start-1); // IMP: k is relative to the new array now.
		}
		return -1;
	}
	public void KthLargest(int[] arr, int start, int end, int k)
	{
		if(k > 0 && k >= end-start+1)
		{
			int p = Partition(arr, start, end);
		}
	}
	string PrintArray(int[] Arr)
	{
		return string.Join(' ', Arr);
	}
	
	//Lomuto
	public int Partition(int[] arr, int start, int end)
	{
		int pivot = arr[end];
		int gtPivot = start;
		for(int i = start; i <= end-1; i ++)
		{
			if(arr[i] < pivot)
			{
				Swap(arr, gtPivot, i);
				gtPivot ++;
			}
		}
		Swap(arr, gtPivot, end);
		return gtPivot;
	}
	
	//Lomuto Reverse
	public int PartitionReverse(int[] arr, int start, int end)
	{
		int pivot = arr[start];
		int i = end;
		for(int j = end; j > start; j--)
		{
			if(arr[j] > pivot)
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