using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
	public int progressInLevel;	//Progress in "stages"
	public int amountGiven;		//Amount of collectible given to target npc
	public int level;				//Current level, taken from game manager
	public bool atExit;			//If the player is at the exit point in the level
	public bool levelComplete;		//Has the player completed all stages (ie. reached max progressInLevel)

	public GameObject collectible;	//Collectible for fetch quest (ie. yarn, etc.)
	public int targetAmount;		//Amount needed in fetch quest for level
	public GameObject levelExit;	//What gameObject is designated as the exit point

	public GameObject[] enemies = new GameObject[5];	//All the enemies in the level, placed in accordingly
	public GameObject[] npcs = new GameObject[5]; 		//All the npcs in the level, placed in accordingly
	public Checkpoints checkpoints;
	public GameObject currCP;	//All the checkpoints in the level, placed in accordingly
	public DialogueManager dManage;

	// Start is called before the first frame update
	void Start()
	{
		level = GameManager.instance.currlvl;
		atExit = false;
		amountGiven = 0;
		progressInLevel = 0;
		levelComplete = false;


		//Start Gameplay for the level
		StartCoroutine (GamePlay());
	}


	public IEnumerator GamePlay()
	{
		currCP = checkpoints.returnCurrCP();
		switch (progressInLevel)
		{
			case 0:	//First stage of progress
			{
				//Check if the first enemy has been placated
				//Check if the first checkpoint trigger has been triggered
				//If both true, increment progress and destory trigger
				if (enemies[0] == null && currCP.name == "cp1")
				{
					progressInLevel++;
				}
				break;
			}
			case 1:	//Second Stage of Progress
			{
				//Once Kico gets close enough to first npc, trigger dialogue
				if (currCP.name == "cp2" && amountGiven == 0)
				{
					dManage.currsentence = 0;
					break;
				}
				else if (currCP.name == "cp2" && amountGiven == 1)
				{
					dManage.currsentence = 1;
					break;
				}
				else if (currCP.name == "cp2" && amountGiven == 2)
				{
					dManage.currsentence = 2;
					break;
				}
				else if (currCP.name == "cp2" && amountGiven == 3)
				{
					dManage.currsentence = 3;
					progressInLevel++;
					//access boxes
					break;
				}
				//Once all the collectibles for the quest have been collected
				//Increment progress
				break;
			}
			case 2:	//Third Stage of Progress
			{
				if (GameObject.FindWithTag("Player").transform.GetChild(0).tag == "kitten"
				&& atExit)
				{
					levelComplete = true;
					break;
				}
				break;
			}
			default:
			{
				Debug.Log("Error");
				break;
			}
		}
		if (levelComplete)
		{
			yield return null;
		}
		else
		{
			StartCoroutine (GamePlay());
		}
	}
}
