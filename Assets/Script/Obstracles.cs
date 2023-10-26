using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstricle : MonoBehaviour
{

    Rigidbody2D rd;
    Vector2 originalPosition;

    private void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        originalPosition = gameObject.transform.position;
    }

    public void SetPhysicsTrue()
    {
        rd.isKinematic = false;
        rd.freezeRotation = false;
    }

    public void ResetPosition()
    {
        rd.isKinematic = true;
        rd.velocity = new Vector2(0f,0f);
        rd.freezeRotation = true;
        //gameObject.transform.rotation = Quaternion.Euler(new Vector3(0f,0f,0f));
        gameObject.transform.position = originalPosition;
    }
}
