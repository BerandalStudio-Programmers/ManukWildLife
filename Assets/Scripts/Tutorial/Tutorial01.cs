using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial01 : MonoBehaviour
{
    bool allowed;

    private void OnEnable()
    {
        allowed = true;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
        {
            gameObject.SetActive(false);
        }
    }
}
