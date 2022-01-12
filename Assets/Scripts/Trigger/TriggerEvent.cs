using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public string colliderTag;
    public UnityEvent onTriggerEnter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(colliderTag))
        {
            onTriggerEnter.Invoke();
            print("Trigger Enter");
        }
    }
}
