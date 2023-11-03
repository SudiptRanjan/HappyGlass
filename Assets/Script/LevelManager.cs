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
    public int currentLevelCount = 0;
    public NoOfStars noOfStars;


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

    public void LevelStarts()
    {
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);

    }

    public void NextLevel()
    {
        ScreenManage.instance.NexLevelBotton();
        SaveStars(currentLevelCount);

        DeactivateLevel(currentLevelCount);
        currentLevelCount++;

        if (currentLevelCount >= levelPrefabs.Count)
        {
            return;
        }
        //else
        //{
        //    return null;
        //}
        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);
    }

    public void PreviousLevel()
    {
        ScreenManage.instance.NexLevelBotton();
        SaveStars(currentLevelCount);

        DeactivateLevel(currentLevelCount);

        currentLevelCount--;

        if (currentLevelCount < 0)
        {
            Debug.Log("No previous levels available.");
            currentLevelCount = 0;
            return;
        }

        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);

    }

    public void LoadLevel(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= levelPrefabs.Count)
        {
            Debug.LogWarning("Invalid level index");
            return;
        }
        SaveStars(currentLevelCount);

        DeactivateLevel(currentLevelCount);

        currentLevelCount = levelIndex;
        

        ActivateLevel(currentLevelCount);
        LoadStars(currentLevelCount);

    }


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
        starCountsList[index].starsCount = PlayerPrefs.GetInt("Level" + index + "Stars",0);
    }
}
