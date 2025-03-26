using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject startPanel;
    public Spawner spawner;
    private bool gameStarted = false;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        ResetGame();
        Pause();
    }

    private void Update()
    {
        if (!gameStarted && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            Play();
        }
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameStarted = true;

        startPanel.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);

        foreach (var pipe in FindObjectsOfType<Pipes>())
        {
            Destroy(pipe.gameObject);
        }

        if (spawner != null)
            spawner.enabled = true;

        Time.timeScale = 1f;
        player.enabled = true;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        gameStarted = false;
        Pause();

        if (spawner != null)
            spawner.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void ResetGame()
    {
        startPanel.SetActive(true);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        gameStarted = false;

        Time.timeScale = 0f;
        player.enabled = false;

        if (spawner != null)
            spawner.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
}
