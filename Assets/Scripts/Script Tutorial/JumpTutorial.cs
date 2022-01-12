using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorial : MonoBehaviour
{
    
    public GameObject jumpTutorial;

    bool isActive = false;

    public AudioSource audioEffect;

    private void Update(){

        if(isActive){

            StartCoroutine(WaitAfterShow());

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Player"){

            isActive = true;
            audioEffect.Play();
            jumpTutorial.SetActive(true);

        }

    }

    IEnumerator WaitAfterShow()
    {
        isActive = true;

        yield return new WaitForSeconds(3);

        jumpTutorial.SetActive(false);

        audioEffect.Play();
    }

}
