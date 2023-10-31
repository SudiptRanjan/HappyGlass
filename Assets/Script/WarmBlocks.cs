using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmBlocks : MonoBehaviour
{


    #region PUBLIC_VARS
    public ParticleSystem flameParticle;
    #endregion
    #region PRIVATE_VARS
    Transform waterDropPosition;
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        flameParticle.Stop();
        waterDropPosition = DrawManager.drawManagerInstance.waterDropPosition;
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion

    #region PRIVATE_FUNCTIONS
    private void OnCollisionEnter2D(Collision2D collision)
    {
        WaterDroplets waterDroplets = collision.gameObject.GetComponent<WaterDroplets>();

        if (waterDroplets != null)
        {
            waterDroplets.transform.position = waterDropPosition.position;
            waterDroplets.gameObject.SetActive(false);
            waterDroplets.rb.isKinematic = true;
            flameParticle.Play();
            //Debug.Log("Water Dstroyed");
        }
        else
        {
            flameParticle.Stop();
        }


    }
    #endregion





}
