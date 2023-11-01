using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NoOfStars : ScriptableObject
{
    public List<Stars> listOfStars;

}

[System.Serializable]
public class Stars
{
    public int stars;
    public string level;
}