using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerObjectInteraction : MonoBehaviour
{
    public LayerMask objectMask;
    public bool rigidBodyApplied;
    GameObject interactableObject;

    public GameObject player;

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D interact = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 1, objectMask);

        if (interact.collider != null && interact.collider.gameObject.tag == "Interactable" && Input.GetMouseButtonDown(0))
        {
            interactableObject = interact.collider.gameObject;
            if(interactableObject != null)
            {
                interactableObject.GetComponent<FixedJoint2D>().enabled = true;
                interactableObject.GetComponent<ObjectInterectableController>().interacted = true;
                PlayerMovement.interacting = true;

                player.GetComponent<Animator>().SetBool("Push", true);

                if (interactableObject.transform.name == "boulder")
                {
                    interactableObject.GetComponent<ObjectInterectableController>().rolling = true;
                }

                interactableObject.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            }
            
        } else if (Input.GetMouseButtonUp(0))
        {
            if(interactableObject != null)
            {
                interactableObject.GetComponent<FixedJoint2D>().enabled = false;
                interactableObject.GetComponent<ObjectInterectableController>().interacted = false;
                if (interactableObject.GetComponent<ObjectInterectableController>().rolling == true)
                    interactableObject.GetComponent<ObjectInterectableController>().rolling = false;
                PlayerMovement.interacting = false;

                player.GetComponent<Animator>().SetBool("Push", false);
            }
        }   
    }
}
