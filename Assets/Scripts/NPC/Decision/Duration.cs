using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "KiCo/Decisions/Duration")]
public class Duration : Decision
{
    public float time_since_last_update;
    public float duration;
    public override bool Decide(Controller controller)
    {
        if(duration == 0f)
        {
            return false;
        } else
        {
            bool res = Time.fixedTime >= time_since_last_update + duration;
            if(res)
                time_since_last_update = Time.fixedTime;
            return res;
        }
    }

    private void Awake()
    {
        time_since_last_update = 0f;
    }

    private void OnEnable()
    {
        time_since_last_update = 0f;
    }
}
