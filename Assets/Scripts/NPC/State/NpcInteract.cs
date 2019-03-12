using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteract : MonoBehaviour
{

    
    Controller npc;

    private bool player_in_range = false;

    // Start is called before the first frame update
    void Start()
    {
        npc = GetComponentInParent<Controller>();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            player_in_range = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            player_in_range = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("z") && player_in_range)
        {
            npc.Interaction();
        }
    }
}
