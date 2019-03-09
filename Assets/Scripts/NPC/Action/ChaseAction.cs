using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Actions/Chase")]
public class ChaseAction : Action
{
    public string chase_target;

    public override void Act(Controller controller)
    {
        UnityEngine.AI.NavMeshAgent agent = controller.agent;
        Eyes eyes = controller.eyes;

        if (eyes.sees(chase_target))
        {
            Vector3 target_pos = eyes.position(chase_target);
            //controller.transform.LookAt(target_pos);
            if (agent.isStopped)
                agent.isStopped = false;

            agent.SetDestination(target_pos);
        }
    }
}
