private bool IsUniqueChars(String str)
{
    if (str.Length > 256)
    {
        return false;
    }

    var charSet = new bool[256];

    for (var i = 0; i < str.Length; i++)
    {
        int val = str[i];

        if (charSet[val])
        {
            return false;
        }
        charSet[val] = true;
    }

    return true;
}
