using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    
    private float lenght, startpos;

    public GameObject kamera;

    public float parallaxEffect;

    void Start()
    {
        
        startpos = transform.position.x;

        lenght = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    void FixedUpdate()
    {
        float temp  = (kamera.transform.position.x * (1 - parallaxEffect));

        float dist = (kamera.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + lenght)
        {
            
            startpos += lenght;

        }
        else if (temp < startpos - lenght)
        {

            startpos -= lenght;

        }

    }

}
