using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

   

    #region PUBLIC_VARS
    public List<GameObject> levelPrefabList;

    #endregion
    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void LevelChanege()
    {
        foreach(var level in levelPrefabList)
        {
            Instantiate(level, this.transform);
        }
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion
}
