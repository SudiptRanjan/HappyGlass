using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tap : MonoBehaviour
{
    #region PUBLIC_VARS
    public WaterDroplets waterDropLets;
    public Transform waterdropletPosition;
    public GameObject tapOpening;
    public List<WaterDroplets> waterList;
    public DrawManager DM;
    #endregion
    #region PRIVATE_VARS
    //[SerializeField] float waterListCount;
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        InstantiateWaterDroplets();
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
            WaterDroplets water = Instantiate(waterDropLets,waterdropletPosition);
            waterList.Add(water);
            //waterListCount = waterList.Count;
            waterDropLets.rb.isKinematic = true;
          
        }
       
    }

    public void RefillWater()
    {
        //waterDropLets.transform.position = waterdropletPosition.position;
        //waterList.Add(waterDropLets);
        //waterDropLets.rb.isKinematic = true;
        foreach( var waterDrops in waterList)
        {
            waterDrops.gameObject.SetActive(false);
            waterDrops.transform.position = tapOpening.transform.position;
            waterDrops.rb.isKinematic = true;
            Vector2 forceDirection = new Vector2(0.05f, 0.05f);
            waterDrops.rb.AddForce(forceDirection);
            DM.istapOff = true;
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

        //if (DM.istapOff)

            for (int j = 0; j <= waterList.Count; j++)
            {
            //Instantiate(waterDrop, tapOpening.transform.position, Quaternion.identity);
            //if (!DM.istapOff)
            if (j <= waterList.Count)
                Debug.Log(j+"j ==============waterList.Count "+ waterList.Count);
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
