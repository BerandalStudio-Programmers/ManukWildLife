using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTimberController : MonoBehaviour
{

    private void Update()
    {
        if (gameObject.transform.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Static)
        {
            Destroy(this);
        }    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
