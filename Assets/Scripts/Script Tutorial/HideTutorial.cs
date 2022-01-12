using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTutorial : MonoBehaviour
{
    public GameObject hideTutorial;

    public AudioSource audioEffect;

    bool isActive = false;

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
            hideTutorial.SetActive(true);

        }        
    }

    private IEnumerator WaitAfterShow()
    {
        isActive = true;

        yield return new WaitForSeconds(3);

        audioEffect.Play();

        hideTutorial.SetActive(false);
    }

}
