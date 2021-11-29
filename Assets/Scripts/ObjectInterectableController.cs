using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInterectableController : MonoBehaviour
{

    public bool interacted;
    private float xPosition;

    void Start()
    {
        xPosition = transform.position.x;
    }

    void Update()
    {
        if (interacted == false)
        {
            transform.position = new Vector2(xPosition, transform.position.y);
        } else
        {
            xPosition = transform.position.x;
        }
    }
}
