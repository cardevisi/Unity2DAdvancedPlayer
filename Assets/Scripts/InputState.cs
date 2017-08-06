using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonState {
    public bool value;
    public float holdTime = 0;
}

public class InputState : MonoBehaviour {

    private Dictionary<Buttons, ButtonState> buttonsStates = new Dictionary<Buttons, ButtonState>();
	
	void Start () {
		
	}
	
	void Update () {


    }

    public void SetButtonState(Buttons key, bool value)
    {
        if(!buttonsStates.ContainsKey(key))
        {
            buttonsStates.Add(key, new ButtonState());
        }

        var state = buttonsStates[key];
         if(state.value && !value )
        {
            Debug.Log("Button " + key + " Released " + state.holdTime);
            state.holdTime = 0;
        } else if (state.value && value)
        {
            state.holdTime += Time.deltaTime;
            Debug.Log("Button " + key + " down " + state.holdTime);
        }

        state.value = value;
    }

    public bool GetButtonValue(Buttons key)
    {
        if (buttonsStates.ContainsKey(key))
        {
            return buttonsStates[key].value;
        } else
        {
            return false;
        }
    }
}
