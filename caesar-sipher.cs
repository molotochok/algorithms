// input: 
//  s: abcdefghijklmnopqrstuvwxyz
//  k: 3
// output: defghijklmnopqrstuvwxyzabc

public static string CaesarCipher(string s, int k)
{
    const int alphabetCharCount = 26;

    k %= 26;

    if (k == 0) return s;

    var res = new StringBuilder();

    int limit, newChar, startChar;
    foreach (var c in s)
    {
        if (!char.IsLetter(c))
        {
            res.Append(c);
            continue;
        }

        startChar = char.IsLower(c) ? 'a' : 'A';
        limit = startChar + alphabetCharCount;

        newChar = c + k;
        if (newChar >= limit)
        {
            newChar = startChar + (newChar - limit);
        }

        res.Append((char)(newChar));
    }

    return res.ToString();
}
