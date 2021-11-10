using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    public Vector3 offset;

    [Range(1, 10)]
    public float smoothfactor;

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        
        Follow();

    }

    void Follow(){

        Vector3 targetpos = target.position + offset;

        Vector3 smoothpos = Vector3.Lerp(transform.position, targetpos, smoothfactor*Time.fixedDeltaTime);

        transform.position = targetpos;

    }

}
