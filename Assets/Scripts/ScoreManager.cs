using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    public static bool gameOver;
    public Text scoreText;
    public Text totalScoreText;
    public GameObject gameOverPanel;
    public GameObject startPanel;

    void Awake()
    {
        Time.timeScale = 0;
        gameOver = false;
        gameOverPanel.SetActive(false);
    }
    void Update()
    {
        scoreText.text = score.ToString();
        if(gameOver)
            gameOverPanel.SetActive(true);
            totalScoreText.text = score.ToString();
    }

    public void OnClickRetryButton()
    {
        SceneManager.LoadScene(0);
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickStartButton()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
