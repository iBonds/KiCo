using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class State : ScriptableObject
{

    public Color state_color = Color.grey;

    public abstract void UpdateState(Controller controller);
}
