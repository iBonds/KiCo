using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Actions/Roam")]
public class RoamAction : Action
{

    public Vector3[] waypoints;
    public int waypoint = 0;

    public override void Act(Controller controller)
    {
        Roam(controller);
    }
    
    private void Roam(Controller controller)
    {
        if (controller.agent.isStopped)
        {
            controller.agent.isStopped = false;
        }

        if (!controller.agent.pathPending && controller.agent.remainingDistance < 0.5f)
        {
            controller.agent.destination = waypoints[waypoint];
            waypoint = (waypoint == waypoints.Length - 1) ? 0 : waypoint + 1;
        }
    }
}
