using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{

    #region PUBLIC_VARS
    public SpriteRenderer glassSprite;
    public Sprite full, half, empty;
    public int countWaterDrop;
    //public ParticleSystem particleSystem;

    #endregion

    #region PRIVATE_VARS
    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        //Invoke("Nothing", 3);
        
    }
    private void OnEnable()
    {
        Events.toResetTheCount += ResetTheCount;
        Events.numnerOfWaterDrops += NumberOfDrops;
    }

    private void OnDisable()
    {
        Events.toResetTheCount -= ResetTheCount;
        Events.numnerOfWaterDrops -= NumberOfDrops;

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {

       
        WaterDroplets waterDroplets = collision.gameObject.GetComponent<WaterDroplets>();
        if (waterDroplets != null)
        {
            waterDroplets.rb.velocity = new Vector2(0, 0);

            glassSprite.sprite = half;
            //Debug.Log("waterDroplets.rb.velocity==="+ waterDroplets.rb.velocity);
            countWaterDrop++;
        }

        if (countWaterDrop > 20)
        {
            //particleSystem.Play();
            ScreenManage.instance.GamWinPopUp();
            glassSprite.sprite = full;
        }

    }

   
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void ResetTheCount()
    {
        countWaterDrop = 0;
        glassSprite.sprite = empty;

    }

    #endregion

    #region PRIVATE_FUNCTIONS
    private void NumberOfDrops(int No)
    {
        No = countWaterDrop;
    }

  

    #endregion

}
