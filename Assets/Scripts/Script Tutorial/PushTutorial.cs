using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTutorial : MonoBehaviour
{
    public GameObject pushTutorial;

    bool isActive = false;

    public AudioSource audioEffect;

    private void Update()
    {
        
        if(isActive){

            StartCoroutine(WaitAfterShow());

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){

            isActive = true;
            audioEffect.Play();
            pushTutorial.SetActive(true);

        }    
    }

    private IEnumerator WaitAfterShow()
    {
        isActive = true;

        yield return new WaitForSeconds(3);

        pushTutorial.SetActive(false);

        audioEffect.Play();
    }
}
