public class MinHeap
{
    private readonly List<int> _list;

    public MinHeap()
    {
        _list = new List<int>();
    }

    public void Add(int data)
    {
        _list.Add(data);
        BubbleUp(_list.Count - 1);
    }

    public void Remove(int data)
    {
        int index = _list.IndexOf(data);
        (_list[index], _list[_list.Count - 1]) = (_list[_list.Count - 1], _list[index]);
        _list.RemoveAt(_list.Count - 1);
        BubbleDown(index);
    }

    public int Peek()
    {
        return _list[0];
    }

    private void BubbleUp(int index)
    {
        if (index <= 0) return;

        int parentIndex = index / 2;
        if (_list[index] < _list[parentIndex])
        {
            (_list[index], _list[parentIndex]) = (_list[parentIndex], _list[index]);
            BubbleUp(parentIndex);
        }
    }

    private void BubbleDown(int index)
    {
        int left = index * 2 + 1;
        int right = index * 2 + 2;

        if(left >= _list.Count)
        {
            if (right >= _list.Count) return;

            if(_list[index] > _list[right])
            {
                (_list[index], _list[right]) = (_list[right], _list[index]);
                BubbleDown(right);
            }
        } 
        else
        {
            if (right >= _list.Count)
            {
                if (_list[index] > _list[left])
                {
                    (_list[index], _list[left]) = (_list[left], _list[index]);
                    BubbleDown(left);
                }
            }
            else
            {
                if(_list[left] < _list[right] && _list[left] < _list[index])
                {
                    (_list[index], _list[left]) = (_list[left], _list[index]);
                    BubbleDown(left);
                } else if(_list[right] < _list[left] && _list[right] < _list[index])
                {
                    (_list[index], _list[right]) = (_list[right], _list[index]);
                    BubbleDown(right);
                }
            }
        }
    }
}