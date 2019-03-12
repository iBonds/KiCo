using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamFollow : MonoBehaviour
{
    public Transform player;
    public float camSpeed = 10;

    Vector3 offset;

    void Start()
    {
        offset = transform.position- player.position;
    }

    void LateUpdate()
    {
        Vector3 rot = player.position - transform.position;
        rot.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rot), camSpeed * Time.deltaTime);

        Vector3 newPos = player.position - player.forward * offset.z + player.up * offset.y;
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * camSpeed);
    }
}
