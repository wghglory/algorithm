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
