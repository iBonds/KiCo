using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KiCo/Actions/PickUp")]
public class PickUpAction : Action
{
    bool x = false;
    GameObject player_mouth;

    private void OnEnable()
    {
        player_mouth = GameObject.FindWithTag("mouth");
    }
    public override void Act(Controller controller)
    {
        if (x)
            PutDown(controller);
        else
            PickUp(controller);
    }

    void PickUp(Controller controller)
    {
        controller.is_picked_up = true;
        controller.GetComponent<Rigidbody>().isKinematic = true;
        controller.transform.SetParent(player_mouth.transform);
        controller.transform.position = player_mouth.transform.position;
    }

    void PutDown(Controller controller)
    {
        controller.is_picked_up = false;
        controller.GetComponent<Rigidbody>().isKinematic = false;
        controller.transform.SetParent(null);
    }
}
