using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerObjectInteraction : MonoBehaviour
{
    public LayerMask objectMask;
    GameObject interactableObject;

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D interact = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, 1, objectMask);

        if (interact.collider != null && interact.collider.gameObject.tag == "Interactable" && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject = interact.collider.gameObject;

            interactableObject.GetComponent<FixedJoint2D>().enabled = true;
            interactableObject.GetComponent<ObjectInterectableController>().interacted = true;

            interactableObject.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();

            CharacterController2D.interacting = true;
        } else if (Input.GetKeyUp(KeyCode.E))
        {
            interactableObject.GetComponent<FixedJoint2D>().enabled = false;
            interactableObject.GetComponent<ObjectInterectableController>().interacted = false;
            CharacterController2D.interacting = false;
        }
    }
}
