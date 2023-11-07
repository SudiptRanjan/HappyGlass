using UnityEngine;
using System.Collections.Generic;

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
    public GameObject Star1, Star2, Star3;
    public static LevelManager instance;
    public int currentLevelCount = 0;

    #endregion


    #region PRIVATE_VARS
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
        SetTheStars(currentLevelCount);
        
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

        DeactivateLevel(currentLevelCount);
        DisplayStars();
        currentLevelCount++;

        if (currentLevelCount >= levelPrefabs.Count)
        {
            Debug.Log("No next level");
            return;
        }

        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
    }

    public void LoadLevel(int levelIndex)
    {

        if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
        {
            Debug.Log("null index");
            return;
        }
        //Debug.Log(" The Current level " + levelIndex);
        SaveStars(currentLevelCount);
        DeactivateLevel(currentLevelCount);
        currentLevelCount = levelIndex;
        DisplayStars();
        //Debug.Log(" The after Current level " + levelIndex);
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);

    }

    #endregion

    #region PRIVATE_FUNCTIONS
    private void SetTheStars(int index)
    {
        int counter = starCountsList[index].starsCount;
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

    private void DisplayStars()
    {
        for (int i = 0; i < levelPrefabs.Count; i++)
        {
            int stars = starCountsList[i].starsCount;
            Transform buttonTransform = listOfStarsOnMenu[i].transform;

            print(" buttonTransform.childCount ==" + buttonTransform.childCount);
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
                Debug.Log("Level == " + i + "========No.Stars=======" + stars);
            }
        }

    }




    #endregion

}


