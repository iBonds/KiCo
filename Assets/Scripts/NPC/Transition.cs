using UnityEngine;
using System.Collections;

[System.Serializable]
public class Transition
{
    public Decision decision;
    public int true_prio = 0;
    public State true_state;
    public int false_prio = 0;
    public State false_state;
}
