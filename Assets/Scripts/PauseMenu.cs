using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public bool paused = false;
	public GameObject pauseMenuUI;
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			// if(paused){
			// 	Resume();
			// }else{
			// 	Pause();
			// }
			SceneManager.LoadScene(0);
			Time.timeScale = 1f;
		}
	}
	
	public void Resume(){
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		paused = false;
	}
	
	void Pause(){
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		paused = true;
	}
	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene("Menu");
	}
	public void QuitGame(){
		Application.Quit();
	}
}
