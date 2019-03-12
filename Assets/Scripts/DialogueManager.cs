using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;
	public string[] sentencesArr;
	public GameObject canvas;
	public int currsentence;

    // Start is called before the first frame update
    void Start()
    {
		sentencesArr = new string[5];
		currsentence = 0;
    }

	public void StartDialogue (Dialogue dialogue)
	{
		canvas = GameObject.FindWithTag("Canvas");
		canvas.GetComponent<Canvas>().enabled = true;

		nameText.text = dialogue.name;

		Array.Clear(sentencesArr, 0, 4);

		int i = 0;

		foreach (string sentence in dialogue.sentences)
		{
			sentencesArr[i] = sentence;
			i++;
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentencesArr.Length == 0)
		{
			EndDialogue();
			return;
		}

		string sentence = sentencesArr[currsentence];
		dialogueText.text = sentence;
	}

	void EndDialogue()
	{
		Debug.Log("End of conversation");
		canvas.GetComponent<Canvas>().enabled = false;
	}
}
