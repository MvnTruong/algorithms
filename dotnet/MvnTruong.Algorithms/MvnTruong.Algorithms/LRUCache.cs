namespace MvnTruong.Algorithms;

public class LRUCache(int capacity)
{
    private readonly Dictionary<int, LinkedListNode<(int, int)>> _cache = new(capacity);
    private readonly LinkedList<(int, int)> _queue = [];

    public int Get(int key)
    {
        if (!_cache.TryGetValue(key, out LinkedListNode<(int, int)>? node))
            return -1;
        
        _queue.Remove(node);
        _queue.AddFirst(node);
        return node.Value.Item2;
    }
    
    public void Put(int key, int value)
    {
        if (!_cache.ContainsKey(key) && _cache.Count >= capacity)
        {
            LinkedListNode<(int, int)> delete = _queue.Last!;
            _queue.RemoveLast();
            _cache.Remove(delete.Value.Item1);
        }

        LinkedListNode<(int, int)> node = new((key, value));
        _queue.AddFirst(node);
        _cache[key] = node;
    }
}
