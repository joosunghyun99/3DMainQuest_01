using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [SerializeField] private int targetScore = 30;
    [SerializeField] private GameObject spawner;
    private int currentScore = 0;

    public int timeRecord = 9999;
    public int timeLimit = 100;

    public float sec = 0;
    public int min = 0;

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Time.timeScale = 0.0f;
        min = 0;
        sec = 0;
        currentScore = 0;
    }

    private void Update()
    {
        sec += Time.deltaTime;

        if (timeLimit <= sec + (min * 60))
        {
            GameOver();
        }
        else if (sec >= 60.0f)
        {
            min += 1;
            sec = 0;
        }
    }

    public void StartGame()
    {
        min = 0;
        sec = 0;
        currentScore = 0;
        Time.timeScale = 1.0f;
        UIManager.Instance.ResetUI(targetScore);
        spawner.GetComponent<Spawner>().StartRandomSpawn(targetScore);
    }

    public void GameOver() 
    {
        Time.timeScale = 0.0f;
        if ((min*60)+sec < timeRecord) 
        {
            timeRecord = (min * 60) + (int)sec;
        }
        UIManager.Instance.GameOver();
    }

    public void UpdateCoinCount() 
    {
        currentScore++;
        if (currentScore >= targetScore) 
        {
            GameOver();
        }
        UIManager.Instance.UpdateScore(currentScore,targetScore);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
