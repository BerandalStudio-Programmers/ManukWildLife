using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToEat : MonoBehaviour
{

    public Animator pressToEat;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            // pressToEat.SetTrigger("IsEat");

            if (Input.GetKeyDown(KeyCode.E))
            {
                
                HungryController.hungry += 10f;
                Destroy(gameObject);

            }
            
        }
    }
}
