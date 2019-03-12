using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    bool in_range;
    Controller controller;

    private void Start()
    {
        controller = GetComponentInParent<Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            in_range = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown("z") && in_range)
            controller.Interaction();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            in_range = false;
        }
    }
}
