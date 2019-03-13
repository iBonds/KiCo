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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (GameObject.FindWithTag("lvl") != null)
        {
            levelScript = GameObject.FindWithTag("lvl").GetComponent<LevelManager>();
        }
        else
            levelScript = null;
    }

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
			//levelScript.GamePlay();

			if (levelScript.levelComplete)
			{
				currlvl++;
				playerLives = 3;
                if (SceneManager.sceneCountInBuildSettings == currlvl)
                    GameDone();
                else{
                    SceneManager.LoadScene(currlvl);
                }
                
			} else if (levelScript.is_dead)
            {
                playerLives--;
                if (playerLives != 0)
                {
                    SceneManager.LoadScene(currlvl);
                    levelScript.is_dead = false;
                }
            }

			if (playerLives == 0)
			{
				GameOver();
			}
        }
        else
        {
            //levelScript = 
        }
	}
		
	void InitializeGame()
	{
		currlvl = 1;
		SceneManager.LoadScene("main_menu");
	}

    void GameDone()
    {
        levelScript = null;
        SceneManager.LoadScene("main_menu");
    }

	public void PlayGame()
	{
		//If the current level is the start menu, initialize currlvl to 1 for 1st level
		//Otherwise current level is an actual game level and leave as is
		if (currlvl == 1)
		{
            currlvl = 2;
		}
		playerLives = 3;
		//Load the current level and get the level manager
		SceneManager.LoadScene(currlvl);
		//If not in the main menu
		//Get a component reference to the attached level manager script
		//levelScript = SceneManager.GetSceneAt(0).GetRootGameObjects()[0].GetComponent<LevelManager>();
	}

	public void GameOver()
	{
		SceneManager.LoadScene("main_menu");

    }
}
