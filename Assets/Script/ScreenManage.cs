using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManage : MonoBehaviour
{
    #region PUBLIC_VARS
    public GameObject gameScreen;
    public DrawManager drawManager;
    public Tap tap;
    public Glass glass;
    public GameObject GlassObj;
    public GameObject Star1, Star2, Star3;
    public Slider inkBar;
    public Canvas StartCanvas;
    #endregion


    #region PRIVATE_VARS
    float decreaseRate = 30.0f;
    float count;
    private bool isDragging = false;
    private Vector3 initialPosGlass;
    private Quaternion initialRotaationGlass;
    Vector3 lastPosition;
   
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        count = 100;
        initialPosGlass = GlassObj.gameObject.transform.position;
        initialRotaationGlass = GlassObj.gameObject.transform.rotation;
        StartCanvas.gameObject.SetActive(true);
        gameScreen.SetActive(false);
        inkBar.value = count;
        inkBar.onValueChanged.AddListener(OnSliderValueChanged);
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
        gameScreen.SetActive(true);
        StartCanvas.gameObject.SetActive(false);

    }


    public void RestartButton()
    {
        tap.RefillWater();
        inkBar.value = 100;

        glass.ResetTheCount();
        NumberOfStars.instance.ScoreWhenGameOver();
        Star3.gameObject.SetActive(true);
        Star2.gameObject.SetActive(true);
        Star1.gameObject.SetActive(true);
        GlassObj.transform.position = initialPosGlass;
        GlassObj.transform.rotation = initialRotaationGlass;
        drawManager.DestroyCreatedLines();

    }

    #endregion

    #region PRIVATE_FUNCTIONS

   

    private void OnSliderValueChanged(float newValue)
    {
        count = newValue;
    }

    private void StarsOnScreen()
    {
        //Debug.Log(inkBar.value);
        NumberOfStars.instance.AddScore(inkBar.value);
        if (count < 70)
        {
            Star3.gameObject.SetActive(false);

        }
        if (count < 40)
        {
            Star2.gameObject.SetActive(false);
        }
        if (count < 15)
        {
            Star1.gameObject.SetActive(false);
        }
    }

    #endregion

}
