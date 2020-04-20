using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip musicClipWin;
    public AudioClip musicClipLose;

    public GameObject[] hazards;
    public GameObject[] pickups;
    public Vector3 spawnValues;
    public int hazardCount;
    public int pickupCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text ScoreText;
    public Text restartText;
    public Text gameOverText;
    public Text livesText;

    private bool gameOver;
    private bool restart;
    public int score;
    public int lives;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        lives = 3;
        SetLivesText();
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            for (int i = 0; i < pickupCount; i++)
            {
                GameObject pickup = pickups[Random.Range(0, pickups.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(pickup, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'F' for Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= 200)
        {
            gameOverText.text = "You win! Game created by Vanessa Seymour.";
            restartText.text = "Press 'F' for Restart";
            gameOver = true;
            restart = true;

            musicSource.clip = musicClipWin;
            musicSource.Play();
        }
    }


    public void SetLivesText()
    {
        livesText.text = "Lives:" + lives.ToString();
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.text = "Game Over! Game created by Vanessa Seymour.";
            gameOver = true;

            musicSource.clip = musicClipLose;
            musicSource.Play();
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}