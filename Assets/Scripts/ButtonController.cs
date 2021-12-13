using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public Animator loader;

    public float loaderTime = 1f;

    public void MainMenu()
    {

        SceneManager.LoadScene(0);

        Time.timeScale = 1f;
        
    }

    public void PlayGame(){

        StartCoroutine(FadeLoader(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public void QuitGame(){

        Application.Quit();
        Debug.Log("Quit Game");

    }

    IEnumerator FadeLoader(int SceneIndex)
    {
        loader.SetBool("Start", true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneIndex);

    }


}
