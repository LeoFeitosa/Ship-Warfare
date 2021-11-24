using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreNumbers;

    public void SetScore(int score)
    {
        int currentScore = 0;
        if (System.Int32.TryParse(scoreNumbers.text, out currentScore))
        {
            currentScore += score;
        }

        scoreNumbers.text = (currentScore).ToString();
    }
}
