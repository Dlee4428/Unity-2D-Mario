using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Data
{
    private Dictionary<string, DataNode> data = new Dictionary<string, DataNode>();

    public DataNode this[string name]
    {
        get
        {
            DataNode node;
            data.TryGetValue(name, out node);
            return node;
        }
        set
        {
            data.Add(name, value);
        }
    }
}
