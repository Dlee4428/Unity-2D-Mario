using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DataNode
{
    public enum ValueType { NONE, INTEGER, FLOAT, VECTOR2 };

    private object value;
    private ValueType type;

    public void Assign(int v)
    {
        if(type == ValueType.NONE || type == ValueType.INTEGER || type == ValueType.FLOAT)
        {
            type = ValueType.INTEGER;
            value = v;
        }
    }

    public void Assign(float v)
    {
        if (type == ValueType.NONE || type == ValueType.INTEGER || type == ValueType.FLOAT)
        {
            type = ValueType.FLOAT;
            value = v;
        }
    }

    public void Assign(Vector2 v)
    {
        if (type == ValueType.NONE || type == ValueType.VECTOR2)
        {
            type = ValueType.VECTOR2;
            value = v;
        }
    }

    public static explicit operator int(DataNode node)
    {
        if (node.type == ValueType.INTEGER || node.type == ValueType.FLOAT)
            return (int)node.value;
        else
            return 0;
    }

    public static explicit operator float(DataNode node)
    {
        if (node.type == ValueType.INTEGER || node.type == ValueType.FLOAT)
            return (float)node.value;
        else
            return 0;
    }

    public static explicit operator Vector2(DataNode node)
    {
        if (node.type == ValueType.VECTOR2)
            return (Vector2)node.value;
        else
            return Vector2.zero;
    }

}