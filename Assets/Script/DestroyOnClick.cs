using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{

    

    private void OnMouseDown()
    {
        DeactiavteObject();
    }

   private void DeactiavteObject()
    {
        gameObject.SetActive(false);
    }
    private void ActiveObject()
    {
        gameObject.SetActive(true);
        Debug.Log("Active");
    }
}
