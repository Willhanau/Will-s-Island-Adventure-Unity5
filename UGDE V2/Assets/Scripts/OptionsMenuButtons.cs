using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OptionsMenuButtons : MonoBehaviour {
	[SerializeField]
	private GameObject optionsPanel;
	[SerializeField]
	private GameObject confirmPanel;

	public void openMenu(){
		Time.timeScale = 0;
		optionsPanel.SetActive (true);
	}

	public void resumeGame(){
		Time.timeScale = 1;
		optionsPanel.SetActive (false);
	}

	public void restartGame(){
		Time.timeScale = 1;
		SceneManager.LoadScene (1);
	}
		
	public void quitGame(){
		confirmPanel.SetActive (true);
	}

	public void confirmQuit(){
		Application.Quit ();
		Time.timeScale = 1;
		SceneManager.LoadScene (0);

	}

	public void cancelQuit(){
		confirmPanel.SetActive (false);
	}

	public void changeVolume(float value){
		AudioListener.volume = value;
	}

}
