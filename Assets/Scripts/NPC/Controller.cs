using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    public State currentState;
    public Eyes eyes;
    public State remainState;
    public bool is_disabled = false;
    public Range range;
    public Rigidbody rb;
    public float character_speed = 1;
    public List<Transform> waypoints;
    public NavMeshAgent agent;


    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        eyes = GetComponent<Eyes>();
        range = GetComponentInChildren<Range>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (is_disabled)
            return;
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
