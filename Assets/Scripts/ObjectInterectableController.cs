using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInterectableController : MonoBehaviour
{

    public bool interacted;
    public bool rolling;
    private float xPosition;
    
    void Start()
    {
        xPosition = transform.position.x;
    }

    void Update()
    {
        if (rolling == false)
        {
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        } else
        {
            transform.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

        if (interacted == false)
        {
            transform.position = new Vector2(xPosition, transform.position.y);
        } else
        {
            xPosition = transform.position.x;
        }
    }
}
