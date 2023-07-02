using System;
					
public class Program
{
	public static void Main()
	{
		int[] arr = new int[] { 89, 8, 76, 0, 7, 76, 3, 10, 3};
		Console.WriteLine("Original Array");
		printArray(arr);
		Console.WriteLine();
		MergeSort obj = new MergeSort();
		obj.Sort(arr, 0, arr.Length-1);
		Console.WriteLine("Sorted Array");
		printArray(arr);
		
	}
	static void printArray(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n; ++i)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }
}

class MergeSort
{
	public string PrintArray(int[] arr)
    {
        return string.Join(' ', arr);
    }
	public void Merge(int[] arr, int l, int m, int r)
	{
		Console.WriteLine($"Merge {PrintArray(arr)} left={l}, mid={m}, right={r}");
		//arr here is always an entire array. We will sort portion of the array
		
		//Two empty arrays of correct lengths
		int length1 = m - l + 1;
		int length2 = r - m;
		int[] arrLeft = new int[length1];
		int[] arrRight = new int[length2];
		
		//Fill those arrays
		for(int index = 0; index < length1; index++)
			arrLeft[index] = arr[l + index];
		for(int index = 0; index < length2; index++)
			arrRight[index] = arr[m + index + 1];
		
		//Get 3 index pointers 
		//1 for arrLeft, 1 for arrRight and 1 for arr
		int i = 0;
		int j = 0;
		int k = l; // sorting of array will start from left 
		
		//sort
		while(i < length1 && j < length2)
		{
			if(arrLeft[i] <= arrRight[j])
			{
				arr[k] = arrLeft[i];
				i++;
			}
			else
			{
				arr[k] = arrRight[j];
				j++;
			}
			k++;
		}
		
		//Add remaining elements from arrLeft and arrRight
		while(i < length1)
		{
			arr[k] = arrLeft[i];
			i++;
			k++;
		}
		while(j < length2)
		{
			arr[k] = arrRight[j];
			j++;
			k++;
		}
		Console.WriteLine($"MergeEnd {PrintArray(arr)}");
		Console.WriteLine(System.Environment.NewLine);
	}
	public void Sort(int[] arr, int l, int r)
	{
		PrintArray(arr);
		Console.WriteLine($"SORT {PrintArray(arr)} left={l}, right={r}");
		if(l < r)
		{
			int m = l + (r - l) / 2;
			
			Sort(arr, l, m);
			Sort(arr, m+1, r);
			Merge(arr, l, m , r);
		}
	}
}