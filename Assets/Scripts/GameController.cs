using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtHighScore;
    public TextMeshProUGUI txtGameOver;


    public Transform spawnPoint;
    public Transform cactusHolder;
    public GameObject LoseGame;
    public GameObject btnPlay;

    public int score;
    public int highScore;

    public bool isPause = false;

    public float timeToSpawn;

    public List<GameObject> cactus;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        score = 0;
        txtHighScore.text = "Score: 0";
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            txtHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        }
        else
        {
            highScore = 0;
            txtHighScore.text = "High Score: 0"; 
        }
    }

    void Update()
    {
        UpdateUI();
        SpawnCactus();
    }

    void SpawnCactus()
    {
        timeToSpawn -= Time.deltaTime;
        if(timeToSpawn < 0) 
        {
            Instantiate(cactus[1], spawnPoint.position, Quaternion.identity, cactusHolder);
            timeToSpawn = 5;
        }
    }

    void UpdateUI()
    {
        txtScore.text = "Score: " + score.ToString();
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", score);
            txtHighScore.text = "High Score: " + highScore.ToString();
        }
    }

    public void PauseGame()
    {
        if (isPause)
        {
            Time.timeScale = 1;
            isPause = false;
        }
        else
        {
            Time.timeScale = 0;
            isPause = true;
        }
        
    }
    public void PlayeGame()
    {
        Time.timeScale = 1;
        isPause = false;
    }
    public void Replay()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Lose()
    {
        LoseGame.SetActive(true);
        btnPlay.SetActive(false);
        Time.timeScale = 0;
        isPause = true;
    }
}
