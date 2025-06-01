using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : Score
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreMultiPlier;
    private bool shouldCount = true;
    private float score;

    private void Count ()
    {
        score += Time.deltaTime * scoreMultiPlier;
        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void Update()
    {
        if (!shouldCount) { return;  }
        Count();
    }

    public void CantCount()
    {
        shouldCount = false;
        SetNewBestScore(Mathf.FloorToInt(score));
    }
}
