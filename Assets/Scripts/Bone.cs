using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour, IPickupable {

	public bool isPickedUp;
	public bool inRange;
	GameObject kico;
	GameObject bone;

	// Start is called before the first frame update
	void Start() {
		isPickedUp = false;
		inRange = false;
		kico = GameObject.FindWithTag("mouth");
		bone = this.transform.parent.gameObject;
	}

	// Update is called once per frame
	void Update() {

		if(Input.GetKeyDown("z") && isPickedUp)
			putDown();
		if (Input.GetKeyDown("z") && inRange)
		{
			if (!isPickedUp)
				pickUp();
		}
	}

	//sets parent of gameObject as child of KiCo
	public void pickUp() {
		isPickedUp = true;
		bone.GetComponent<Rigidbody>().isKinematic = true;
		bone.transform.SetParent(kico.transform);
		bone.transform.position = kico.transform.position;
	}

	//resets parent of gameObject
	public void putDown() {
		isPickedUp = false;
		bone.GetComponent<Rigidbody>().isKinematic = false;
		bone.transform.SetParent(null);
	}

	//if KiCo stays in contact with the gameobject, make inRange true
	void OnTriggerStay(Collider c) {
		if(c.tag == "Player") {
			if(Vector3.Distance(c.transform.position, bone.transform.position) < 5) {
				inRange = true;
			}
		}
	}

	//resets inRange to false
	void OnTriggerExit(Collider c)
	{
		inRange = false;
	}
}
