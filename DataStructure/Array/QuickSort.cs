using System;

public class Sort
{
	//https://www.youtube.com/watch?v=COk73cpQbFQ
	public static void quickSort(int[] arr, int start, int end)
	{
		if (start > end)
			return;

		int partitionIndex = partition(arr, start, end);
		quickSort(arr, start, partitionIndex - 1);
		quickSort(arr, partitionIndex + 1, end);
	}


	private static int partition(int[] arr, int start, int end)
	{
		int pivot = arr[end];
		int partitionIndex = start;  //stopped if element bigger than pivot
		for (int i = start; i < end; i++)   //any element lesser than pivot is on the left, exit partitionIndex is the first element bigger than pivot
		{
			if (arr[i] <= pivot)
			{
				//int tmp = arr[partitionIndex];
				//arr[partitionIndex] = arr[i];
				//arr[i] = tmp;
				Swap(ref arr[i], ref arr[partitionIndex]);

				partitionIndex++;
			}
		}

		//arr[end] = arr[partitionIndex];
		//arr[partitionIndex] = pivot;
		Swap(ref arr[end], ref arr[partitionIndex]);  //partitionindex is the first element bigger than pivot, so just swap it with pivot. finally partitionIndex is pirvot
		return partitionIndex;
	}

	private static void Swap(ref int a, ref int b)
	{
		int tmp = a;
		a = b;
		b = tmp;
	}

	public static void Main(string[] args)
	{
		int[] arr = { 4, 7, 3, 6, 5, 8, 13, 2, 10 };

		quickSort(arr, 0, arr.Length - 1);

		Console.WriteLine(string.Join(",", arr));
	}
}
