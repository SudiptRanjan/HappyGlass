using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassReset : MonoBehaviour
{

    #region PUBLIC_VARS
    #endregion
    #region PRIVATE_VARS
    private Vector3 initialPosGlass;
    private Quaternion initialRotaationGlass;
   
    #endregion

    #region UNITY_CALLBACKS
    void Start()
    {
        initialPosGlass = gameObject.transform.position;
        initialRotaationGlass = gameObject.transform.rotation;
    }

    private void OnEnable()
    {
        Events.toResetTheGlassPosition += ResetPosition;


    }

    private void OnDisable()
    {
        Events.toResetTheGlassPosition -= ResetPosition;

    }
    #endregion

    #region STATIC_FUNCTIONS
    #endregion

    #region PUBLIC_FUNCTIONS

    #endregion

    #region PRIVATE_FUNCTIONS
    void ResetPosition()
    {
        gameObject.transform.position = initialPosGlass;
        gameObject.transform.rotation = initialRotaationGlass;
    }
    #endregion



}
