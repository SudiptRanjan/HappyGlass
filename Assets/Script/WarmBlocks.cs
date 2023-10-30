using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmBlocks : MonoBehaviour
{
    public Tap tap;
    public Transform waterDropPosition;
    public ParticleSystem flameParticle;
    // Start is called before the first frame update
    void Start()
    {
        flameParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
}
