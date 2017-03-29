using System;

public class Sort
{

	public static void quickSort(int[] arr, int l, int r)
	{
		if (l > r)
			return;

		int pivot = getPivot(arr, l, r);
		quickSort(arr, l, pivot - 1);
		quickSort(arr, pivot + 1, r);
	}


	private static int getPivot(int[] arr, int l, int r)
	{
		int pivot = arr[r];
		int idx = l;
		for (int i = l; i < r; i++)
		{
			if (arr[i] < pivot)
			{
				int tmp = arr[idx];
				arr[idx++] = arr[i];
				arr[i] = tmp;
			}
		}
		arr[r] = arr[idx];
		arr[idx] = pivot;
		return idx;
	}

	public static void Main(string[] args)
	{
		int[] arr = { 4, 7, 3, 5, 6, 5, 8, 4, 3, 2, 4, 5, 4 };

		quickSort(arr, 0, arr.Length - 1);

		Console.WriteLine(string.Join(",", arr));
	}
}
