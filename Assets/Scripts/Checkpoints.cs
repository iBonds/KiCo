using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints: MonoBehaviour
{
	public bool activeCP = false;
	public static GameObject[] CPList;

	void Start() {
		CPList = GameObject.FindGameObjectsWithTag("CheckPoint");
	}

	/*void Update() {
		GameObject cp = returnCurrCP();
		Debug.Log(cp.name);
}*/
		void MakeCurrentCP() {
			foreach(GameObject checkpoint in CPList) {
				checkpoint.GetComponent<Checkpoints>().activeCP = false;
			}
			activeCP = true;
		}

		void OnTriggerEnter(Collider c) {
			if (c.tag == "Player") {
				MakeCurrentCP();
			}
		}

		public GameObject returnCurrCP() {
			foreach(GameObject checkpoint in CPList) {
				if(checkpoint.GetComponent<Checkpoints>().activeCP == true) {

					return checkpoint;
				}
			}
			return CPList[0];
		}
	}
