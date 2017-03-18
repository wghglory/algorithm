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
		Console.ReadKey();
	}


	//find target index
	public static int BinarySearch(int target, int[] nums)
	{
		int floorIndex = -1;
		int ceilIndex = nums.Length;  //11

		while (floorIndex + 1 < ceilIndex)
		{
			int halfDistance = (ceilIndex - floorIndex) / 2;  //assume length 11, 5 is halfDistance

			int guessIndex = floorIndex + halfDistance;

			if (target == nums[guessIndex])
			{
				return guessIndex;
			}

			if (target < nums[guessIndex])  // target on left
			{
				Console.WriteLine($"<: guessIndex: {guessIndex}, floorIndex: {floorIndex}, ceilIndex: {ceilIndex}");
				ceilIndex = guessIndex;
			}
			else if (target > nums[guessIndex]) //target on right
			{
				Console.WriteLine($">: guessIndex: {guessIndex}, floorIndex: {floorIndex}, ceilIndex: {ceilIndex}");
				floorIndex = guessIndex;
			}



		}
		return -1;
	}
}
