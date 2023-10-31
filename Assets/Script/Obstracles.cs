using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstricle : MonoBehaviour
{

    #region PUBLIC_VARS
    #endregion
    #region PRIVATE_VARS
    Rigidbody2D rd;
    Vector2 originalPosition;

    #endregion

    #region UNITY_CALLBACKS
    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        originalPosition = gameObject.transform.position;
    }

    private void Update()
    {
        if (DrawManager.drawManagerInstance.istapOff == false)
        {
            SetPhysicsTrue();
        }
        else
        {
            ResetPosition();
        }
    }

    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    public void SetPhysicsTrue()
    {
        rd.isKinematic = false;
        rd.freezeRotation = false;
    }

    public void ResetPosition()
    {
        rd.isKinematic = true;
        rd.velocity = new Vector2(0f, 0f);
        rd.freezeRotation = true;
        //gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
        gameObject.transform.position = originalPosition;
    }
    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion





}
