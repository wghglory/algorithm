using System;
using System.Collections.Generic;

class Program
{
	//Sample Input, find start with
	//add hack
	//add hackerrank
	//find hac
	//find hak

	//Sample Output
	//2
	//0
	static HashSet<string> Names = new HashSet<string>();
	public static void AddName(string name)
	{
		Names.Add(name);
	}

	public static int CountNames(string search)
	{
		int count = 0;
		foreach (var n in Names)
		{
			if (n.StartsWith(search))
			{
				count++;
			}
		}
		return count;
	}


	static void Main(string[] args)
	{
		string input = "";
		while ((input = Console.ReadLine()) != null)
		{

			if (!string.IsNullOrEmpty(input.Trim()))
			{
				if (input.IndexOf("add ") != -1)  // add new contact
				{
					Names.Add(input.Replace("add ", ""));
				}
				else if (input.IndexOf("find ") != -1)
				{
					Console.WriteLine(CountNames(input.Replace("find ", "")));
				}
			}

		}

	}

}

