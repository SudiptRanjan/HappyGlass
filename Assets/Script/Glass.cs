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
  private void Update()
  {
    NumberOfDrops(countWaterDrop);
    
  }
    private void OnEnable()
    {
        Events.toResetTheCount += ResetTheCount;
        // Events.numnerOfWaterDrops += NumberOfDrops;
    }

    private void OnDisable()
    {
        Events.toResetTheCount -= ResetTheCount;
        // Events.numnerOfWaterDrops -= NumberOfDrops;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       
        WaterDroplets waterDroplets = collision.gameObject.GetComponent<WaterDroplets>();
        if (waterDroplets != null)
        {
            waterDroplets.rb.velocity = new Vector2(0, 0);

            glassSprite.sprite = half;
        //    Debug.Log("velocity" + waterDroplets.rb.velocity);
            countWaterDrop++;
        }

        if (countWaterDrop > 20)
        {
            //particleSystem.Play();
            //ScreenManage.instance.GamWinPopUp();
            Invoke("OnWin", 5);
            glassSprite.sprite = full;
            ScreenManage.instance.winParticle.Play();

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
        CancelInvoke("OnWin");

    }

    public void OnWin()
    {
        ScreenManage.instance.GamWinPopUp();

    }

    #endregion

    #region PRIVATE_FUNCTIONS
    private void NumberOfDrops(int No)
    {
        No = countWaterDrop;
        // Debug.Log("The  Count====" + No);
        if(No<20 && ScreenManage.instance.count < 1 )
        {
            // DrawManager.drawManagerInstance. Invoke("IsGameOver", 15);
            ScreenManage.instance.Invoke("GameOver", 10);
            // Debug.Log(ScreenManage.instance.count);
        }
    }

    #endregion
}
