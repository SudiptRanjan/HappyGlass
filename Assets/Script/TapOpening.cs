using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapOpening : MonoBehaviour
{
   
    private void OnEnable()
    {
       Events.toGetTapOpeningPosition += TapPosition;
        
    }

    private void OnDisable()
    {
       Events.toGetTapOpeningPosition -= TapPosition;
    }

    private void TapPosition( GameObject gameObjects)
    {
       gameObjects = this.gameObject;
    }
   
}

