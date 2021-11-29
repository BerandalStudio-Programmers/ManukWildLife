using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject ButtonPanel;

    public Animator Loader;

    public float LoaderTime = 1f;

    public void SettingPanel(){

        SceneManager.LoadScene(0);

        Loader.SetBool("Start", false);

        ButtonPanel.SetActive(true);
        
    }

    public void PlayLoader()
    {

        StartCoroutine(FadeLoader(SceneManager.GetActiveScene().buildIndex + 1));
        

    }


    IEnumerator FadeLoader(int SceneIndex)
    {
        Loader.SetBool("Start", true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneIndex);

    }

}
