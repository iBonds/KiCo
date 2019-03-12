using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/Look")]
public class LookDecision : Decision
{
    public string target;
    public bool sees;

    public override bool Decide(Controller controller)
    {
        return look(controller);
    }

    private bool look(Controller controller)
    {
        sees = controller.eyes.sees(target);
        return sees;
    }
}
