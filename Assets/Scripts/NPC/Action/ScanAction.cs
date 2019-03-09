using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Actions/Scan")]
public class ScanAction : Action
{
    public override void Act(Controller controller)
    {
        controller.transform.Rotate(0, 60 * Time.deltaTime, 0);
    }
}
