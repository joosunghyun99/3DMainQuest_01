using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [SerializeField] private int targetScore = 30;
    [SerializeField] private GameObject spawner;
    private int currentScore = 0;

    private bool isGameOver = false;

    private void Awake()
    {
        base.Awake();
        Time.timeScale = 0.0f;
    }

    public void StartGame()
    {
        isGameOver = false;
        currentScore = 0;
        Time.timeScale = 1.0f;
        UIManager.Instance.UpdateScore(currentScore, targetScore);
        spawner.GetComponent<Spawner>().StartRandomSpawn(targetScore);
    }

    public void GameOver() 
    {
        isGameOver = true;
        Time.timeScale = 0.0f;
    }

    public void UpdateCoinCount() 
    {
        currentScore++;
        UIManager.Instance.UpdateScore(currentScore,targetScore);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
