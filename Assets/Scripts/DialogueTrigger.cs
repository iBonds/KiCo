using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKeyDown("z"))
		{
			TriggerDialogue();
		}
	}
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}