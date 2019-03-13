using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour, IDamageable
{
    public State currentState;
    public bool can_pick_up;
    public bool can_damage;
    public float health;
    public float eyes_range = 10f;
    public Eyes eyes;
    public State remainState;
    public bool is_disabled = false;
    public Range range;
    public Rigidbody rb;
    public float character_speed = 1;
    public List<Transform> waypoints;
    public NavMeshAgent agent;
    public Action interaction;

    
    [HideInInspector] public bool is_picked_up = false;
    [HideInInspector] public GameObject player_mouth;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        eyes = GetComponentInChildren<Eyes>();
        range = GetComponentInChildren<Range>();
        rb = GetComponent<Rigidbody>();
        player_mouth = GameObject.FindGameObjectWithTag("mouth");
    }

    void Update()
    {
        if (is_disabled || is_picked_up)
        {
            if (is_picked_up)
                transform.localPosition = Vector3.zero;
            if (!agent.isStopped)
                agent.isStopped = true;
            return;
        }
        currentState.UpdateState(this);
    }

    public void TransitionToState(State nextState)
    {
        if (nextState == null)
            return;

        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }

    public void Interaction()
    {
        if(interaction)
            interaction.Act(this);
    }

    public void doDamage()
    {
        if (can_damage)
        {
            health--;
            onDeath();
        }
    }

    public void onDeath()
    {
        Destroy(transform.gameObject);
    }
}
