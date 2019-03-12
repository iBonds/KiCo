using UnityEngine;
using System.Collections;
using UnityEngine.UI;   //Allows us to use UI.
using UnityEngine.SceneManagement;

//Player inherits from MovingObject, our base class for objects that can move, Enemy also inherits from this.
public class PlayerController2 : MonoBehaviour
{
	public int playerLives;
	public Text livesText;
	private float speed;	//Movement speed

	//Start overrides the Start function of MovingObject
	void Start()
	{
		playerLives = 3;
		speed = 1f;

		//Set the player lives to 3 everytime a level begins
		livesText.text = "Lives: " + playerLives;
	}

	private void Update()
	{
		//Player Movement Controls
		transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);

		//Check if the game is over when lives == 0
		CheckIfGameOver();
	}

	//AttemptMove overrides the AttemptMove function in the base class MovingObject
	//AttemptMove takes a generic parameter T which for Player will be of the type Wall, it also takes integers for x and y direction to move in.
	void AttemptMove<T>(int xDir, int yDir)
	{
		/*//Every time player moves, subtract from food points total.
		food--;

		//Update food text display to reflect current score.
		foodText.text = "Food: " + food;

		//Call the AttemptMove method of the base class, passing in the component T (in this case Wall) and x and y direction to move.
		base.AttemptMove<T>(xDir, yDir);

		//Hit allows us to reference the result of the Linecast done in Move.
		RaycastHit2D hit;

		//If Move returns true, meaning Player was able to move into an empty space.
		if (Move(xDir, yDir, out hit))
		{
			//Call RandomizeSfx of SoundManager to play the move sound, passing in two audio clips to choose from.
			SoundManager.instance.RandomizeSfx(moveSound1, moveSound2);
		}

		//Since the player has moved and lost food points, check if the game has ended.
		CheckIfGameOver();

		//Set the playersTurn boolean of GameManager to false now that players turn is over.
		GameManager.instance.playersTurn = false;*/
	}


	//OnCantMove overrides the abstract function OnCantMove in MovingObject.
	//It takes a generic parameter T which in the case of Player is a Wall which the player can attack and destroy.
	void OnCantMove<T>(T component)
	{
		/*//Set hitWall to equal the component passed in as a parameter.
		Wall hitWall = component as Wall;

		//Call the DamageWall function of the Wall we are hitting.
		hitWall.DamageWall(wallDamage);

		//Set the attack trigger of the player's animation controller in order to play the player's attack animation.
		animator.SetTrigger("playerChop");*/
	}


	//OnTriggerEnter2D is sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter(Collider other)
	{
		//Check if the tag of the trigger collided with is Exit.
		if (other.tag == "Exit")
		{
			SceneManager.LoadScene("LevelComplete");
		}

		//Check if the tag of the trigger collided with is Dog.
		else if (other.tag == "Dog")
		{
			LoseLife();
		}

		//Check if the tag of the trigger collided with is NPC.
		/*else if (other.tag == "NPC" && Input.GetKey("z"))
		{
			other.GameObject.DialogueTrigger.TriggerDialogue();
		}*/
	}


	//Restart reloads the scene when called.
	private void Restart()
	{
		//Load the last scene loaded, in this case Main, the only scene in the game.
		SceneManager.LoadScene(1);
	}


	//LoseFood is called when an enemy attacks the player.
	//It takes a parameter loss which specifies how many points to lose.
	public void LoseLife()
	{
		//Subtract lost food points from the players total.
		playerLives--;

		//Update the food display with the new total.
		livesText.text = "Lives: " + playerLives;

		//Check to see if game has ended.
		CheckIfGameOver();
	}


	//CheckIfGameOver checks if the player is out of food points and if so, ends the game.
	private void CheckIfGameOver()
	{
		//Check if food point total is less than or equal to zero.
		if (playerLives <= 0)
		{
			//Call the PlaySingle function of SoundManager and pass it the gameOverSound as the audio clip to play.
			//SoundManager.instance.PlaySingle(gameOverSound);

			//Stop the background music.
			//SoundManager.instance.musicSource.Stop();

			// Disable the player.
			enabled = false;

			//Call the GameOver function of GameManager.
			//GameManager.instance.GameOver();
		}
	}
}