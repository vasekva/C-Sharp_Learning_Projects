using System;

public static class Detect_Pangram
{
    public static bool IsPangram(string str)
    {
        int[] ascii = new int[26];
        char[] strSymbols;

        str = str.ToUpper();
        strSymbols = str.ToCharArray();
        foreach(char c in strSymbols)
        {
            if (c >= 65 && c <= 90)
                ascii[(int)c - 65] += 1;
        }
        foreach(int num in ascii)
        {
            if (num == 0)
                return (false);
        }
        return(true);
    }
}