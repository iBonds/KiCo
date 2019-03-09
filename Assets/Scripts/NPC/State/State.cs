using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KiCo/State")]
public class State : ScriptableObject
{

    public Action[] actions;
    public Transition[] transitions;
    public Color sceneGizmoColor = Color.grey;

    public void UpdateState(Controller controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
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
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decision = transitions[i].decision.Decide(controller);

            if (decision)
            {
                controller.TransitionToState(transitions[i].true_state);
            }
            else
            {
                controller.TransitionToState(transitions[i].false_state);
            }
        }
    }


}
