using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/Look")]
public class LookDecision : Decision
{
    public string[] target_tags;

    public override bool Decide(Controller controller)
    {
        return look(controller);
    }

    private bool look(Controller controller)
    {
        return controller.eyes.sees(target_tags[0]);
    }
}
