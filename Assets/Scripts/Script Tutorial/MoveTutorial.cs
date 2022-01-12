using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : MonoBehaviour
{
    public GameObject moveTutorial;

    bool isActice = false;

    public AudioSource audioEffect;

    private void Update()
    {
        if(isActice == true){

            StartCoroutine(WaitAfterShow());

        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){

            isActice = true;
            audioEffect.Play();
            moveTutorial.SetActive(true);

        }
    }

    private IEnumerator WaitAfterShow()
    {
        
        isActice = true;

        yield return new WaitForSeconds(3);

        moveTutorial.SetActive(false);

        audioEffect.Play();

    }
    
    

}
