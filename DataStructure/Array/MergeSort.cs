using System;

// Divide and Conquer
// Recursion

public class Sort
{
	public static void mergeSort(int[] arr, int left, int right)
	{
		if (left >= right)
			return;
		int mid = left + (right - left) / 2;
		mergeSort(arr, left, mid);
		mergeSort(arr, mid + 1, right);
		merge(arr, left, mid, right);
	}

	private static void merge(int[] arr, int left, int mid, int right)
	{
		int[] newarr = new int[right - left + 1];

		for (int i = left; i <= right; i++)
			newarr[i - left] = arr[i];

		int l = 0;
		int r = mid - left + 1;
		for (int i = left; i <= right; i++)
		{
			if (l > mid - left)
				arr[i] = newarr[r++];
			else if (r > right - left)
				arr[i] = newarr[l++];
			else
				arr[i] = newarr[l] < newarr[r] ? newarr[l++] : newarr[r++];
		}
	}

	public static void Main(string[] args)
	{
		int[] arr = { 4, 7, 3, 5, 6, 5, 8, 4, 3, 2, 4, 5, 4 };

		mergeSort(arr, 0, arr.Length - 1);

		Console.WriteLine(string.Join(",", arr));
	}
}
