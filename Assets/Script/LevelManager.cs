using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[System.Serializable]
public class StarCount
{
   public int starsCount ;

}

public class LevelManager : MonoBehaviour
{
    #region PUBLIC_VARS
    public List<StarCount> starCountsList;
    public List<GameObject> levelPrefabs;
    public List<GameObject> listOfStarsOnMenu;
    public List<GameObject> hintLineList;
    public GameObject Star1, Star2, Star3;
    public static LevelManager instance;
    public int currentLevelCount = 0;
    public GameObject disableNextLevelButton;
    public bool isLevelCompleted = false;
    #endregion

    #region PRIVATE_VARS
     int counter;
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i <= starCountsList.Count; i++)
        {
            LoadStars(i);
        }
        DisplayStars();
    }
    private void Update()
    {
        SetTheStars();
        // UnlockNextLevel();
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    public void LevelStarts()
    {
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
    }
  
    public void NextLevel()
    {
        SaveStars(currentLevelCount);
        ScreenManage.instance.NexLevelBotton();
        UnlockNextLevel();
        DeactivateLevel(currentLevelCount);
        DisplayStars();

        currentLevelCount++;

        if (currentLevelCount >= levelPrefabs.Count)
        {
            // SaveStars(currentLevelCount);
            DrawManager.drawManagerInstance.istapOff = false;
            Debug.Log("There are no next level");
            // currentLevelCount = levelPrefabs.Count - 1; 
            return;
        }
        
        // if(isLevelCompleted)
        // {
        //      ActivateLevel(currentLevelCount);
        //      LoadStars(currentLevelCount);
        //      DisableNextButton();
        // }
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
        DisableNextButton();
    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
        {
            Debug.Log("null");
            return;
        }
        // Debug.Log(" The Current level " + levelIndex);

        SaveStars(currentLevelCount);
        DeactivateLevel(currentLevelCount);
        currentLevelCount = levelIndex;
        DisplayStars();
        // Debug.Log(" The after Current level " + levelIndex);
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
        DisableNextButton();

    }

    public void HintMethod()
    {
        hintLineList[currentLevelCount].SetActive(true);
        // Debug.Log("Hint On");
    }
    public void HintMethodOff()
    {
        hintLineList[currentLevelCount].SetActive(false);
        // Debug.Log("Hint off");

    }

    
    public void UnlockNextLevel()
    {
        if (counter == 3)
        {
            isLevelCompleted = true;
            Debug.Log("You have unlocked the next level" );
            // Debug.Log(cou);
        }
        else
        {
            Debug.Log("You have to get 3 stars to unlock the next level" + counter);
        }
    }

    #endregion

    #region PRIVATE_FUNCTIONS
    private void SetTheStars()
    {
         counter = ScreenManage.instance.starsActCount;
        //  Debug.Log(counter);
        //int counter = starCountsList[index].starsCount;
        Star1.SetActive(counter >= 1);
        Star2.SetActive(counter >= 2);
        Star3.SetActive(counter == 3);
        
    }


    private void ActivateLevel(int index)
    {
        if (index >= 0 && index < levelPrefabs.Count)
        {
            levelPrefabs[index].SetActive(true);
        }
    }

    private void DeactivateLevel(int index)
    {
        if (index >= 0 && index < levelPrefabs.Count)
        {
            levelPrefabs[index].SetActive(false);
        }
    }

    private void SaveStars(int index)
    {
        starCountsList[index].starsCount = ScreenManage.instance.starsActCount;
        if (index >= 0 && index < starCountsList.Count)
        {  
            PlayerPrefs.SetInt("Level" + index + "Stars", starCountsList[index].starsCount);

        }
    }

    private void LoadStars(int index)
    {
        if (index >= 0 && index < starCountsList.Count)
        {
            starCountsList[index].starsCount = PlayerPrefs.GetInt("Level" + index + "Stars", 0);
            //Debug.Log(starCountsList[index].starsCount);
        }

    }

    private void DisableNextButton()
    {
        if (currentLevelCount == levelPrefabs.Count - 1)
        {
            disableNextLevelButton.SetActive(false);
            Debug.Log(currentLevelCount + "        " + levelPrefabs.Count);
        }
        else
        {
            disableNextLevelButton.SetActive(true);
        }
    }
     
    private void DisplayStars()
    {
        for (int i = 0; i < levelPrefabs.Count; i++)
        {
            int stars = starCountsList[i].starsCount;
            Transform buttonTransform = listOfStarsOnMenu[i].transform;

            //print(" buttonTransform.childCount ==" + buttonTransform.childCount);
            for (int j = 0; j < buttonTransform.childCount; j++)
            {
                Transform starImage = buttonTransform.GetChild(j);
                //Debug.Log(j);
                if (j < stars)
                {
                    starImage.gameObject.SetActive(true);
                }
                else
                {
                    starImage.gameObject.SetActive(false);
                }
                //Debug.Log("Level == " + i + "========No.Stars=======" + stars);
            }
        }
    }
    #endregion

}


