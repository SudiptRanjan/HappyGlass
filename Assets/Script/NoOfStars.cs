using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoOfStars : ScriptableObject
{
    public List<Stars> leveData;

}

[System.Serializable]
public class Stars
{
    //public GameObject level;
    public int stars;
    //public string level;
}