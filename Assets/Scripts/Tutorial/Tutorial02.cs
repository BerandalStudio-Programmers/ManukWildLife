using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial02 : MonoBehaviour
{
    bool allowed;

    private void OnEnable()
    {
        allowed = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.SetActive(false);
        }
    }
}
