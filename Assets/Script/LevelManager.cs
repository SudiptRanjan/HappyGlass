using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StarCount
{
   public int starsCount ;

}

public class LevelManager : MonoBehaviour
{
    public List<StarCount> starCountsList;
    public List<GameObject> levelPrefabs;
    public GameObject Star1, Star2, Star3;
    public static LevelManager instance;
    public int currentLevelIndex = 0;
    public NoOfStars noOfStars;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        //Debug.Log(ScreenManage.instance.starsActCount);

        //SetTheStars();
        SetTheStars(currentLevelIndex);

    }

    public void LevelStarts()
    {
        ActivateLevel(currentLevelIndex);
        LoadStars(currentLevelIndex);

    }

    public void NextLevel()
    {
        ScreenManage.instance.NexLevelBotton();
        SaveStars(currentLevelIndex);

        DeactivateLevel(currentLevelIndex);
        currentLevelIndex++;

        if (currentLevelIndex >= levelPrefabs.Count)
        {
            return;
        }
        ActivateLevel(currentLevelIndex);
        LoadStars(currentLevelIndex);
    }

    public void PreviousLevel()
    {
        ScreenManage.instance.NexLevelBotton();
        SaveStars(currentLevelIndex);

        DeactivateLevel(currentLevelIndex);

        currentLevelIndex--;

        if (currentLevelIndex < 0)
        {
            Debug.Log("No previous levels available.");
            currentLevelIndex = 0;
            return;
        }

        ActivateLevel(currentLevelIndex);
        LoadStars(currentLevelIndex);

    }

    private void SetTheStars(int index)
    {
        int counter = starCountsList[index].starsCount;
        //print(counter);
        //int counter = ScreenManage.instance.starsActCount;
        //noOfStars.leveData[index].stars = ScreenManage.instance.starsActCount;
        //Debug.Log(counter);
        //if (index < starCountsList.Count)
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
        starCountsList[index].starsCount = PlayerPrefs.GetInt("Level" + index + "Stars",0);
    }
}
