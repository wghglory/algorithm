using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		//Find the Running Median [1,2,3,6,18,8]
		//1. sort
		//2. calculate based on odd / even total number

		List<double> inputlist = new List<double>();

		string str;
		while ((str = Console.ReadLine()) != null)
		{
			int input = int.Parse(str);
			inputlist.Add(input);
			double[] arr = inputlist.ToArray();

			Array.Sort(arr);

			if (arr.Length % 2 == 1)
			{  //odd
				Console.WriteLine(arr[arr.Length / 2]);
			}
			else
			{
				Console.WriteLine((arr[arr.Length / 2 - 1] + arr[arr.Length / 2]) / 2);
			}
		}
	}
}
