using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{
		int[] arr = { 1, 2, 3, 4, 5, 8, 10, 44, 55, 66, 100 };   // 11 numbers

		Console.WriteLine(BinarySearch(93, arr));
		Console.WriteLine(BinarySearch(0, arr));
		Console.WriteLine("index: " + BinarySearch(100, arr));
		Console.WriteLine("index: " + BinarySearch(3, arr));

		Console.WriteLine("Iterative method\t index: " + BinarySearchIterative(100, arr));
		Console.ReadKey();
	}


	//find target index
	public static int BinarySearch(int target, int[] nums)
	{
		return BinarySearchRecusive(target, nums, 0, nums.Length - 1);
	}

	private static int BinarySearchRecusive(int target, int[] nums, int floorIndex, int ceilIndex)
	{
		if (floorIndex > ceilIndex)
		{
			return -1;  // when target is less than smallest number or bigger than biggest number
		}

		int mid = floorIndex + (ceilIndex - floorIndex) / 2;

		if (nums[mid] == target)
		{
			return mid;
		}
		else if (nums[mid] < target)
		{
			return BinarySearchRecusive(target, nums, mid + 1, ceilIndex);
		}
		else
		{
			return BinarySearchRecusive(target, nums, floorIndex, mid - 1);
		}
	}


	public static int BinarySearchIterative(int target, int[] arr)
	{
		int floorIndex = 0;
		int ceilIndex = arr.Length - 1;

		while (floorIndex <= ceilIndex)
		{
			int mid = (floorIndex + ceilIndex) / 2;   //may 2 large int plus, stackoverflow

			if (arr[mid] == target)
			{
				return mid;
			}
			else if (arr[mid] > target)
			{
				ceilIndex = mid - 1;
			}
			else
			{
				floorIndex = mid + 1;
			}
		}
		return -1;   // doesn't have target
	}
}


//binary search usage:
using System;
using System.Collections.Generic;

class Program
{
	/*1. Find first/last instance's index of a number in sorted array where duplicates are allowed.
	e.g. find first/last 44
	find key occurrence: lastIndex - firstIndex + 1;
	*/
	static void Main(string[] args)
	{
		int[] arr = { 1, 2, 3, 4, 5, 8, 10, 44, 44, 66, 100 };   // 11 numbers

		Console.WriteLine($"first duplicate index: {FindFirstDuplicateIndex(arr, 44)}");
		Console.WriteLine($"last duplicate index: {FindLastDuplicateIndex(arr, 44)}");

		int[] nums = { 1, 2, 3, 4, 7, 6, 5 };
		Console.WriteLine($"first decreasing index: {FindDecreasingIndex(nums)}");
		Console.ReadKey();
	}

	private static int FindFirstDuplicateIndex(int[] arr, int key)
	{
		int leftIndex = 0;
		int rightIndex = arr.Length - 1;

		while (leftIndex <= rightIndex)
		{
			int mid = leftIndex + (rightIndex - leftIndex) / 2;

			if (arr[mid] == key && arr[mid - 1] != arr[mid])  //only change here
			{
				return mid;
			}
			else if (arr[mid] < key)
			{
				leftIndex = mid + 1;
			}
			else
			{
				rightIndex = mid - 1;
			}
		}

		return -1;
	}

	private static int FindLastDuplicateIndex(int[] arr, int key)
	{
		int leftIndex = 0;
		int rightIndex = arr.Length - 1;

		while (leftIndex <= rightIndex)
		{
			int mid = leftIndex + (rightIndex - leftIndex) / 2;

			if (arr[mid] == key && arr[mid - 1] == arr[mid])  //only change here
			{
				return mid;
			}
			else if (arr[mid] < key)
			{
				leftIndex = mid + 1;
			}
			else
			{
				rightIndex = mid - 1;
			}
		}

		return -1;
	}

	//Find a point where arrays starts decreasing, array is first increasing and then decreasing.
	private static int FindDecreasingIndex(int[] arr)
	{
		int left = 0;
		int right = arr.Length - 1;

		while (left <= right)
		{

			int mid = left + (right - left) / 2;

			if (arr[mid - 1] < arr[mid] && arr[mid] > arr[mid + 1]) // mid is the biggest number, mid+1 is the first decreasing number
			{
				return mid + 1;
			}
			else if (arr[mid - 1] < arr[mid] && arr[mid] < arr[mid + 1])  // increasing
			{
				left = mid + 1;
			}
			else if (arr[mid - 1] > arr[mid] && arr[mid] > arr[mid + 1])  // decreasing
			{
				right = mid - 1;
			}
		}
		return -1;

	}

}
