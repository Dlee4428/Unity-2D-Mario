using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlVector2ToTranslate : ControlComponent
{
    [Header("Speed")]
    [SerializeField] private float speed = 1;
    [Header("Data")]
    [SerializeField] private string dataName = "inputVector2";

    private DataNode cachedVector;

    public override void Gather(Data data)
    {
        cachedVector = data[dataName];
    }

    public override void Execute()
    {
        transform.Translate((Vector2)cachedVector * speed);
    }
}
