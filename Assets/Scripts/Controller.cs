using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputComponent : MonoBehaviour
{
    public abstract void Gather(Data data);

    public abstract void Input();
}

public abstract class ControlComponent : MonoBehaviour
{

    public abstract void Gather(Data data);

    public abstract void Execute();
}

public class Controller : MonoBehaviour
{
    [Header("Inputs")]
    [SerializeField] private List<InputComponent> inputs = new List<InputComponent>();
    [Header("Controls")]
    [SerializeField] private List<ControlComponent> controls = new List<ControlComponent>();

    private Data data = new Data();

    // Start is called before the first frame update
    void Start()
    {
        InputComponent[] inputComponents = GetComponents<InputComponent>();
        for (int i = inputComponents.Length - 1; i >= 0; i--)
        {
            if (!inputs.Contains(inputComponents[i]))
                inputs.Add(inputComponents[i]);
        }

        ControlComponent[] controlComponents = GetComponents<ControlComponent>();
        for (int j = controlComponents.Length - 1; j >= 0; j--)
        {
            if (!controls.Contains(controlComponents[j]))
                controls.Add(controlComponents[j]);
        }

        foreach (InputComponent component in inputs)
            component.Gather(data);

        foreach (ControlComponent component in controls)
            component.Gather(data);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (InputComponent component in inputs)
            component.Input();

        foreach (ControlComponent component in controls)
            component.Execute();
    }
}
