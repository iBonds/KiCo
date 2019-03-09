using UnityEngine;
using System.Collections;

[System.Serializable]
public class Transition
{
    public Decision decision;
    public State true_state;
    public State false_state;
}
