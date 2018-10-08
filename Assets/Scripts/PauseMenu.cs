using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour {

	public string mainMenu;

	public bool isPaused;
	public GameObject pauseMenuCanvas;


	void Update () {
		if(isPaused){

			pauseMenuCanvas.SetActive(true);
		}else{
			pauseMenuCanvas.SetActive(false);
		}

	if (Input.GetKeyDown(KeyCode.Escape)){
		isPaused = !isPaused;
	}		
	}

	public void Resume(){

		isPaused = false;


	}

	public void Quit(){

	SceneManager.LoadScene(mainMenu);


	}
}
