// LeetCode Problem : LRU Cache
// https://leetcode.com/problems/lru-cache/
// Related Topics : Hash Table, Linked List, Design, Doubly-Linked List

public class LRUCache
{
    private int _capacity;
    private Dictionary<int, ValueNode> _cache;
    private LinkedList<int> _freq;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
        _cache = new Dictionary<int, ValueNode>();
        _freq = new LinkedList<int>();
    }

    public int Get(int key)
    {
        bool hasKey = _cache.TryGetValue(key, out ValueNode target);
        if (!hasKey) return -1;

        _freq.Remove(target.KeyNode);
        _freq.AddLast(target.KeyNode);

        return target.Value;
    }

    public void Put(int key, int value)
    {
        bool hasKey = _cache.TryGetValue(key, out ValueNode target);

        if (hasKey)
        {
            target.Value = value;
            _freq.Remove(target.KeyNode);
            _freq.AddLast(target.KeyNode);
            _cache[key] = target;

            return;
        }

        if (_freq.Count < _capacity)
        {
            var newNode = new ValueNode(key, value);
            _cache[key] = newNode;
            _freq.AddLast(_cache[key].KeyNode);
        }
        else
        {
            var oldestNode = _freq.First;
            _freq.RemoveFirst();

            // Get 'oldest' key.
            var oldest = _cache[oldestNode.Value];
            _cache.Remove(oldest.KeyNode.Value);

            // Put new key and value.
            oldest.Value = value;
            oldest.KeyNode.Value = key;
            _cache[key] = oldest;
            _freq.AddLast(oldest.KeyNode);
        }
    }
}