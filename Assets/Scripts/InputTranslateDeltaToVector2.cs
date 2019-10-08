using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTranslateDeltaToVector2 : InputComponent
{
    [Header("Target")]
    [SerializeField] private Transform target;
    [Header("Data")]
    [SerializeField] private string dataName = "inputVector2";

    private DataNode cachedVector;

    public override void Gather(Data data)
    {
        data[dataName] = cachedVector = new DataNode();
    }

    public override void Input()
    {
        cachedVector.Assign((target.position - transform.position).normalized);
    }
}
