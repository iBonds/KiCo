using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KiCo/Actions/PickUp")]
public class PickUpAction : Action
{

    //public GameObject player_mouth;

    private void OnEnable()
    {
        //player_mouth = GameObject.FindWithTag("mouth");
    }

    private void Awake()
    {
        
    }
    public override void Act(Controller controller)
    {
        if (controller.is_picked_up)
            PutDown(controller);
        else
            PickUp(controller);
    }

    void PickUp(Controller controller)
    {
        controller.is_picked_up = true;
        //controller.GetComponent<Rigidbody>().isKinematic = true;
        controller.transform.SetParent(controller.player_mouth.transform);
        //controller.transform.position = player_mouth.transform.position;
        //controller.transform.position = Vector3.zero;
        controller.transform.localPosition = Vector3.zero;

        AudioSource source = controller.GetComponent<AudioSource>();
        if(source != null)
        {
            source.mute = true;
        }
    }

    void PutDown(Controller controller)
    {
        controller.is_picked_up = false;
        //controller.GetComponent<Rigidbody>().isKinematic = false;
        controller.transform.SetParent(null);
        AudioSource source = controller.GetComponent<AudioSource>();
        if (source != null)
        {
            source.mute = false;
        }
    }
}
