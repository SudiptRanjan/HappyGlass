using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StarCount
{
   public int starsCount =3;

}

public class LevelManager : MonoBehaviour
{
    public List<StarCount> starCountsList;
    public List<GameObject> levelPrefabs;
    public GameObject Star1, Star2, Star3;
    public static LevelManager instance;
    private float counter;
    private int currentLevelIndex = 0;

    private void Start()
    {
        instance = this;
    }

    private void Update()
    {
        Debug.Log(ScreenManage.instance.starsActCount);

        //SetTheStars();

    }

    public void LevelStarts()
    {
        ActivateLevel(currentLevelIndex);

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

        SaveStars(currentLevelIndex);

    }

    private void SetTheStars(int index)
    {
        //counter = ScreenManage.instance.inkBar.value;
        counter = starCountsList[index].starsCount;
        //Debug.Log(counter);

        if (counter == 3)
        {
            Star3.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star1.gameObject.SetActive(true);
        }
         if(counter == 2)
        {
           
            Star3.gameObject.SetActive(false);
            Star2.gameObject.SetActive(true);
            Star1.gameObject.SetActive(true);

        }
       if( counter == 1)
        {
            Star3.gameObject.SetActive(false);
            Star2.gameObject.SetActive(false);
            Star1.gameObject.SetActive(true);

        }

        if (counter == 0)
        {
            Star3.gameObject.SetActive(false);
            Star2.gameObject.SetActive(false);
            Star1.gameObject.SetActive(false);

        }
        //if (counter < 40)
        //{

        //}
        //if (counter < 0.1)
        //{

        //}
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
        //if (index >= 0 && index < starCountsList.Count)
        PlayerPrefs.SetInt("Level" + index + "Stars", starCountsList[index].starsCount);
    }

    private void LoadStars(int index)
    {
        //if (index >= 0 && index < starCountsList.Count)
        starCountsList[index].starsCount = PlayerPrefs.GetInt("Level" + index + "Stars",0);
        //Debug.Log(starCountsList[index].starsCount);
    }
}
