using UnityEngine;
using System.Collections;
using System;

[CreateAssetMenu(menuName = "KiCo/Actions/RunFrom")]
public class RunFromAction : Action
{
    public string tag_target;

    public override void Act(Controller controller)
    {
        RunFrom(controller);
    }

    private void RunFrom(Controller controller)
    {
        if (controller.range.InRange(tag_target))
        {
            if (!controller.agent.isStopped)
                controller.agent.isStopped = true;

            Vector3 direction = controller.transform.position - controller.range.Position(tag_target);
            controller.transform.LookAt(2 * direction);
            // transform.rotation = Quaternion.LookRotation(transform.position - target.position);
            direction.y = 0;
            controller.rb.MovePosition((controller.transform.position + direction) * Time.deltaTime * controller.character_speed);
        }
    }
}
