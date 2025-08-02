using System;
using System.Collections.Generic;

public static class SetsAndMaps
{
    public static string[] FindPairs(string[] words)
    {
        HashSet<string> seen = new HashSet<string>();
        List<string> result = new List<string>();

        foreach (var word in words)
        {
            if (word.Length != 2 || word[0] == word[1]) continue; 

            string reversed = new string(new[] { word[1], word[0] });

            if (seen.Contains(reversed))
            {
                result.Add($"{reversed} & {word}"); 
            }

            seen.Add(word); 
        }

        return result.ToArray();
    }


    public static Dictionary<string, int> SummarizeDegrees(string filePath)
    {
        Dictionary<string, int> degreeCounts = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filePath))
        {
            string[] columns = line.Split(',');

            if (columns.Length < 4)
                continue; 

            string degree = columns[3].Trim();

            if (string.IsNullOrEmpty(degree))
                continue;

            if (degreeCounts.ContainsKey(degree))
            {
                degreeCounts[degree]++;
            }
            else
            {
                degreeCounts[degree] = 1;
            }
        }

        return degreeCounts;
    }
    public static bool IsAnagram(string word1, string word2)
    {
        string cleaned1 = word1.Replace(" ", "").ToLower();
        string cleaned2 = word2.Replace(" ", "").ToLower();

        if (cleaned1.Length != cleaned2.Length)
            return false;

        Dictionary<char, int> letterCounts = new Dictionary<char, int>();

        foreach (char c in cleaned1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }


        foreach (char c in cleaned2)
        {
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;

            if (letterCounts[c] < 0)
                return false;
        }

        return true;
    }
}
