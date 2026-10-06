public class Solution
{
    public int MaxVowels(string s, int k)
    {
        if (string.IsNullOrWhiteSpace(s) || k <= 0 || k > s.Length)
            return 0;

        int currentVowels = 0;
        for (int i = 0; i < k; i++)
        {
            if (IsVowel(s[i]))
                currentVowels++;
        }
        int maxVowels = currentVowels;
        for (int i = k; i < s.Length; i++)
        {
            if (IsVowel(s[i]))
                currentVowels++;
            if (IsVowel(s[i - k]))
                currentVowels--;

            maxVowels = Math.Max(maxVowels, currentVowels);
        }
        return maxVowels;
    }

    public bool IsVowel(char c)
    {
        return c == 'a' ||
               c == 'e' ||
               c == 'i' ||
               c == 'o' ||
               c == 'u';
    }
}