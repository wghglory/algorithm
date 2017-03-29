using System;
using System.Collections.Generic;

class Program
{
	static void Main(string[] args)
	{
		Console.Write(IsBalancedBracket("(fads)[]{}"));
		Console.ReadKey();
	}

	// amazon online assessment 2017-3-3 seattle
	public static bool IsBalancedBracket(string str)
	{
		int len = str.Length;
		Stack<char> s = new Stack<char>();

		for (int i = 0; i < len; i++)
		{
			if (str[i] == '(' || str[i] == '{' || str[i] == '[')  // push open bracket
			{
				s.Push(str[i]);
			}
			else if (str[i] == ')' || str[i] == '}' || str[i] == ']')  // detect close bracket
			{
				if (s.Count == 0 || s.Peek() != Getpair(str[i]))  // check if peek match opener or not
				{
					return false;
				}
				else  // match and pop up
				{
					s.Pop();
				}
			}
		}
		return s.Count == 0 ? true : false;  // if nothing in stack left, match successfully
	}

	public static char Getpair(char s)
	{
		if (s == ')')
		{
			return '(';
		}
		else if (s == '}')
		{
			return '{';
		}
		else
		{
			return '[';
		}
	}
}
