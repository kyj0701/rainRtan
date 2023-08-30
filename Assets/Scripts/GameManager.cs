using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject rain;
    public Text scoreText;
    public Text timeText;

    public GameObject panel;

    public static GameManager I;

    int totalScore = 0;

    float limit = 30.0f;

    void Awake()
    {
        I = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0.0f, 0.5f);
        InitGame();
    }

    void InitGame()
    {
        Time.timeScale = 1.0f;
        limit = 5.0f;
        totalScore = 0;
    }

    void MakeRain()
    {
        Instantiate(rain);
    }

    // Update is called once per frame
    void Update()
    {
        limit -= Time.deltaTime;

        if (limit < 0)
        {
            limit = 0.0f;
            panel.SetActive(true);
            Time.timeScale = 0.0f;
        }

        timeText.text = limit.ToString("N2");
    }

    public void AddScore(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}