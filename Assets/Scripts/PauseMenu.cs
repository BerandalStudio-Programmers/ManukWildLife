using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{
    public bool paused = false;

	SaveSystem playerPosData;

	public GameObject pauseMenuUI;

	void Start()
	{
		playerPosData = FindObjectOfType<SaveSystem>();
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			if(paused){
				Resume();
			}else{
				Pause();
			}
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
		playerPosData.PlayerPosSave();
		SceneManager.LoadScene("MainMenu");
	}
	public void QuitGame(){
		Application.Quit();
	}
}
