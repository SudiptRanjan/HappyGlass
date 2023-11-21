using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroplets : MonoBehaviour
{
    #region PUBLIC_VARS
    public Rigidbody2D rb;
    public float power = 10;
    #endregion
    #region PRIVATE_VARS
    Vector2 forceDirection;
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        forceDirection = new Vector2(0.1f, 0.1f);
    }

    void Update()
    {
        rb.AddForce(forceDirection);
    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS
    public void shoot(GameObject tapOpening,Vector2 dir)
    {
        transform.position = tapOpening.transform.position ;
        rb.velocity = dir * power;
        rb.isKinematic = false;
    }

    #endregion

    #region PRIVATE_FUNCTIONS
    #endregion



}
