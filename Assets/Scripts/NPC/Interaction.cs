using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public bool in_range;
    bool to_interact;
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
            to_interact = true;
        else
            to_interact = false;
    }

    private void FixedUpdate()
    {
        if (to_interact)
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
