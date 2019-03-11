//Modeled after singleton pattern
//Sources used: Unity 2d Roguelike tutorial Game Manager pages
		//Unity tanks tutorial Game Manager
		//wiki.unity3d.com/index.hp/Singleton
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
//	public static GameManager : MonoBehaviour //Instance {get; private set;}

	public int playerLives;
	public int currlvl;
	//private Vector3 playerPosition;
	public static GameManager instance = null;	//Static instance of GameManager
	public LevelManager levelScript;

	private void Awake()
	{
		//If there is no GameManager, make a new one
		if (instance == null)
		{
			//Set instance to this
			instance = this;
		}
		//If instance already exists and it's not this
		else if (instance != this)
		{
			//Destroy this (the about to be made GameManager)
			Destroy(gameObject);
		}

		//Don't destroy when reloading the scene
		DontDestroyOnLoad(gameObject);

		//Intialize the game, beginning at Main Menu
		InitializeGame();
	}

	void Update()
	{
		//If the level is the main menu, there is no level manager
		//If there is a level script, play the game and track progress
		if (levelScript != null) 
		{
			levelScript.GamePlay();

			if (levelScript.levelComplete)
			{
				currlvl++;
				playerLives = 3;
				SceneManager.LoadScene(currlvl);
			}

			if (playerLives == 0)
			{
				GameOver();
			}
		}
	}
		
	void InitializeGame()
	{
		currlvl = 0;
		SceneManager.LoadScene("MainMenu");
	}

	void PlayGame()
	{
		//If the current level is the start menu, initialize currlvl to 1 for 1st level
		//Otherwise current level is an actual game level and leave as is
		if (currlvl == 0)
		{
			currlvl = 1;
		}
		playerLives = 3;
		//Load the current level and get the level manager
		SceneManager.LoadScene(currlvl);
		//If not in the main menu
		//Get a component reference to the attached level manager script
		levelScript = GetComponent<LevelManager>();
	}

	public void GameOver()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
