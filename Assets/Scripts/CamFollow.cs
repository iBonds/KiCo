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

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation( player.position - transform.position), camSpeed * Time.deltaTime);

        Vector3 newPos = player.position - player.forward * offset.z - player.up * offset.y;
        transform.position = Vector3.Slerp(transform.position, newPos, Time.deltaTime * camSpeed);
    }
}
