using UnityEngine;
using System.Collections;

public class Yarn : MonoBehaviour, IPickupable, IDamageable {

  public bool isPickedUp;
  public int maxHP;
  public bool inRange;
  GameObject kico;
  GameObject yarn;

  void Start() {
    isPickedUp = false;
    maxHP = 1;
    kico = GameObject.FindWithTag("mouth");
    yarn = this.transform.parent.gameObject;
  }

  void Update() {
    if(Input.GetKeyDown("z") && isPickedUp)
    putDown();
    if (Input.GetKeyDown("z") && inRange)
    {
      if (!isPickedUp)
      pickUp();
    }
    if(maxHP == 0)
    onDeath();
  }

  public void doDamage() {
    maxHP--;
  }
  public void onDeath() {
    Destroy(yarn);
  }
  public void pickUp() {
    isPickedUp = true;
    yarn.GetComponent<Rigidbody>().isKinematic = true;
    yarn.transform.SetParent(kico.transform);
    yarn.transform.position = kico.transform.position;
  }
  public void putDown() {
    isPickedUp = false;
    yarn.GetComponent<Rigidbody>().isKinematic = false;
    yarn.transform.SetParent(null);
  }

  //if KiCo stays in contact with the gameobject, make inRange true
  void OnTriggerStay(Collider c) {
    if(c.tag == "Player") {
      if(Vector3.Distance(c.transform.position, yarn.transform.position) < 5) {
        inRange = true;
      }
    }
    if(c.tag == "QuestCat") {
      doDamage();
    }
  }

  //resets inRange to false
  void OnTriggerExit(Collider c)
  {
    inRange = false;
  }

}
