using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class NumberOfStars : MonoBehaviour
{

    #region PUBLIC_VARS
    #endregion
    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion

    public TextMeshProUGUI myScoreText;
    public static NumberOfStars instance;
    float score;

    public void Start()
    {
        instance = this;
        score = 0;
        myScoreText.text = score.ToString();

    }
    public void Update()
    {
        myScoreText.text = score   +"  %";
    }

    public void AddScore(float udscore)
    {
        score = udscore;
        //HighestPercetage.instance.UpdateHighScore(score);
    }


    public void ScoreWhenGameOver()
    {
        score = 0;
    }
}