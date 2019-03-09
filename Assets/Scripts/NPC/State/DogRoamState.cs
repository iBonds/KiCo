using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/State/DogRoam")]
public class DogRoamState : State
{
    public RoamAction action;

    private void OnEnable()
    {
        action = ScriptableObject.CreateInstance<RoamAction>(); ; 
    }
    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public override void UpdateState(Controller controller)
    {
        throw new System.NotImplementedException();
    }
}
