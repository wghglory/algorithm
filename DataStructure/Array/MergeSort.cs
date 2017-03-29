using System;

public class MergeSortAlgo
{
	// Function to Merge Arrays L and R into A.
	// lefCount = number of elements in L
	// rightCount = number of elements in R.
	static void Merge(int[] arr, int[] left, int[] right)
	{
		int i, j, k;

		// i - to mark the index of left aubarray (L)
		// j - to mark the index of right sub-raay (R)
		// k - to mark the index of merged subarray (A)
		i = 0; j = 0; k = 0;

		while (i < left.Length && j < right.Length)
		{
			if (left[i] < right[j]) arr[k++] = left[i++];
			else arr[k++] = right[j++];
		}
		// only one of below execute
		while (i < left.Length) arr[k++] = left[i++];
		while (j < right.Length) arr[k++] = right[j++];
	}

	// Recursive function to sort an array of integers.
	static void MergeSort(int[] arr)
	{
		int mid;
		int n = arr.Length;
		if (n < 2) return; // base condition. If the array has less than two element, do nothing.

		mid = n / 2;  // find the mid index.

		// create left and right subarrays
		// mid elements (from index 0 till mid-1) should be part of left sub-array
		// and (n-mid) elements (from mid to n-1) will be part of right sub-array
		int[] left = new int[mid];
		int[] right = new int[n - mid];

		for (int i = 0; i < mid; i++) left[i] = arr[i]; // creating left subarray
		for (int i = mid; i < n; i++) right[i - mid] = arr[i]; // creating right subarray

		MergeSort(left);  // sorting the left subarray
		MergeSort(right);  // sorting the right subarray
		Merge(arr, left, right);  // Merging L and R into A as sorted list.
	}

	public static void Main(string[] args)
	{
		int[] arr = { 6, 2, 3, 1, 9, 10, 15, 13, 12, 17 }; // creating an array of integers.


		// finding number of elements in array as size of complete array in bytes divided by size of integer in bytes.
		// This won't work if array is passed to the function because array
		// is always passed by reference through a pointer. So sizeOf function will give size of pointer and not the array.
		// Watch this video to understand this concept - http://www.youtube.com/watch?v=CpjVucvAc3g


		// Calling merge sort to sort the array.
		MergeSort(arr);

		//printing all elements in the array once its sorted.
		for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + " ");
	}
}
