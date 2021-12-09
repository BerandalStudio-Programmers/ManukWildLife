using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimberController : MonoBehaviour
{

    public GameObject timberWood;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "boulder")
        {
            timberWood.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            collision.gameObject.GetComponent<ObjectInterectableController>().interacted = false;
            collision.gameObject.GetComponent<ObjectInterectableController>().rolling = false;
            Destroy(this);
        }
    }
}
