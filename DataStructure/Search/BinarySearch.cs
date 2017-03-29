using System;
using System.Collections.Generic;

class Program
{

	static void Main(string[] args)
	{
		int[] arr = { 1, 2, 3, 4, 5, 8, 10, 44, 55, 66, 100 };   // 11 numbers

		Console.WriteLine(BinarySearchRecusive(0, arr));   //-1 not existing
		Console.WriteLine("recurison method\t index: " + BinarySearchRecusive(100, arr));
		Console.WriteLine("recurison method\t index: " + BinarySearchRecusive(3, arr));
		Console.WriteLine("Iterative method\t index: " + BinarySearchIterative(100, arr));

		// binary search usage:
		int[] test = { 10, 44, 44, 44, 55, 66 };
		Console.WriteLine($"first duplicate index: {FindFirstDuplicateIndex(test, 44)}");
		Console.WriteLine($"last duplicate index: {FindLastDuplicateIndex(test, 44)}");

		int[] nums = { 1, 2, 3, 4, 7, 6, 5 };
		Console.WriteLine($"first decreasing index: {FindDecreasingIndex(nums)}");
		Console.ReadKey();

	}

	public static int BinarySearchRecusive(int target, int[] nums)
	{
		return BinarySearchRecusive(target, nums, 0, nums.Length - 1);
	}

	private static int BinarySearchRecusive(int target, int[] nums, int leftIndex, int rightIndex)
	{
		if (leftIndex > rightIndex)
		{
			return -1;  // when target is less than smallest number or bigger than biggest number
		}

		int mid = leftIndex + (rightIndex - leftIndex) / 2;

		if (nums[mid] == target)
		{
			return mid;
		}
		else if (nums[mid] < target)
		{
			return BinarySearchRecusive(target, nums, mid + 1, rightIndex);
		}
		else
		{
			return BinarySearchRecusive(target, nums, leftIndex, mid - 1);
		}
	}


	public static int BinarySearchIterative(int target, int[] arr)
	{
		int left = 0;
		int right = arr.Length - 1;

		while (left <= right)
		{
			int mid = (left + right) / 2;   //may 2 large int plus, stackoverflow

			if (arr[mid] == target)
			{
				return mid;
			}
			else if (arr[mid] > target)
			{
				right = mid - 1;
			}
			else
			{
				left = mid + 1;
			}
		}
		return -1;   // doesn't have target
	}


	/*1. Find first/last instance's index of a number in sorted array where duplicates are allowed.
	e.g. find first/last 44
	find key occurrence: lastIndex - firstIndex + 1;
	*/
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

			// 44,44,44,55. 44 == pervious 44 and != next 55
			if (arr[mid] == key && arr[mid - 1] == arr[mid])  //find target
			{
				if (arr[mid] == arr[mid + 1]) // not last target
				{
					leftIndex = mid + 1;
					continue;
				}
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
