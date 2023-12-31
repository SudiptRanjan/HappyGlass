using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    
    #region PUBLIC_VARS
    public WaterDroplets waterDropLets;
    public GameObject tapOpening;
    public List<WaterDroplets> waterList;
    
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
        for (int i = 0; i < 30; i++)
        {
            WaterDroplets water = Instantiate(waterDropLets, waterdropletPosition.transform);
            waterList.Add(water);
            //waterListCount = waterList.Count;
            waterDropLets.rb.isKinematic = true;
        }
    }     
    public void RefillWater()
    {

        foreach ( var waterDrops in waterList)
        {
            waterDrops.gameObject.SetActive(false);
            //Debug.Log("Next  Level reset Sccessfull");
            waterDrops.transform.position = waterdropletPosition.transform.position;
            waterDrops.rb.isKinematic = true;
            Vector2 forceDirection = new Vector2(0.05f, 0.05f);
            waterDrops.rb.AddForce(forceDirection);
            DrawManager.drawManagerInstance.istapOff = true;

        }
        //InstantiateWaterDroplets();
        //ToStartWaterFlow();
    }

    #endregion

    #region PRIVATE_FUNCTIONS

    IEnumerator StartSpawning()
    {
       
      

        foreach (var waterDrops in waterList)
        {
            waterDrops.gameObject.SetActive(true);
           
        }


            for (int j = 0; j < waterList.Count; j++)
            {
                waterList[j].shoot(tapOpening,-transform.up);
               
                yield return new WaitForSeconds(0.06f);
            }

    }
    #endregion


}