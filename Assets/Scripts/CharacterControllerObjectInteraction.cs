using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerObjectInteraction : MonoBehaviour
{
    public LayerMask objectMask;
    public bool rigidBodyApplied;
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
            if (interactableObject.transform.name == "boulder")
            {
                interactableObject.GetComponent<ObjectInterectableController>().rolling = true;
            }

            interactableObject.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        } else if (Input.GetKeyUp(KeyCode.E))
        {
            interactableObject.GetComponent<FixedJoint2D>().enabled = false;
            if (interactableObject.GetComponent<ObjectInterectableController>().rolling == false)
                interactableObject.GetComponent<ObjectInterectableController>().interacted = false;
        }
    }
}
