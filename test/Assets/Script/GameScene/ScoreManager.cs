using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private int totalScore = 0;

    [SerializeField]
    private Text score;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateScoreText();
    }

    public void AddScore(int score)
    {
        totalScore += score;
    }

    private void UpdateScoreText()
    {
        score.text = "ëçé˚âv : " + totalScore.ToString();
    }


}
