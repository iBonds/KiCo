using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
	public Transform player;
	private Vector3 camOffSet;
	[Range(0.01f, 1.0f)]
	public float smoothness = 0.75f;
	// Start is called before the first frame update
	void Start()
	{
		camOffSet = transform.position - player.position;
	}

	// Late update is called once per frame
	void LateUpdate()
	{
		Vector3 newPos = player.position + camOffSet;
		transform.position = Vector3.Slerp(transform.position, newPos, smoothness);
	}
}