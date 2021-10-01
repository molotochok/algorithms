private static void Permutations(char[] s, int l, int r)
{
    if(l == r)
    {
        Console.WriteLine(new string(s));
        return;
    }

    for(int i = l; i <= r; i++)
    {
        (s[i], s[l]) = (s[l], s[i]);
        Permutations(s, l + 1, r);
        (s[l], s[i]) = (s[i], s[l]);
    }
}

/* 
Example input:
  abc

Example output:
  abc
  acb
  bac
  bca
  cba
  cab
*/