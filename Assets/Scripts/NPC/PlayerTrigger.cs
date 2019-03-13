using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
    public float timeLastHit = 0f;
    PlayerController player;
    FlashCanvas fc;
    private void Start()
    {
        player = GetComponentInParent<PlayerController>();
        // fc = GameObject.Find("Flash").GetComponent<FlashCanvas>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            player.doDamage();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Dog"))
        {
            player.doDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
    }
}
