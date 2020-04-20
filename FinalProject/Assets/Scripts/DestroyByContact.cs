using System.Collections;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	//public GameObject bolt;
	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;

	private GameController gameController;
	private int lives;


	void Start()
	{

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boundary") || other.CompareTag("Enemy") || other.CompareTag("Pickup"))
		{
			return;
		}

		if (explosion != null)
		{
		 Instantiate(explosion, transform.position, transform.rotation);
		 
      	}

		if (other.tag == "Player")
		{
            gameController.lives = gameController.lives - 1;
		    gameController.SetLivesText();

			if (gameController.lives == 0)
			{
				Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
				Destroy(other.gameObject);
				gameController.GameOver();
			}
		}


		gameController.AddScore(scoreValue);
		Destroy(gameObject);
		
	}
}
