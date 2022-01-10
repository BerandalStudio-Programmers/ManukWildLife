using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLine : MonoBehaviour
{

    public Animator loader;

    public float loaderTime = 1f;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        
        StartCoroutine(FadeLoader(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator FadeLoader(int SceneIndex)
    {
        loader.SetBool("Start", true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneIndex);

    }

}
