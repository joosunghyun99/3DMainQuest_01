using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text resultText;

    [SerializeField] private GameObject resultPanel;
    private int timeLimit;

    private float sec = 0;
    private int min = 0;

    private void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        timeLimit = GameManager.Instance.timeLimit;
    }

    private void Update()
    {
        sec = GameManager.Instance.sec;
        min = GameManager.Instance.min;

        float temp = timeLimit - (sec + (min * 60));

        int remainMin = (int)(temp / 60);
        int remainSec = (int)(temp % 60);

        timeText.text = string.Format("{0:D2}:{1:D2}", (int)remainMin, (int)remainSec);
    }

    public void UpdateScore(int currentScore, int targetScore) 
    {
        scoreText.text = $"{currentScore.ToString()}/{targetScore.ToString()}";
    }

    public void PopUp(GameObject panel)
    {
        if (panel.activeSelf == true)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void GameOver() 
    {
        resultPanel.SetActive(true);
        int record = GameManager.Instance.timeRecord;

        int recordMin = (int)(record / 60);
        int recordSec = (int)(record % 60);

        resultText.text = $"HighScore : {string.Format("{0:D2}:{1:D2}", (int)recordMin, (int)recordSec)}\n" +
            $"YourRecord : {string.Format("{0:D2}:{1:D2}", (int)min, (int)sec)}";
    }

    public void ResetUI(int targetScore) 
    {
        resultPanel.SetActive(false);
        min = 0;
        sec = 0.0f;    
        timeText.text = string.Format("{0:D2}:{1:D2}", (int)min, (int)sec);

        UpdateScore(0, targetScore);
    }
}
