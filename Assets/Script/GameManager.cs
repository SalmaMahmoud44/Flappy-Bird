using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject startPanel;
    bool gameStarted = false;
    public Spawner spawner;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        startPanel.SetActive(true);
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Pause();

        if (spawner != null)
            spawner.enabled = false;

    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        gameStarted = true;

        startPanel.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        foreach (var pipe in pipes)
        {
            Destroy(pipe.gameObject);
        }

        if (spawner != null)
            spawner.enabled = true;

        Time.timeScale = 1f;
        player.enabled = true;

    }
    private void Update()
    {
        
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !gameStarted)
        {
             Play();
        }
    }
    private void Start()
    {

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
        gameStarted = false;

        if (spawner != null)
            spawner.enabled = false;
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

    }
}
