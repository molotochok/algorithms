// https://www.hackerrank.com/challenges/one-month-preparation-kit-bomber-man/problem?h_l=interview&playlist_slugs%5B%5D=preparation-kits&playlist_slugs%5B%5D=one-month-preparation-kit&playlist_slugs%5B%5D=one-month-week-three

public static List<string> bomberMan(int n, List<string> grid)
{
    if(n <= 1)
        return grid;
    
    if(n % 2 == 0) {
        return FullGrid(grid.Count, grid[0].Length);
    }
    
    if(n != 3 && (n - 3) % 4 == 0) {
        return bomberMan(3, grid);
    }
    
    if(n != 5 && (n - 5) % 4 == 0) {
        return bomberMan(5, grid);
    }
    
    var arr = InitialGrid(grid);
    PlantAndDestroy(arr, n);
    return FinalGrid(arr);
}

private static List<string> FullGrid(int rows, int cols) 
{
    var res = new List<string>();
    
    for(int i = 0; i < rows; i++) {
        var sb = new System.Text.StringBuilder();
        for(int j = 0; j < cols; j++) {
            sb.Append('O');
        }
        res.Add(sb.ToString());
    }
    
    return res;
}

private static List<int[]> InitialGrid(List<string> grid)
{
    var arr = new List<int[]>();

    for (int i = 0; i < grid.Count; i++)
    {
        arr.Add(new int[grid[i].Length]);
        for (int j = 0; j < grid[i].Length; j++)
        {
            arr[i][j] = grid[i][j] == 'O' ? 1 : -1;
        }
    }

    return arr;
}

private static void PlantAndDestroy(List<int[]> arr, int n)
{
    for (int k = 2; k <= n; k++)
    {
        for (int i = 0; i < arr.Count; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                if (arr[i][j] == -2)
                {
                    arr[i][j] = -1;
                }
                else if (arr[i][j] == -1)
                {
                    arr[i][j] = 2;
                }
                else if (arr[i][j] == 0)
                {
                    arr[i][j] = -1;

                    if (i + 1 < arr.Count && arr[i + 1][j] != 0)
                        arr[i + 1][j] = -2;

                    if (i - 1 >= 0 && arr[i - 1][j] != -1)
                        arr[i - 1][j] = -1;

                    if (j + 1 < arr[i].Length && arr[i][j + 1] != 0)
                        arr[i][j + 1] = -2;

                    if (j - 1 >= 0 && arr[i][j - 1] != -1)
                        arr[i][j - 1] = -1;
                } 
                else
                {
                    arr[i][j]--;
                }
            }
        }
    }
}

private static List<string> FinalGrid(List<int[]> arr)
{
    var res = new List<string>();

    for (int i = 0; i < arr.Count; i++)
    {
        var sb = new System.Text.StringBuilder();
        for (int j = 0; j < arr[i].Length; j++)
        {
            sb.Append(arr[i][j] == -1 ? '.' : 'O');
        }

        res.Add(sb.ToString());
    }

    return res;
}