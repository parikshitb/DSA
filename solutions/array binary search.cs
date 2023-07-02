using System;
					
public class Program
{
	public static void Main()
	{
		int[] arr = new int[]{ 9, 44, 51, 98, 789, 811, 1001};
		int needle = 44;
		
		Console.WriteLine($"{needle} is found at {BinarySearchIterative(arr, needle)} position");
	}
	
	
	public static int BinarySearchIterative(int[] arr, int no)
	{
		int start = 0;
		int end = arr.Length - 1;
		
		while(end >= start)
		{
			int i = start + (end - start) / 2 ; 
			if(arr[i] == no)
				return i;
			if (no > arr[i])
				start = i + 1; 
			else
				end = i - 1;
		}
		return -1;
	}
	public static int BinarySearchy(int[] hay, int needle, int start, int end)
	{
		if(end < start)
			return -1;
		
		int mid = start + (end - start) / 2;
		if(hay[mid] == needle)
			return mid;
		if(needle > hay[mid])
			return BinarySearchy(hay, needle, mid+1, end);
		return BinarySearchy(hay, needle, start, mid-1);
	}
	
	public static int binarySearch(int[] arr, int x, int l, int r)
    {
        if (r >= l) {
            int mid = l + (r - l) / 2;
            if (arr[mid] == x)
                return mid;
 
            if (arr[mid] > x)
                return binarySearch(arr, x, l, mid - 1);
 
            return binarySearch(arr, x, mid + 1, r);
        }
        return -1;
    }
}