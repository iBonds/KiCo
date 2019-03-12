using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/Location")]
public class Location : Decision
{
    public Vector3 location;

    [SerializeField]
    private Vector3 current_location;

    public override bool Decide(Controller controller)
    {
        current_location = controller.transform.position;
        return Vector3.SqrMagnitude(location - current_location) < 1;
    }
}
