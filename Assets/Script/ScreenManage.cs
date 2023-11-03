using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManage : MonoBehaviour
{
    #region PUBLIC_VARS
    public GameObject gameScreen;
    public DrawManager drawManager;
    public GameObject Star1, Star2, Star3;
    public Slider inkBar;
    public Canvas StartCanvas;
    public GameObject gameOverPanal;
    public Canvas homeCanvas;
    public GameObject winOverPanal;
    public static ScreenManage instance;
    public int starsActCount;
    #endregion



    #region PRIVATE_VARS
    float decreaseRate = 30.0f;
    float count;
    //int s = 3;
    private bool isDragging = false;
    Vector3 lastPosition;
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
       
        starsActCount = 3;
        instance = this;
        count = 100;
        StartCanvas.gameObject.SetActive(true);
        gameScreen.SetActive(false);
        inkBar.value = count;
        inkBar.onValueChanged.AddListener(OnSliderValueChanged);
        gameOverPanal.SetActive(false);
        winOverPanal.SetActive(false);
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
                isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {

            isDragging = false;
        }

       
        if (isDragging)
        {
            StarsOnScreen();
            //Debug.Log("The Dist Changes"+ Vector3.Distance(lastPosition, Input.mousePosition));
            if (Vector3.Distance(lastPosition,Input.mousePosition)>0.5f)
            {
                count -= decreaseRate * Time.deltaTime;
                inkBar.value = count;
            }
           
            lastPosition = Input.mousePosition;
        }

    }

    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS


    public void StartButton()
    {
        //gameScreen.SetActive(true);
        homeCanvas.gameObject.SetActive(true);
        StartCanvas.gameObject.SetActive(false);
        //LevelManager.instance.LevelStarts();

    }

    public void HomeButton()
    {
        LevelManager.instance.LevelStarts();
        homeCanvas.gameObject.SetActive(true);
        gameScreen.SetActive(false);
        NexLevelBotton();
        //LevelManager.instance.LevelStarts();
    }

    public void LevelButtons()
    {
        homeCanvas.gameObject.SetActive(false);
        gameScreen.SetActive(true);

    }

    public void RestartButton()
    {
        Events.toRefillWater();
        inkBar.value = 100;
        Events.toResetTheCount();
        NumberOfStars.instance.ScoreWhenGameOver();
        Star3.gameObject.SetActive(true);
        Star2.gameObject.SetActive(true);
        Star1.gameObject.SetActive(true);
        Events.toResetTheGlassPosition();
        drawManager.DestroyCreatedLines();
        gameOverPanal.SetActive(false);
        winOverPanal.SetActive(false);
        Time.timeScale = 1;
    }

    public void NexLevelBotton()
    {
        Events.toRefillWater();
        inkBar.value = 100;
        Events.toResetTheCount();
        NumberOfStars.instance.ScoreWhenGameOver();

        Star3.gameObject.SetActive(true);
        Star2.gameObject.SetActive(true);
        Star1.gameObject.SetActive(true);

        drawManager.DestroyCreatedLines();
        gameOverPanal.SetActive(false);
        winOverPanal.SetActive(false);
        Time.timeScale = 1;
    }

    public void GamOverPopUp()
    {
        gameOverPanal.SetActive(true);
        Time.timeScale = 0;

    }

    public void GamWinPopUp()
    {
        winOverPanal.SetActive(true);
        Time.timeScale = 0;

    }
    #endregion


    #region PRIVATE_FUNCTIONS

    private void OnSliderValueChanged(float newValue)
    {
        count = newValue;
    }

    private void StarsOnScreen()
    {
        NumberOfStars.instance.AddScore(inkBar.value);
        if (count > 70)
        {
            starsActCount = 3;
        }
        if (count < 70)
        {
            Star3.gameObject.SetActive(false);
            starsActCount = 2;
        }
        if (count < 40)
        {
            Star2.gameObject.SetActive(false);
            starsActCount = 1;
        }

        if (count < 12)
        {
            Star1.gameObject.SetActive(false);
            starsActCount = 0;
        }
        if (count < 0.1)
        {
            //Star1.gameObject.SetActive(false);
            //starsActCount = 0;
            GamOverPopUp();
            //Invoke("GameOver", 8);
        }
    }

    //void GameOver()
    //{
    //    GamOverPopUp();
    //}

    #endregion

}
