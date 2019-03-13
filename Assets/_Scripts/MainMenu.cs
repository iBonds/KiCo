using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame()
	{
        //SceneManager.LoadScene("level_1");
        GameManager.instance.PlayGame();
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
