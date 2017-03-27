//Given an array A[] and a number x, check for pair in A[] with sum as x
//arr[] = {1, 5, 7, -1, 5}, sum = 6; count should be 3
using System;
using System.Collections.Generic;

public class GetPairOfSum
{
	public static void Main(string[] args)
	{
		int[] arr = { 1, 5, 7, -1, 5 };
		//int[] arr = { 1, 5, 7, -1, 6 };
		int sum = 6;


		Console.WriteLine(Has2Candidates(arr, sum));

		Has2CandidatesDic(arr, sum);

		CountBad(arr, sum);

		Console.ReadKey();
	}

	private static bool Has2Candidates(int[] arr, int sum)
	{
		//good for counting for no duplicate array

		//1) Sort the array in non - decreasing order.
		//2) Initialize two index variables to find the candidate
		//	   (a) Initialize first to the leftmost index: l = 0
		//	   (b) Initialize second  the rightmost index: r = ar_size - 1
		//3) Loop while l < r.
		//	  (a) If(A[l] + A[r] == sum)  then return true
		//	  (b) Else if (A[l] + A[r] < sum) then l++
		//    (c)Else r--
		//4) No candidates in whole array


		//Time Complexity: Depends on what sorting algorithm we use.
		//Merge Sort or Heap Sort then O(nlogn) in worst case. Quick Sort then O(n ^ 2) in worst case.
		//Space Complexity: Again, depends on sorting algorithm. O(n) for merge sort and O(1) for Heap Sort.


		Array.Sort(arr);
		int left = 0;
		int right = arr.Length - 1;

		while (left < right)
		{
			if (arr[left] + arr[right] == sum)
			{
				//Console.WriteLine($"{sum} = {arr[left]} + {arr[right]}");
				//left++;
				return true;
			}
			else if (arr[left] + arr[right] > sum)
			{
				right--;
			}
			else
			{
				left++;
			}
		}
		return false;

	}

	private static void Has2CandidatesDic(int[] arr, int sum)
	{
		//store arr element to dictionary, and check sum-arr[i], if it is a key in dictionary

		//Time Complexity: O(n)
		//Auxiliary Space: O(R) where R is range of integers.

		Dictionary<int, bool> dic = new Dictionary<int, bool>();
		int count = 0;

		for (int i = 0; i < arr.Length; i++)
		{
			int temp = sum - arr[i];

			if (dic.ContainsKey(temp))
			{
				count++;
				Console.WriteLine($"sum {sum} = {arr[i]} + {temp}");
			}
			dic[arr[i]] = true;
		}
		Console.WriteLine($"totalCount is {count}");

	}

	private static int CountBad(int[] arr, int sum)
	{

		// Prints number of pairs in arr[0..n-1] with sum equal
		// to 'sum'


		int count = 0;// Initialize result

		// Consider all possible pairs and check their sums
		for (int i = 0; i < arr.Length; i++)
			for (int j = i + 1; j < arr.Length; j++)
				if ((arr[i] + arr[j]) == sum)
					count++;

		Console.WriteLine($"Count of pairs is {count}");
		return count;

	}
}
