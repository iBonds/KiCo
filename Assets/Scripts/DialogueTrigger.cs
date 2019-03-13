using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue dialogue;
    public bool x;
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && Input.GetKeyDown("z"))
		{
            if (x)
                Clean();
            else
                TriggerDialogue();
		}
	}
	public void TriggerDialogue()
	{
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}

    public void Clean()
    {
        FindObjectOfType<DialogueManager>().Clean();
    }
}