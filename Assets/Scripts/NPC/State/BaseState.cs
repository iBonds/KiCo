using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/State/State")]
public class BaseState : State
{
    public Action[] actions;
    public Transition[] transitions;
    

    public override void UpdateState(Controller controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
        state_color = Color.grey;
    }

    private void DoActions(Controller controller)
    {
        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(Controller controller)
    {
        int index = 0;
        int prio = -1;
        bool state = false;

        for (int i = 0; i < transitions.Length; i++)
        {
            bool decision = transitions[i].decision.Decide(controller);

            if (decision)
            {
                if (transitions[i].true_prio > prio)
                {
                    state = decision;
                    index = i;
                }
                    
            }
            else
            {
                if (transitions[i].false_prio > prio)
                {
                    state = decision;
                    index = i;
                }
            }
        }

        if (state)
            controller.TransitionToState(transitions[index].true_state);
        else
            controller.TransitionToState(transitions[index].false_state);

    }

}
