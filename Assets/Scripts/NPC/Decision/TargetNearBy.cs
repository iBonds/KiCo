using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/NearBy")]
public class TargetNearBy : Decision
{
    public string target;
    public override bool Decide(Controller controller)
    {
        return controller.range.InRange(target);
    }
}
