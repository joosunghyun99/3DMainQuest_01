using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text resultText;

    private void Awake()
    {
        base.Awake();
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
}
