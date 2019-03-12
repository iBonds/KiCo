using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Actions/Move")]
public class MoveAction : Action
{
    public Vector3 location;
    public float speed = 1;
    public override void Act(Controller controller)
    {
        Move(controller);
    }

    private void Move(Controller controller)
    {
        if (controller.agent.isStopped)
            controller.agent.isStopped = false;
        controller.agent.speed = speed;
        controller.agent.SetDestination(location);
    }
}
