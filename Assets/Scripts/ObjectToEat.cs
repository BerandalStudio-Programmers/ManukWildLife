using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectToEat : MonoBehaviour
{

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
          
            if (Input.GetKeyDown(KeyCode.E))
            {
                
                HungryController.hungry += 50f;
                Destroy(gameObject);

            }
            
        }
    }
}
