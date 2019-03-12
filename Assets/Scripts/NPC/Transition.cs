using UnityEngine;
using System.Collections;

[System.Serializable]
public class Transition
{
    public Transition(Decision decision, State true_state, int true_prio, State false_state, int false_prio)
    {
        this.decision = decision;
        this.true_prio = true_prio;
        this.true_state = true_state;
        this.false_prio = false_prio;
        this.false_state = false_state;
    }
    public Transition() { }


    public Decision decision;
    public int true_prio = 0;
    public State true_state;
    public int false_prio = 0;
    public State false_state;
}
