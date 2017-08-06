using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Buttons
{
    Right,
    Left
}

public enum Condition
{
    GreatherThan,
    LessThan
}

[System.Serializable]
public class InputAxisState
{
    public string axisName;
    public float offValue;
    public Buttons button;
    public Condition condition;

    public bool value
    {
        get {
            var val = Input.GetAxis(axisName);

            switch(condition)
            {
                case Condition.GreatherThan:
                    return val > offValue;
                break;
                case Condition.LessThan:
                    return val < offValue;
                break;
            }

            return false;
        }
    }
}


public class InputManager : MonoBehaviour {
       
    public InputAxisState[] inputs;
    public InputState inputState;

    void Start () {
		
	}
    
    void Update () {
        foreach (var input in inputs)
        {
            inputState.SetButtonState(input.button, input.value);
        }
	}
}
