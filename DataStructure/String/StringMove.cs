// move string to right n. e.g. str = abcde, n = 2 => deabc
private static string Movestring(string str, int n)
{
	// str.length > n
	int len = str.Length;
	char[] charset = new char[len];
	for (int i = 0; i < len; i++)
	{
		if (i < len - n)  // abc
		{
			charset[n + i] = str[i];
		}
		else // de
		{
			charset[i - (len - n)] = str[i];
		}

	}

	return new string(charset);
}
