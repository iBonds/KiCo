using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/NavAgentDone")]
public class NavAgentDone : Decision
{
    public float distance = 0.5f;

    public override bool Decide(Controller controller)
    {
        return controller.agent.remainingDistance <= distance;
    }
}
