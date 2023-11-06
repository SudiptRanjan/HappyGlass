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
    public GameObject Star1, Star2, Star3;
    public static LevelManager instance;
    public int currentLevelCount = 0;
    public NoOfStars noOfStars;
    #endregion


    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        //Debug.Log(ScreenManage.instance.starsActCount);

        //SetTheStars();
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
        currentLevelCount++;

        if (currentLevelCount >= levelPrefabs.Count)
        {
            Debug.Log("No next level");
            return;
        }
       
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
    }


    //public void PreviousLevel()
    //{
        //ScreenManage.instance.NexLevelBotton();
        //SaveStars(currentLevelCount);

        //DeactivateLevel(currentLevelCount);

        //currentLevelCount--;

        //if (currentLevelCount < 0)
        //{
        //    Debug.Log("No previous levels available.");
        //    currentLevelCount = 0;
        //    return;
        //}

        //ActivateLevel(currentLevelCount);
        //LoadStars(currentLevelCount);
    //}

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
        currentLevelCount = levelIndex ;
        //Debug.Log(" The after Current level " + levelIndex);
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);

    }

    public void LoadLevel1()
    {

        //if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
        //{
        //    Debug.Log("null index");
        //    return;
        //}
        //Debug.Log(" The Current level " + levelIndex);
        //SaveStars(currentLevelCount);
        //DeactivateLevel(currentLevelCount);
        //currentLevelCount = 5;
        ////Debug.Log(" The after Current level " + levelIndex);
        //ActivateLevel(currentLevelCount);
        //LoadStars(currentLevelCount);

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
            PlayerPrefs.SetInt("Level" + index + "Stars", starCountsList[index].starsCount);
    }

    private void LoadStars(int index)
    {
        if (index >= 0 && index < starCountsList.Count)
            starCountsList[index].starsCount = PlayerPrefs.GetInt("Level" + index + "Stars", 0);
    }
    #endregion


}
