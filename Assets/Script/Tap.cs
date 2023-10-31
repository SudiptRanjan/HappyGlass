using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    #region PUBLIC_VARS
    public WaterDroplets waterDropLets;
    public GameObject tapOpening;
    public List<WaterDroplets> waterList;
    //public Transform waterdropletPosition;
    #endregion
    #region PRIVATE_VARS
    [SerializeField] Transform waterdropletPosition;

    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        waterdropletPosition = DrawManager.drawManagerInstance.waterDropPosition;
        InstantiateWaterDroplets();
        
       
    }

   

    private void OnEnable()
    {
        Events.startWaterFlow += ToStartWaterFlow;
        Events.toRefillWater += RefillWater;
    }

    private void OnDisable()
    {
        Events.startWaterFlow -= ToStartWaterFlow;
        Events.toRefillWater -= RefillWater;
    }

    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void ToStartWaterFlow()
    {  
        StartCoroutine(StartSpawning());
    }

    public void InstantiateWaterDroplets()
    {
        for (int i = 0; i < 100; i++)
        {
            WaterDroplets water = Instantiate(waterDropLets, waterdropletPosition.transform);
            waterList.Add(water);
            //waterListCount = waterList.Count;
            waterDropLets.rb.isKinematic = true;
        }
       
    }

    public void RefillWater()
    {
        
        foreach( var waterDrops in waterList)
        {
            waterDrops.gameObject.SetActive(false);
            waterDrops.transform.position = waterdropletPosition.transform.position;
            waterDrops.rb.isKinematic = true;
            Vector2 forceDirection = new Vector2(0.05f, 0.05f);
            waterDrops.rb.AddForce(forceDirection);
            DrawManager.drawManagerInstance.istapOff = true;
        }


    }

    #endregion

    #region PRIVATE_FUNCTIONS

    IEnumerator StartSpawning()
    {
       
        foreach (var waterDrops in waterList)
        {
            waterDrops.gameObject.SetActive(true);
           
        }

            for (int j = 0; j <= waterList.Count; j++)
            {
                //Instantiate(waterDrop, tapOpening.transform.position, Quaternion.identity);

                waterList[j].shoot(tapOpening,-transform.up);
                 //waterListCount--;
                //if (waterListCount == 0)
                //{
                //    waterList.Clear();
                //}
                yield return new WaitForSeconds(0.023f);
            }

    }
    #endregion


}
